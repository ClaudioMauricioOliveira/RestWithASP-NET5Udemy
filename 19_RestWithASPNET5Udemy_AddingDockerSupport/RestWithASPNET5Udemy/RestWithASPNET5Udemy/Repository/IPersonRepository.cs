using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Repository.Generic;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string lastName);
    }
}
