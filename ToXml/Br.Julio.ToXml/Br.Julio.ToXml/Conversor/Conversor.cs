using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Br.Julio.ToXml.Interface;
using Br.Julio.ToXml.Annotations;

namespace Br.Julio.ToXml.Conversor
{
    public static class Conversor
    {
        public static XmlDocument ToXml<T>(this IXMLConvertable obj, string diretorio = "", string versaoXML = "1.0", string encode = "UTF-8")
        {
            //Pegando o nome do elemento raiz
            var objeto = (T)obj;
            Root classe = (Root)Attribute.GetCustomAttribute(objeto.GetType(), typeof(Root));    

            //Inicializando o documento
            XmlDocument objetoConvertido = new XmlDocument();
            XmlDeclaration declaracaoXML = objetoConvertido.CreateXmlDeclaration(versaoXML, encode, null);

            XmlElement initialize = objetoConvertido.DocumentElement;
            objetoConvertido.InsertBefore(declaracaoXML, initialize);

            XmlElement raiz = objetoConvertido.CreateElement(string.Empty, classe.TagRoot, string.Empty);
            objetoConvertido.AppendChild(raiz);

            //obtendo os valores das propriedades
            var propriedades = objeto.GetType().GetProperties();
            foreach (var propriedade in propriedades)
            {
                var atributosCustomizados = propriedade.GetCustomAttributes(typeof(Field), false);
                foreach (var atributoCustomizado in atributosCustomizados)
                {
                    var nomePropriedade = atributoCustomizado.GetType().GetProperty("FieldTag").GetValue(atributoCustomizado, null).ToString();
                    var tipoPropriedade = atributoCustomizado.GetType().GetProperty("FieldType").GetValue(atributoCustomizado, null);
                    var valorPropriedade = propriedade.GetValue(objeto, null);

                    XmlElement elemento = objetoConvertido.CreateElement(string.Empty, nomePropriedade, string.Empty);
                    elemento.InnerText = valorPropriedade.ToString();
                    elemento.SetAttribute("tipo", tipoPropriedade.ToString());
                    raiz.AppendChild(elemento);
                }
            }

            //verifica se e possivel salvar o documento xml
            if (!string.IsNullOrEmpty(diretorio))
                objetoConvertido.Save(diretorio + classe.TagRoot + ".xml");

            return objetoConvertido;
        }
    }
}
