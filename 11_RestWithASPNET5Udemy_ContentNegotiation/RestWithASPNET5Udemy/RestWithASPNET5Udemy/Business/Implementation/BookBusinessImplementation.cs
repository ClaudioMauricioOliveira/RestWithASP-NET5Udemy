using RestWithASPNET5Udemy.Data.Converter.Implementation;
using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Business.Implementation
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> respository)
        {
            _repository = respository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var BookEntity = _converter.Parse(book);
            BookEntity = _repository.Create(BookEntity);
            return _converter.Parse(BookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BookVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public BookVO Update(BookVO book)
        {
            var BookEntity = _converter.Parse(book);
            BookEntity = _repository.Update(BookEntity);
            return _converter.Parse(BookEntity);
        }
    }
}
