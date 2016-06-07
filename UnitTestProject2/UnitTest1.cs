using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {


            var res = Filtr.Go(new List<Filter>
            {
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Farg,
                    Value = "blå"
                },
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Storlek,
                    Value = "S"
                },
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Farg,
                    Value = "grön"
                },
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Marke,
                    Value = "Addidas"
                }
            });

            Assert.AreEqual(1, res.Count);

        }
        [TestMethod]
        public void TestMethod2()
        {


            var res = Filtr.Go(new List<Filter>
            {
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Farg,
                    Value = "blå"
                },
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Storlek,
                    Value = "S"
                },
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Farg,
                    Value = "grön"
                },
                new Filter
                {
                    Execute = false,
                    PropertyType = PropertyType.Marke,
                    Value = "Addidas"
                }
            });

            Assert.AreEqual(3, res.Count);

        }
        [TestMethod]
        public void TestMethod3()
        {


            var res = Filtr.Go(new List<Filter>
            {
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Farg,
                    Value = "blå"
                },
                new Filter
                {
                    Execute = false,
                    PropertyType = PropertyType.Storlek,
                    Value = "S"
                },
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Farg,
                    Value = "grön"
                },
                new Filter
                {
                    Execute = false,
                    PropertyType = PropertyType.Marke,
                    Value = "Addidas"
                }
            });

            Assert.AreEqual(5, res.Count);

            res = Filtr.Go(new List<Filter>
            {
                new Filter
                {
                    Execute = false,
                    PropertyType = PropertyType.Farg,
                    Value = "blå"
                },
                new Filter
                {
                    Execute = false,
                    PropertyType = PropertyType.Storlek,
                    Value = "S"
                },
                new Filter
                {
                    Execute = false,
                    PropertyType = PropertyType.Farg,
                    Value = "grön"
                },
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Marke,
                    Value = "Addidas"
                }
            });

            Assert.AreEqual(2, res.Count);

            res = Filtr.Go(new List<Filter>
            {
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Farg,
                    Value = "blå"
                },
                new Filter
                {
                    Execute = false,
                    PropertyType = PropertyType.Storlek,
                    Value = "S"
                },
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Farg,
                    Value = "grön"
                },
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Marke,
                    Value = "Addidas"
                },
                new Filter
                {
                    Execute = true,
                    PropertyType = PropertyType.Storlek,
                    Value = "M"
                }
            });

            Assert.AreEqual(1, res.Count);
        }
    }
}
