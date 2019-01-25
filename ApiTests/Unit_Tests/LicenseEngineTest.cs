using API_SOAP_licenses;
using API_SOAP_licenses.Core;
using API_SOAP_licenses.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.Unit_Tests
{
    class LicenseEngineTest
    {
        [Test]
        public void shouldReturnValidLicense()
        {

            IQueryable<license> licenses =
                new List<license>
                {
                    new license { lic_id = 1, lic_cmpid = 1, lic_valid = true}
                }.AsQueryable();

            IDbSet<license> licenseDbSet = Substitute.For<IDbSet<license>>();
            licenseDbSet.Provider.Returns(licenses.Provider);
            licenseDbSet.Expression.Returns(licenses.Expression);
            licenseDbSet.ElementType.Returns(licenses.ElementType);
            licenseDbSet.GetEnumerator().Returns(licenses.GetEnumerator());

            IQueryable<company> companies =
                new List<company>
                {
                    new company { cmp_id = 1, cmp_name = "Company", cmp_nip = "2222222222"}
                }.AsQueryable();

            IDbSet<company> companyDbSet = Substitute.For<IDbSet<company>>();
            companyDbSet.Provider.Returns(companies.Provider);
            companyDbSet.Expression.Returns(companies.Expression);
            companyDbSet.ElementType.Returns(companies.ElementType);
            companyDbSet.GetEnumerator().Returns(companies.GetEnumerator());

            IRepositoryContext repositoryContext = Substitute.For<IRepositoryContext>();
            repositoryContext.licenses.Returns(licenseDbSet);
            repositoryContext.companies.Returns(companyDbSet);

            string nip = "222 22 22 222";


            var licenseEngine = new LicenseEngine(repositoryContext);

            bool isValidLicense = licenseEngine.CheckValidityLicenseByNip(nip);


            Assert.IsTrue(isValidLicense);

        }

        [Test]
        public void shouldReturnInvalidLicense()
        {

            IQueryable<license> licenses =
                new List<license>
                {
                    new license { lic_id = 1, lic_cmpid = 1, lic_valid = true}
                }.AsQueryable();

            IDbSet<license> licenseDbSet = Substitute.For<IDbSet<license>>();
            licenseDbSet.Provider.Returns(licenses.Provider);
            licenseDbSet.Expression.Returns(licenses.Expression);
            licenseDbSet.ElementType.Returns(licenses.ElementType);
            licenseDbSet.GetEnumerator().Returns(licenses.GetEnumerator());

            IQueryable<company> companies =
                new List<company>
                {
                    new company { cmp_id = 1, cmp_name = "Company", cmp_nip = "2222222222"}
                }.AsQueryable();

            IDbSet<company> companyDbSet = Substitute.For<IDbSet<company>>();
            companyDbSet.Provider.Returns(companies.Provider);
            companyDbSet.Expression.Returns(companies.Expression);
            companyDbSet.ElementType.Returns(companies.ElementType);
            companyDbSet.GetEnumerator().Returns(companies.GetEnumerator());

            IRepositoryContext repositoryContext = Substitute.For<IRepositoryContext>();
            repositoryContext.licenses.Returns(licenseDbSet);
            repositoryContext.companies.Returns(companyDbSet);

            string nip = "333 22 22 222";


            var licenseEngine = new LicenseEngine(repositoryContext);

            bool isValidLicense = licenseEngine.CheckValidityLicenseByNip(nip);


            Assert.IsFalse(isValidLicense);

        }
    }
}
