using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Data.Converter.Contract
{
    public interface IParse<O, D>
    {
        D Parse(O origin);
        List<D> Parse(List<O> origin);
    }
}
