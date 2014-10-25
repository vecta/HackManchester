using System;
using System.Linq;
using Kitbag.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kitbag.Database.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private Repository<Person> _personRepository; 
        
        [TestInitialize]
        public void Setup()
        {
            _personRepository = new Repository<Person>(new CwonData());
        }

        [TestMethod, Ignore]
        public void CreatePerson()
        {
            var newUser = new Person
            {
                FirstName = "Matthew",
                LastName = "Hughes",
                Email = "sdsdsd@ddssd.com"
            }; 

            _personRepository.Create(newUser);

            var currentUser = _personRepository.GetAll().FirstOrDefault(p => p.Email == newUser.Email);

            Assert.IsNotNull(currentUser);
        }
    }
}
