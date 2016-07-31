using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCFServiceWebRole1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //test on the class Beer in the webservice project
        //Id = 1, BeerName = "Carlsberg Pilsner", BeerStyle = "Pilsner", Abv = "4.6"
        public void TestMethod1()
        {
            IService1 beerService = new Service1();
            IList<Beer> beers = beerService.GetBeers();
            
            Assert.AreEqual(1, beers.Count);

            Beer beer = beerService.GetBeer("1");
            Assert.AreEqual("Carlsberg Pilsner", beer.BeerName);

            Assert.IsNull(beerService.GetBeer("100"));


          

            Beer s1 = new Beer { BeerName = "HCA", BeerStyle = "Aargang2006", Abv = "10" };
            Beer s1Copy = beerService.AddBeer(s1);
            Assert.AreEqual(2, s1Copy.Id);
            Assert.AreEqual("HCA", s1Copy.BeerName);
            s1Copy.BeerName = "Strange Beer";
            Beer updatedBeer = beerService.UpdateBeer(s1Copy.Id.ToString(), s1Copy);
            Assert.AreEqual("Strange Beer", updatedBeer.BeerName);

            Beer bCopy2 = beerService.DeleteBeer("2");
            Assert.AreEqual(2, bCopy2.Id);
            Assert.AreEqual("Strange Beer", bCopy2.BeerName);

            Assert.AreEqual(1, beerService.GetBeers().Count);

            Assert.IsNull(beerService.DeleteBeer("100"));

        }
    }
}
