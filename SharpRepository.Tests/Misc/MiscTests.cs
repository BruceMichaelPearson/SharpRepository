using SharpRepository.InMemoryRepository;
using NUnit.Framework;using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.Tests.TestObjects;
using Should;

namespace SharpRepository.Tests.Misc
{
    [TestFixture][TestClass]
    public class MiscTests
    {
        [Test][TestMethod]
        public void EntityType_Returns_Proper_Type()
        {
            var repo = new InMemoryRepository<Contact>();
            repo.EntityType.ShouldEqual(typeof(Contact));
        }

        [Test][TestMethod]
        public void KeyType_Returns_Proper_Type()
        {
            var repo = new InMemoryRepository<Contact, int>();
            repo.KeyType.ShouldEqual(typeof(int));
        }

        [Test][TestMethod]
        public void KeyType_Implied_Returns_Proper_Type()
        {
            var repo = new InMemoryRepository<Contact>();
            repo.KeyType.ShouldEqual(typeof(int));
        }
    }
}
