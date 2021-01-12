using RestWithASPNET5Udemy.Model;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Business
{
    public interface IBookBusiness
    {
        Book Create(Book Book);
        Book FindByID(long id);
        List<Book> FindAll();
        Book Update(Book Book);
        void Delete(long id);
    }
}
