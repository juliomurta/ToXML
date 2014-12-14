using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Br.Julio.ToXml.Annotations;
using Br.Julio.ToXml.Interface;

namespace Br.Julio.ToXml.Test
{
    [Root("Estado")]
    public class Estado:IXMLConvertable
    {
        [Field("Sigla", typeof(string))]
        public string Sigla { get; set; }

        [Field("Nome", typeof(string))]
        public string Nome { get; set; }
    }
}
