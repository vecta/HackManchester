using System;
using System.Linq;
using Kitbag.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kitbag.Database.Tests
{
    [TestClass]
    public class UnitTest1
    {

        private CwonData _dbContext;

        [TestInitialize]
        public void Setup()
        {
            _dbContext = new CwonData();
        }

        [TestMethod]
        public void CreatePerson()
        {
            var personRepository = new Repository<Person>(_dbContext);

            var newUser = new Person
            {
                FirstName = "Matthew",
                LastName = "Hughes",
                Email = "sdsdsd@ddssd.com"
            }; 
            personRepository.Create(newUser);

            var currentUser = personRepository.GetAll().FirstOrDefault(p => p.Email == newUser.Email);

            Assert.IsNotNull(currentUser);
        }
    }
}
