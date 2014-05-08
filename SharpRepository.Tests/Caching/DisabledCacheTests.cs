using NUnit.Framework;using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.InMemoryRepository;
using SharpRepository.Repository.Caching;
using SharpRepository.Tests.TestObjects;
using Should;

namespace SharpRepository.Tests.Caching
{
    [TestFixture][TestClass]
    public class DisabledCacheTests
    {
        [Test][TestMethod]
        public void Using_DisableCaching_Should_Disable_Cache_Inside_Using_Block()
        {
            var repos = new InMemoryRepository<Contact>(new StandardCachingStrategy<Contact>());

            repos.CachingEnabled.ShouldBeTrue();

            using (repos.DisableCaching())
            {
                repos.CachingEnabled.ShouldBeFalse();
            }

            repos.CachingEnabled.ShouldBeTrue();
        }
    }
}
