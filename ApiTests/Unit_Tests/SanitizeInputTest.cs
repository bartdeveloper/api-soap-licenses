using API_SOAP_licenses.Tools;
using NUnit.Framework;

namespace ApiTests.Unit_Tests
{
    public class SanitizeInputTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SanitizeNIPWithDash()
        {
            string nip = "111-11-11-111";

            string sanitizedNip = SanitizeInput.RemoveDashAndSpace(nip);

            Assert.AreEqual("1111111111", sanitizedNip);
        }

        [Test]
        public void SanitizeNIPWithSpace()
        {
            string nip = "111 11 11 111";

            string sanitizedNip = SanitizeInput.RemoveDashAndSpace(nip);

            Assert.AreEqual("1111111111", sanitizedNip);
        }

        [Test]
        public void SanitizeNIPWithDashAndSpace()
        {
            string nip = "111-11 1  1 111";

            string sanitizedNip = SanitizeInput.RemoveDashAndSpace(nip);

            Assert.AreEqual("1111111111", sanitizedNip);
        }

        [Test]
        public void SanitizeNIPWithCorrectLength()
        {
            string nip = "111 11 11 111";

            string sanitizedNip = SanitizeInput.RemoveDashAndSpace(nip);

            Assert.AreEqual(10, sanitizedNip.Length);
        }

        [Test]
        public void SanitizeNIPWithIncorrectLength()
        {
            string nip = "111 11 11 11111";

            string sanitizedNip = SanitizeInput.RemoveDashAndSpace(nip);

            Assert.AreNotEqual(10, sanitizedNip.Length);
        }
    }
}