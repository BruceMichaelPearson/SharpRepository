using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using SharpRepository.Tests.TestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpRepository.Repository.UnitOfWork;
using SharpRepository.InMemoryRepository;

namespace SharpRepository.Tests.UnitOfWork
{
    [TestFixture][TestClass]
    public class UnitOfWorkTests
    {
        [Test][TestMethod]
        public void UnitOfWork_Add_Entity()
        {
            Contact contact = new Contact();
            contact.ContactId = 1;
            contact.Name = "Floyd Flab";
            contact.PhoneNumbers.Add(new PhoneNumber() { Label = "Home", Number = "661-661-0000" });
            IUnitOfWork UofW = new SharpRepository.InMemoryRepository.UnitOfWork.UnitOfWork();
        }
    }
}
