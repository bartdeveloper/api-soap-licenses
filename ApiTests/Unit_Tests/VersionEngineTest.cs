using API_SOAP_licenses;
using API_SOAP_licenses.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using API_SOAP_licenses.Core;

namespace ApiTests.Unit_Tests
{
    class VersionEngineTest
    {
        [Test]
        public void shouldReturnLastNumberOfVersion()
        {

            IQueryable<version> versions = 
                new List<version>
                {
                    new version { ver_id = 1, ver_name = "Start", ver_version = "1.0" },
                    new version { ver_id = 2, ver_name = "Update 1", ver_version = "1.1" },
                    new version { ver_id = 3, ver_name = "Update 2", ver_version = "1.2" }
                }.AsQueryable();

            IDbSet<version> versionDbSet = Substitute.For<IDbSet<version>>();
            versionDbSet.Provider.Returns(versions.Provider);
            versionDbSet.Expression.Returns(versions.Expression);
            versionDbSet.ElementType.Returns(versions.ElementType);
            versionDbSet.GetEnumerator().Returns(versions.GetEnumerator());

            IRepositoryContext repositoryContext = Substitute.For<IRepositoryContext>();
            repositoryContext.versions.Returns(versionDbSet);


            var versionEngine = new VersionEngine(repositoryContext);

            VersionItem versionItem = versionEngine.GetNewestVersion();


            Assert.AreNotEqual("-1", versionItem.Version);
            Assert.AreEqual("1.2", versionItem.Version);
            
        }
    }
}
