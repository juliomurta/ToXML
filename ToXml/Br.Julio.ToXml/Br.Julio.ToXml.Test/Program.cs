using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Br.Julio.ToXml.Conversor;

namespace Br.Julio.ToXml.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Banda banda = new Banda();
            banda.Nome = "Kraftwerk";
            banda.Genero = "Eletronica";
            banda.Pais = "Alemanha";
            banda.Ano = 1970;

            var d1 = banda.ToXml<Banda>("C:\\");

            Estado estado = new Estado();

            estado.Sigla = "SP";
            estado.Nome = "Sao Paulo";

            var d2 = estado.ToXml<Estado>("C:\\");
        }
    }
}
