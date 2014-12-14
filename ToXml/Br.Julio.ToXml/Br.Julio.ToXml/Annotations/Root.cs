using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Br.Julio.ToXml.Annotations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Root:System.Attribute
    {
        private string rootTag;

        public Root(string nameTag)
        {
            this.rootTag = nameTag;
        }

        public string TagRoot 
        {
            get
            {
                return this.rootTag;
            }        
        }
    }
}
