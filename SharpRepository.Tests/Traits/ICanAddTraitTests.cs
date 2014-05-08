using System;
using System.Collections.Generic;
using NUnit.Framework;using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.Repository;
using SharpRepository.Repository.Traits;
using SharpRepository.Tests.TestObjects;
using Should;
using SharpRepository.InMemoryRepository;

namespace SharpRepository.Tests.Traits
{
    [TestFixture][TestClass]
    public class ICanAddTraitTests : TestBase
    {
        [Test][TestMethod]
        public void ICanAdd_Exposes_Add_Entity()
        {
            var repo = new ContactRepository();
            repo.Add(new Contact());
        }

        [Test][TestMethod]
        public void ICanAdd_Exposes_Add_Multiple_Entities()
        {
            var repo = new ContactRepository();
            repo.Add(new List<Contact> { new Contact(), new Contact() });
        }

        private class ContactRepository : InMemoryRepository<Contact, int>, IContactRepository
        {
         
        }

        private interface IContactRepository : ICanAdd<Contact>
        {

        }
    }
}