using System.Linq;
using NUnit.Framework;using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.InMemoryRepository;
using SharpRepository.Tests.TestObjects;
using Should;

namespace SharpRepository.Tests.Spikes
{
    [TestFixture][TestClass]
    public class CompoundKeySpikes
    {
        [Test][TestMethod]
        public void CompoundKeyRepository_Should_Work()
        {
            var repository = new InMemoryRepository<CompoundKeyItemInts, int, int>();

            repository.Add(new CompoundKeyItemInts { SomeId = 1, AnotherId = 1, Title = "1-1"});
            repository.Add(new CompoundKeyItemInts { SomeId = 1, AnotherId = 2, Title = "1-2"});
            repository.Add(new CompoundKeyItemInts { SomeId = 1, AnotherId = 3, Title = "1-3"});
            repository.Add(new CompoundKeyItemInts { SomeId = 2, AnotherId = 1, Title = "2-1"});
            repository.Add(new CompoundKeyItemInts { SomeId = 2, AnotherId = 2, Title = "2-2"});
            repository.Add(new CompoundKeyItemInts { SomeId = 2, AnotherId = 3, Title = "2-3"});

            repository.Get(1, 1).Title.ShouldEqual("1-1");
            repository.Get(2, 1).Title.ShouldEqual("2-1");
            repository.Get(1, 2).Title.ShouldEqual("1-2");

            repository.FindAll(x => x.SomeId == 1).Count().ShouldEqual(3);
        }

        [Test][TestMethod]
        public void CompoundKeyRepositoryNoGenerics_Should_Work()
        {
            var repository = new InMemoryCompoundKeyRepository<CompoundKeyItemInts>();

            repository.Add(new CompoundKeyItemInts { SomeId = 1, AnotherId = 1, Title = "1-1" });
            repository.Add(new CompoundKeyItemInts { SomeId = 1, AnotherId = 2, Title = "1-2" });
            repository.Add(new CompoundKeyItemInts { SomeId = 1, AnotherId = 3, Title = "1-3" });
            repository.Add(new CompoundKeyItemInts { SomeId = 2, AnotherId = 1, Title = "2-1" });
            repository.Add(new CompoundKeyItemInts { SomeId = 2, AnotherId = 2, Title = "2-2" });
            repository.Add(new CompoundKeyItemInts { SomeId = 2, AnotherId = 3, Title = "2-3" });

            repository.Get(1, 1).Title.ShouldEqual("1-1");
            repository.Get(2, 1).Title.ShouldEqual("2-1");
            repository.Get(1, 2).Title.ShouldEqual("1-2");

            repository.FindAll(x => x.SomeId == 1).Count().ShouldEqual(3);
        }
    }
}
