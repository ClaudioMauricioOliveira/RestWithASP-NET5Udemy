using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Repository;
using RestWithASPNET5Udemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Business.Implementation
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;

        public BookBusinessImplementation(IRepository<Book> respository)
        {
            _repository = respository;
        }

        public Book Create(Book Book)
        {
            return _repository.Create(Book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Book Update(Book Book)
        {
            return _repository.Update(Book);
        }
    }
}
