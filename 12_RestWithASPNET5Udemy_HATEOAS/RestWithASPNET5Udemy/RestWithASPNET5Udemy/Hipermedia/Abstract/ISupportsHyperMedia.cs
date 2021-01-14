using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Hipermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
