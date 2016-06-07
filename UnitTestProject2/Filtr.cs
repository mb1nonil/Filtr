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

            // filtrera bort onödiga filter
            filters = filters.Where(x => x.Execute).ToList();

            //Gruppera på typ för att skapa en union för varje typ
            //Då kan vi sedan jämföra X antal listor och utgå från den med flest i och sedan hitta där den har matchningar i andra listor
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

            //Tror bara att ngn måste vara principal
            result = result.OrderByDescending(x => x.Count).ToList();

            //Här lägger vi till de produkter som har tillräckligt matchande parametrar
            List<Product> res = new List<Product>();

            //Principal att iterera igenom
            foreach (var item in result[0])
            {
                // initiera en nedgående räknare för antalet matchningar i de andra typ-listorna. Man måste hitta matchning i alla listor utom sig själv
                var jj = result.Count - 1;

                for (int i = 1; i < result.Count; i++)
                {

                    //Gå igenom varje item i de sekuundära listorna
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
                    Type = PropertyType.Storlek,
                    Value = "S"
                    },
                    new Property
                    {
                    Type = PropertyType.Marke,
                    Value = "Addidas"
                    },
                       new Property
                    {
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
                    Type = PropertyType.Storlek,
                    Value = "M"
                    },
                    new Property
                    {
                    Type = PropertyType.Marke,
                    Value = "Addidas"
                    },
                       new Property
                    {
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
                    Type = PropertyType.Storlek,
                    Value = "XL"
                    },
                    new Property
                    {
                    Type = PropertyType.Marke,
                    Value = "Addidas"
                    },
                       new Property
                    {
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
                    Type = PropertyType.Storlek,
                    Value = "S"
                    },
                    new Property
                    {
                    Type = PropertyType.Marke,
                    Value = "Reebook"
                    },
                       new Property
                    {
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
                    Type = PropertyType.Storlek,
                    Value = "S"
                    },
                    new Property
                    {
                    Type = PropertyType.Marke,
                    Value = "Reebook"
                    },
                       new Property
                    {
                    Type = PropertyType.Farg,
                    Value = "blå"
                    }
                }
            },
              new Product
            {
                Name = "Skor6",
                Properties = new List<Property>
                {
                    new Property
                    {
                    Type = PropertyType.Storlek,
                    Value = "XL"
                    },
                    new Property
                    {
                    Type = PropertyType.Marke,
                    Value = "Addidas"
                    },
                       new Property
                    {
                    Type = PropertyType.Doft,
                    Value = "citron"
                    }
                }
            }
        };
    }
}
