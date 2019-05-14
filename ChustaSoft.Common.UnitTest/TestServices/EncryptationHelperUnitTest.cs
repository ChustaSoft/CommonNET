using ChustaSoft.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    public class EncryptationHelperUnitTest
    {

        [TestMethod]
        public void Given_SingleString_When_CreateHashInvoked_Then_EncryptedHashRetrived()
        {
            var testString = "Test";

            var encryptedString = EncryptationHelper.CreateHash(testString);

            Assert.IsNotNull(encryptedString);
        }

        [TestMethod]
        public void Given_Null_When_CreateHashInvoked_Then_ArgumentNullExceptionThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => EncryptationHelper.CreateHash(null));
        }

        [TestMethod]
        public void Given_TwoString_When_CreateHashInvoked_Then_EncryptedHashRetrived()
        {
            var testString = "Test";

            var encryptedString = EncryptationHelper.CreateHash(testString, testString);

            Assert.IsNotNull(encryptedString);
        }

        [TestMethod]
        public void Given_FirstStringNull_When_CreateHashInvoked_Then_ArgumentNullExceptionThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => EncryptationHelper.CreateHash(null, string.Empty));
        }

        [TestMethod]
        public void Given_SecondStringNull_When_CreateHashInvoked_Then_ArgumentNullExceptionThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => EncryptationHelper.CreateHash(string.Empty, null));
        }

        [TestMethod]
        public void Given_NullBoth_When_CreateHashInvoked_Then_ArgumentNullExceptionThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => EncryptationHelper.CreateHash(null, null));
        }

        [TestMethod]
        public void Given_TextAndPassphrase_When_EncryptInvoked_Then_EncryptedStringRetrived()
        {
            var text = "TestText";
            var passphrase = "E546C8DF278CD5931069B522E695D4F2";

            var encryptedText = EncryptationHelper.Encrypt(text, passphrase);

            Assert.AreNotEqual(text, encryptedText);
        }

        [TestMethod]
        public void Given_PreviouslyEncryptedTextAndPassphrase_When_DecryptInvoked_Then_DecryptedStringRetrived()
        {
            var text = "TestText";
            var passphrase = Guid.NewGuid().ToString().Replace("-", "");

            var encryptedText = EncryptationHelper.Encrypt(text, passphrase);
            var decryptedText = EncryptationHelper.Decrypt(encryptedText, passphrase);

            Assert.AreEqual(text, decryptedText);
        }

    }
}
