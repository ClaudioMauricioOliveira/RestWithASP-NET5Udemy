using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Model.Context;
using RestWithASPNET5Udemy.Repository.Generic;
using System;
using System.Linq;

namespace RestWithASPNET5Udemy.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(MySQLContext context) : base(context) { }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;
            var person = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (person != null)
            {
                person.Enabled = false;

                try
                {
                    _context.Entry(person).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return person;
        }
    }
}
