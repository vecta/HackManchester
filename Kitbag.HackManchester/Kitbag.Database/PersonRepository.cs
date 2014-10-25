using System;
using System.Collections.Generic;
using System.Linq;
using Kitbag.Domain;

namespace Kitbag.Database
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(CwonData dbContext) : base(dbContext) { }

        public IEnumerable<Person> GetByGroup(int groupId) { return _dbContext.People.Where(x => x.Id == groupId).ToList(); }

        public Person GetByEmail(string email)
        {
            return _dbContext.People.SingleOrDefault(person => string.Compare(person.Email, email, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        public IList<Person> GetByGroup(int groupId)
        {
            
            var people = base._dbContext.Groups.FirstOrDefault(x => x.Id == groupId).People1.ToList();


            return people;
        }
    }
}