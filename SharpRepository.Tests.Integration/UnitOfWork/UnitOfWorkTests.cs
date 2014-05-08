using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.InMemoryRepository;
using SharpRepository.Repository.UnitOfWork;
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
            Contact contact = new Contact();
            contact.ContactId = "FF";
            contact.Name = "Floyd Flab";
            contact.PhoneNumbers.Add(new PhoneNumber() { Label = "Home", Number = "661-661-0000" });
            IUnitOfWork UofW = new SharpRepository.InMemoryRepository.UnitOfWork.UnitOfWork();
            UofW.AddRepository<Contact>();
            UofW.Add<Contact>(contact);

        }
    }
}
