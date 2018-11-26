using System;


namespace ChustaSoft.Common.Models
{
    public class PropertyInfo
    {
        
        public Type Type => Value.GetType();

        public string Name { get; set; }

        public object Value { get; set; }

    }
}
