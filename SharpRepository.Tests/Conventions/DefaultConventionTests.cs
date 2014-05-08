using NUnit.Framework;using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.Repository;
using SharpRepository.Repository.Caching;
using SharpRepository.Tests.TestObjects;
using Should;

namespace SharpRepository.Tests.Conventions
{
    [TestFixture][TestClass]
    public class RepositoryConventionTests
    {
        [Test][TestMethod]
        public void Default_PrimaryKeySuffix_Is_Id()
        {
            DefaultRepositoryConventions.PrimaryKeySuffix.ShouldEqual("Id");
        }

        [Test][TestMethod]
        public void RepositoryConventions_Uses_Default_PrimaryKeySuffix()
        {
            DefaultRepositoryConventions.PrimaryKeySuffix = "Key";
            DefaultRepositoryConventions.GetPrimaryKeyName(typeof (Contact)).ShouldBeNull();

            // change back to default for the rest of the tests
            DefaultRepositoryConventions.PrimaryKeySuffix = "Id";
        }

        [Test][TestMethod]
        public void Default_PrimaryKeyName()
        {
            DefaultRepositoryConventions.GetPrimaryKeyName(typeof (Contact)).ShouldEqual("ContactId");
        }

        [Test][TestMethod]
        public void Change_PrimaryKeyName()
        {
            var orig = DefaultRepositoryConventions.GetPrimaryKeyName;

            DefaultRepositoryConventions.GetPrimaryKeyName = type => "PK_" + type.Name + "_Id";

            DefaultRepositoryConventions.GetPrimaryKeyName(typeof(TestConventionObject)).ShouldEqual("PK_TestConventionObject_Id");

            DefaultRepositoryConventions.GetPrimaryKeyName = orig;
        }

        [Test][TestMethod]
        public void Default_CachePrefix()
        {
            var repos = new InMemoryRepository.InMemoryRepository<Contact>(new StandardCachingStrategy<Contact, int>());
            repos.CachingStrategy.FullCachePrefix.ShouldStartWith(DefaultRepositoryConventions.CachePrefix);
        }

        [Test][TestMethod]
        public void Change_CachePrefix()
        {
            const string newPrefix = "TestPrefix123";
            DefaultRepositoryConventions.CachePrefix = newPrefix;

            var repos = new InMemoryRepository.InMemoryRepository<Contact>(new StandardCachingStrategy<Contact, int>());
            repos.CachingStrategy.FullCachePrefix.ShouldStartWith(newPrefix);
        }

        internal class TestConventionObject
        {
            public int PK_TestConventionObject_Id { get; set; }
            public string Name { get; set; }
        }
    }

    
}
