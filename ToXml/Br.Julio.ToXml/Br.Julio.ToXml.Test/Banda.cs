using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Br.Julio.ToXml.Annotations;
using Br.Julio.ToXml.Interface;

namespace Br.Julio.ToXml.Test
{
    [Root("Banda")]
    public class Banda:IXMLConvertable
    {
        [Field("Nome", typeof(string))]
        public string Nome { get; set; }

        [Field("Genero", typeof(string))]
        public string Genero { get; set; }

        [Field("Pais", typeof(string))]
        public string Pais { get; set; }

        [Field("Ano", typeof(int))]
        public int Ano { get; set; }
    }
}
