using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Hipermedia.Utils;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindByID(long id);
        List<BookVO> FindAll();
        PagedSearchVO<BookVO> FindWithPagedSearch(string title, string sortDirections, int pageSize, int page);
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
