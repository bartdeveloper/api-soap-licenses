using API_SOAP_licenses.Tools;
using NUnit.Framework;

namespace Tests
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

            string sanitizedNip = SanitizeInput.SanitizeNIP(nip);

            Assert.AreEqual("1111111111", sanitizedNip);
        }

        [Test]
        public void SanitizeNIPWithSpace()
        {
            string nip = "111 11 11 111";

            string sanitizedNip = SanitizeInput.SanitizeNIP(nip);

            Assert.AreEqual("1111111111", sanitizedNip);
        }

        [Test]
        public void SanitizeNIPWithDashAndSpace()
        {
            string nip = "111-11 1  1 111";

            string sanitizedNip = SanitizeInput.SanitizeNIP(nip);

            Assert.AreEqual("1111111111", sanitizedNip);
        }
    }
}