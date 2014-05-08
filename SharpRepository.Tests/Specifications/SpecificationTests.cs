using NUnit.Framework;using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.Repository.FetchStrategies;
using SharpRepository.Repository.Specifications;
using SharpRepository.Tests.TestObjects;
using Should;

namespace SharpRepository.Tests.Specifications
{
    [TestFixture][TestClass]
    public class SpecificationTests : TestBase
    {
        [Test][TestMethod]
        public void Specification_Will_Default_To_GenericFetchStrategy()
        {
            var spec = new Specification<Contact>(p => p.ContactId == 1);
            spec.FetchStrategy.ShouldBeType<GenericFetchStrategy<Contact>>();
        }

        [Test][TestMethod]
        public void Specification_May_Be_Chained_By_And()
        {
            var spec = new Specification<Contact>(p => p.ContactId == 1)
                .And(new Specification<Contact>(p => p.Name.Equals("test")));

            var contact = new Contact() {ContactId = 1, Name = "test"};
            spec.IsSatisfiedBy(contact).ShouldBeTrue();

            contact = new Contact() { ContactId = 2, Name = "test" };
            spec.IsSatisfiedBy(contact).ShouldBeFalse();

            contact = new Contact() { ContactId = 1, Name = "nottest" };
            spec.IsSatisfiedBy(contact).ShouldBeFalse();
        }

        [Test][TestMethod]
        public void Specification_May_Be_Chained_By_Or()
        {
            var spec = new Specification<Contact>(p => p.ContactId == 1)
                .Or(new Specification<Contact>(p => p.Name.Equals("test")));

            var contact = new Contact() { ContactId = 1, Name = "test" };
            spec.IsSatisfiedBy(contact).ShouldBeTrue();

            contact = new Contact() { ContactId = 2, Name = "test" };
            spec.IsSatisfiedBy(contact).ShouldBeTrue();

            contact = new Contact() { ContactId = 1, Name = "nottest" };
            spec.IsSatisfiedBy(contact).ShouldBeTrue();

            contact = new Contact() { ContactId = 2, Name = "nottest" };
            spec.IsSatisfiedBy(contact).ShouldBeFalse();
        }

        [Test][TestMethod]
        public void Specification_Predicate_May_Be_Updated_In_Constructor()
        {
            var spec = new ContactByNameMatchSpec("tes");
                
            var contact = new Contact() { ContactId = 1, Name = "tess" };
            spec.IsSatisfiedBy(contact).ShouldBeTrue();

            contact = new Contact() { ContactId = 2, Name = "test" };
            spec.IsSatisfiedBy(contact).ShouldBeTrue();

            contact = new Contact() { ContactId = 1, Name = "ben" };
            spec.IsSatisfiedBy(contact).ShouldBeFalse();
        }
    }

    public class ContactByNameMatchSpec : Specification<Contact>
    {
        public ContactByNameMatchSpec(string name)
            : base(p => p.Name.Contains(name))
        {
        }
    }

}