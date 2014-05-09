using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.InMemoryRepository;
using SharpRepository.Repository.UnitOfWork;
using SharpRepository.Repository;
using SharpRepository.Tests.Integration.TestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRepository.Tests.Integration.UnitOfWork
{
    //[TestFixture]
    [TestClass]
    public class UnitOfWorkTests
    {
        //[Test]
        [TestMethod]
        public void UnitOfWork_Add_Entity()
        {
            Contact newContact = new Contact();
            newContact.ContactId = "FF";
            newContact.Name = "Floyd Flab";
            newContact.PhoneNumbers = new List<PhoneNumber>();
            newContact.PhoneNumbers.Add(new PhoneNumber() { Label = "Home", Number = "661-661-0000" });
            IUnitOfWork UofW = new SharpRepository.InMemoryRepository.UnitOfWork.UnitOfWork();
            UofW.AddRepository<Contact>();
            UofW.Add<Contact>(newContact);
            IRepository<Contact> repo = UofW.Repository<Contact>();
            var foundContact = repo.Find(new SharpRepository.Repository.Specifications.Specification<Contact>(c => c.ContactId == "FF"));
            Assert.AreEqual(newContact.Name, foundContact.Name);
            Assert.AreEqual(newContact.PhoneNumbers.Count(), 1);
        }
    }
}
