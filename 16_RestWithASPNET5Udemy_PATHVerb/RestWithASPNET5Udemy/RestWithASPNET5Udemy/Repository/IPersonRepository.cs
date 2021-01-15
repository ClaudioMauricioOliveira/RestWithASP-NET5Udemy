using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Repository.Generic;

namespace RestWithASPNET5Udemy.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
