using RestWithASPNET5Udemy.Data.Converter.Implementation;
using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Hipermedia.Utils;
using RestWithASPNET5Udemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Business.Implementation
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository respository)
        {
            _repository = respository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirections, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirections) && !sortDirections.Equals("desc")) ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offSet = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from person p where 1=1 ";
            if (!string.IsNullOrWhiteSpace(name)) query += $" and p.first_name like '%{name}%'";
            query += $" order by p.first_name {sort} limit {size} offset {offSet}";

            string countQuery = @"select count(*) from person p where 1=1 ";
            if (!string.IsNullOrWhiteSpace(name)) countQuery += $" and p.first_name like '%{name}%'";

            var persons = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO>
            {
                CurrentPage = page,
                List = _converter.Parse(persons),
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
    }
}
