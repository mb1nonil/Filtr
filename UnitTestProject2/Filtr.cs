using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject2
{
    public class Filter
    {
        public bool Execute { get; set; }
        public PropertyType PropertyType { get; set; }
        public string Value { get; set; }
    }

    public class Filtr
    {
        public static List<Product> Go(List<Filter> filters)
        {
            List<List<Product>> result = new List<List<Product>>();

            filters = filters.Where(x => x.Execute).ToList();

            foreach (var group in filters.GroupBy(x => x.PropertyType))
            {
                List<Product> result2 = new List<Product>();


                foreach (var filter in group)
                {
                        var temp = products.Where(x => x.Properties.Any(y => y.Type == filter.PropertyType && y.Value == filter.Value));

                        result2.AddRange(temp);
                
                }
                result.Add(result2);
            }

            result = result.OrderByDescending(x => x.Count).ToList();


            List<Product> res = new List<Product>();
            foreach (var item in result[0])
            {
                var jj = result.Count - 1;

                for (int i = 1; i < result.Count; i++)
                {

                    foreach (var jitem in result[i])
                    {
                        var j = result.Count;

                        foreach (var prop in item.Properties)
                        {
                            foreach (var jprop in jitem.Properties)
                            {
                                if ((filters.Any(x => x.Execute && x.PropertyType == prop.Type)) && jprop.Type == prop.Type && jprop.Value == prop.Value)
                                {
                                    j--;
                                    break;
                                }
                            }
                            
                        }
                        if (j <= 0)
                        {
                            jj--;
                        }

                    }

                   
                }
                if (jj <= 0)
                {
                    res.Add(item);
                }
            }
            res = res.Distinct().ToList();
            return res;
        }


        public static List<Product> products = new List<Product>
        {
            new Product
            {
                Name = "Skor1",
                Properties = new List<Property>
                {
                    new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Storlek,
                    Value = "S"
                    },
                    new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Marke,
                    Value = "Addidas"
                    },
                       new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Farg,
                    Value = "blå"
                    }
                }
            },
             new Product
            {
                Name = "Skor2",
                Properties = new List<Property>
                {
                    new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Storlek,
                    Value = "M"
                    },
                    new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Marke,
                    Value = "Addidas"
                    },
                       new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Farg,
                    Value = "grön"
                    }
                }
            },
              new Product
            {
                Name = "Skor3",
                Properties = new List<Property>
                {
                    new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Storlek,
                    Value = "XL"
                    },
                    new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Marke,
                    Value = "Reebook"
                    },
                       new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Farg,
                    Value = "blå"
                    }
                }
            },
              new Product
            {
                Name = "Skor4",
                Properties = new List<Property>
                {
                    new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Storlek,
                    Value = "S"
                    },
                    new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Marke,
                    Value = "Reebook"
                    },
                       new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Farg,
                    Value = "grön"
                    }
                }
            },
              new Product
            {
                Name = "Skor5",
                Properties = new List<Property>
                {
                    new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Storlek,
                    Value = "S"
                    },
                    new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Marke,
                    Value = "Reebook"
                    },
                       new Property
                    {
                        Id = Guid.NewGuid(),
                    Type = PropertyType.Farg,
                    Value = "blå"
                    }
                }
            }
        };
    }
}
