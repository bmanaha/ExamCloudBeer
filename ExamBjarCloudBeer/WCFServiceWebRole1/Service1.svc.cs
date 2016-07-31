using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    //http://bjarkexambeercloud.cloudapp.net/Service1.svc/beers/
    public class Service1 : IService1
    {
        private static readonly IList<Beer> Beers = new List<Beer>();
        private static int _nextId = 2;

        static Service1()
        {
            Beer newBeer = new Beer()
            {
                Id = 1,
                BeerName = "Carlsberg Pilsner",
                BeerStyle = "Pilsner",
                Abv = "4.6"
            };
            Beers.Add(newBeer);

        }
        public IList<Beer> GetBeers()
        {
            return Beers;
        }
        public Beer GetBeer(string id)
        {
            int idNumber = int.Parse(id);
            return Beers.FirstOrDefault(beer => beer.Id == idNumber);
        }
        public Beer AddBeer(Beer beer)
        {

            beer.Id = _nextId++;
            Beers.Add(beer);
            return beer;
        }
        public Beer UpdateBeer(string id, Beer beer)
        {
            int idNumber = int.Parse(id);
            Beer existingBeer = Beers.FirstOrDefault(b => b.Id == idNumber);
            if (existingBeer == null) return null;
            existingBeer.BeerName = beer.BeerName;
            existingBeer.BeerStyle = beer.BeerStyle;
            existingBeer.Abv = beer.Abv;
            return existingBeer;
        }
        public Beer DeleteBeer(string id)
        {
            Beer beer = GetBeer(id);
            if (beer == null) return null;
            bool removed = Beers.Remove(beer);
            if (removed) return beer;
            return null;
        }
    }
}
