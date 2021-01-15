using RestWithASPNET5Udemy.Hipermedia.Abstract;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Hipermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
