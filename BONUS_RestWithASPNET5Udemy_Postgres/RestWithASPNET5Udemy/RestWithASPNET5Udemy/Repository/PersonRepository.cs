using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Model.Context;
using RestWithASPNET5Udemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5Udemy.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(PostgreSQLContext context) : base(context) { }

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

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            }
            else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
            }
            else
            {
                return null;
            }

        }
    }
}
