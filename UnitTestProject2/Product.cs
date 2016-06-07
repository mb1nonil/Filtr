using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2
{
    public class Product
    {
        public List<Property> Properties { get; set; }
        public string Name { get; set; }

    }

    public class Property
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public PropertyType Type { get; set; }

    }

    public enum PropertyType
    {
        Storlek,
        Farg,
        Marke
    }
}
