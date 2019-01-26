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
            IDbSet<license> licenseDbSet = getLicenseDbSet();
            IDbSet<company> companyDbSet = getCompanyDbSet();

            IRepositoryContext repositoryContext = Substitute.For<IRepositoryContext>();
            repositoryContext.Licenses.Returns(licenseDbSet);
            repositoryContext.Companies.Returns(companyDbSet);

            string nip = "222 22 22 222";
            var licenseEngine = new LicenseEngine(repositoryContext);


            bool isValidLicense = licenseEngine.CheckValidityLicenseByNip(nip);


            Assert.IsTrue(isValidLicense);
        }

        [Test]
        public void shouldReturnInvalidLicense()
        {
            IDbSet<license> licenseDbSet = getLicenseDbSet();
            IDbSet<company> companyDbSet = getCompanyDbSet();

            IRepositoryContext repositoryContext = Substitute.For<IRepositoryContext>();
            repositoryContext.Licenses.Returns(licenseDbSet);
            repositoryContext.Companies.Returns(companyDbSet);

            string nip = "333 22 22 222";
            var licenseEngine = new LicenseEngine(repositoryContext);


            bool isValidLicense = licenseEngine.CheckValidityLicenseByNip(nip);


            Assert.IsFalse(isValidLicense); ;
        }

        IDbSet<license> getLicenseDbSet()
        {
            IQueryable<license> licenses = getLicenses();

            IDbSet<license> licenseDbSet = Substitute.For<IDbSet<license>>();
            licenseDbSet.Provider.Returns(licenses.Provider);
            licenseDbSet.Expression.Returns(licenses.Expression);
            licenseDbSet.ElementType.Returns(licenses.ElementType);
            licenseDbSet.GetEnumerator().Returns(licenses.GetEnumerator());

            return licenseDbSet;
        }

        IQueryable<license> getLicenses()
        {
            IQueryable<license> licenses =
                new List<license>
                {
                    new license { lic_id = 1, lic_cmpid = 1, lic_valid = true}
                }.AsQueryable();

            return licenses;
        }

        IDbSet<company> getCompanyDbSet()
        {
            IQueryable<company> companies = getCompanies();

            IDbSet<company> companyDbSet = Substitute.For<IDbSet<company>>();
            companyDbSet.Provider.Returns(companies.Provider);
            companyDbSet.Expression.Returns(companies.Expression);
            companyDbSet.ElementType.Returns(companies.ElementType);
            companyDbSet.GetEnumerator().Returns(companies.GetEnumerator());

            return companyDbSet;
        }
        IQueryable<company> getCompanies()
        {
            IQueryable<company> companies =
                new List<company>
                {
                    new company { cmp_id = 1, cmp_name = "Company", cmp_nip = "2222222222"}
                }.AsQueryable();

            return companies;
        }

    }
}
