using RestWithASPNET5Udemy.Data.Converter.Implementation;
using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Hipermedia.Utils;
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

        public PagedSearchVO<BookVO> FindWithPagedSearch(string title, string sortDirections, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirections) && !sortDirections.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offSet = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from books b where 1=1 ";
            if (!string.IsNullOrWhiteSpace(title)) query += $" and b.title like '%{title}%'";
            query += $" order by b.title {sort} limit {size} offset {offSet}";

            string countQuery = @"select count(*) from books b where 1=1 ";
            if (!string.IsNullOrWhiteSpace(title)) countQuery += $" and b.title like '%{title}%'";

            var books = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<BookVO>
            {
                CurrentPage = page,
                List = _converter.Parse(books),
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public BookVO Update(BookVO book)
        {
            var BookEntity = _converter.Parse(book);
            BookEntity = _repository.Update(BookEntity);
            return _converter.Parse(BookEntity);
        }
    }
}
