using System;
using NUnit.Framework;using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpRepository.Repository.Ioc;
using Should;

namespace SharpRepository.Tests.Ioc
{
    [TestFixture][TestClass]
    public class RepositoryDependencyResolverExceptionTests
    {
        [Test][TestMethod]
        public void DependencyType_Should_Get_Set()
        {
            var ex = new RepositoryDependencyResolverException(typeof (Int32));
            ex.DependencyType.ShouldEqual(typeof(Int32));
        }

        [Test][TestMethod]
        public void InnerException_Should_Get_Set()
        {
            var ex = new RepositoryDependencyResolverException(typeof(Int32), new ArgumentNullException());
            ex.InnerException.ShouldBeType<ArgumentNullException>();
        }
    }
}
