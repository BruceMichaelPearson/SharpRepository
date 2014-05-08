using NUnit.Framework;using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.Tests.TestObjects;
using SharpRepository.InMemoryRepository;

namespace SharpRepository.Tests.Spikes
{
    [TestFixture][TestClass]
    public class LoggingSpikes : TestBase
    {
        [Test][TestMethod]
        public void Logging_Via_Aspects()
        {
            var repository = new InMemoryRepository<Contact, int>();


            var contact1 = new Contact() {Name = "Contact 1"};
            repository.Add(contact1);
            repository.Add(new Contact() { Name = "Contact 2"});
            repository.Add(new Contact() { Name = "Contact 3"});

            contact1.Name += " EDITED";
            repository.Update(contact1);

            repository.Delete(2);

            repository.FindAll(x => x.ContactId < 50);
        }
    }
}
