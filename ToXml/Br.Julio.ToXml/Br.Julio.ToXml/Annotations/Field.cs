using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Br.Julio.ToXml.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Field : System.Attribute
    {
        private string fieldTag;
        private Type fieldType;

        public Field(string nameField, Type type)
        {
            this.fieldTag = nameField;
            this.fieldType = type;
        }

        public string FieldTag 
        { 
            get 
            { 
                return this.fieldTag; 
            } 
        }

        public Type FieldType 
        { 
            get 
            { 
                return this.fieldType; 
            } 
        }
    }
}
