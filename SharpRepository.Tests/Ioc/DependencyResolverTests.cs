using System;
using NUnit.Framework;using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.Repository.Ioc;

namespace SharpRepository.Tests.Ioc
{
    [TestFixture][TestClass]
    public class DependencyResolverTests
    {
        [Test][TestMethod]
        public void No_Ioc_Configuration_Should_Throw_Exception()
        {
            try
            {
                new TestDependencyResolver().Resolve<ISomeFakeInterface>();

                NUnit.Framework.Assert.Fail(); // exception was not throws
            }
            catch (RepositoryDependencyResolverException)
            {
                // ignore
            }
            catch (Exception)
            {
                NUnit.Framework.Assert.Fail();
            }
            
        }
    }


    public class TestDependencyResolver : BaseRepositoryDependencyResolver
    {
        protected override T ResolveInstance<T>()
        {
            throw new NotImplementedException();
        }

        protected override object ResolveInstance(Type type)
        {
            throw new NotImplementedException();
        }
    }

    public interface ISomeFakeInterface
    {
    }
}
