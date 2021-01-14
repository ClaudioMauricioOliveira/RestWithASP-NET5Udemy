﻿using RestWithASPNET5Udemy.Hipermedia;
using RestWithASPNET5Udemy.Hipermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Data.VO
{
    public class PersonVO: ISupportsHyperMedia
    { 
        public long Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Address { get; set; }
        
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}