using RestWithASPNET5Udemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindByID(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
