using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFServiceWebRole1
{
    public class Beer
    {
        public int Id { get; set; }
        public string BeerName { get; set; }
        public string BeerStyle { get; set; }
        public string Abv { get; set; }

    }
}