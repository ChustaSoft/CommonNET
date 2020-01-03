using ChustaSoft.Common.Exceptions;
using ChustaSoft.Common.Helpers;
using ChustaSoft.Common.UnitTest.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Security.Authentication;

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
        public void Given_SingleStringAndMD5AlgorithType_When_CreateHashInvoked_Then_32BitsEncryptedHashRetrived()
        {
            var testString = "Test";

            var encryptedString = EncryptationHelper.CreateHash(testString, HashAlgorithmType.Md5);

            Assert.IsNotNull(encryptedString);
            Assert.AreEqual(encryptedString.Length, 32);
        }

        [TestMethod]
        public void Given_SingleStringAndNoneAlgorithType_When_CreateHashInvoked_Then_UnsupportedAlgorithmExceptionThrown()
        {
            Assert.ThrowsException<UnsupportedAlgorithmException>(() => EncryptationHelper.CreateHash("Test", HashAlgorithmType.None));
        }

        [TestMethod]
        public void Given_SingleStringAndSha1AlgorithType_When_CreateHashInvoked_Then_UnsupportedAlgorithmExceptionThrown()
        {
            Assert.ThrowsException<UnsupportedAlgorithmException>(() => EncryptationHelper.CreateHash("Test", HashAlgorithmType.Sha1));
        }

        [TestMethod]
        public void Given_SingleStringAndSha256AlgorithType_When_CreateHashInvoked_Then_UnsupportedAlgorithmExceptionThrown()
        {
            Assert.ThrowsException<UnsupportedAlgorithmException>(() => EncryptationHelper.CreateHash("Test", HashAlgorithmType.Sha256));
        }

        [TestMethod]
        public void Given_SingleStringAndSha384AlgorithType_When_CreateHashInvoked_Then_UnsupportedAlgorithmExceptionThrown()
        {
            Assert.ThrowsException<UnsupportedAlgorithmException>(() => EncryptationHelper.CreateHash("Test", HashAlgorithmType.Sha384));
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
        public void Given_TwoStringAndMD5AlgorithType_When_CreateHashInvoked_Then_EncryptedHashRetrived()
        {
            var testString = "Test";

            var encryptedString = EncryptationHelper.CreateHash(testString, testString, HashAlgorithmType.Md5);

            Assert.IsNotNull(encryptedString);
            Assert.AreEqual(encryptedString.Length, 32);
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
        public void Given_TwoStringAndNoneAlgorithType_When_CreateHashInvoked_Then_UnsupportedAlgorithmExceptionThrown()
        {
            Assert.ThrowsException<UnsupportedAlgorithmException>(() => EncryptationHelper.CreateHash("Test", "Test2", HashAlgorithmType.None));
        }

        [TestMethod]
        public void Given_TwoStringAndSha1AlgorithType_When_CreateHashInvoked_Then_UnsupportedAlgorithmExceptionThrown()
        {
            Assert.ThrowsException<UnsupportedAlgorithmException>(() => EncryptationHelper.CreateHash("Test", "Test2", HashAlgorithmType.Sha1));
        }

        [TestMethod]
        public void Given_TwoStringAndSha256AlgorithType_When_CreateHashInvoked_Then_UnsupportedAlgorithmExceptionThrown()
        {
            Assert.ThrowsException<UnsupportedAlgorithmException>(() => EncryptationHelper.CreateHash("Test", "Test2", HashAlgorithmType.Sha256));
        }

        [TestMethod]
        public void Given_TwoStringAndSha384AlgorithType_When_CreateHashInvoked_Then_UnsupportedAlgorithmExceptionThrown()
        {
            Assert.ThrowsException<UnsupportedAlgorithmException>(() => EncryptationHelper.CreateHash("Test", "Test2", HashAlgorithmType.Sha384));
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
        public void Given_TextAndRandomPassphrase_When_EncryptInvoked_Then_EncryptedStringRetrived()
        {
            var text = "TestText";
            var passphrase = "123158624fkvld9oejkd0cks84jd83s6asdasdasdasd";

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

        [TestMethod]
        public void Given_JsonObjectForSerialize_When_EncryptInvoked_Then_EncryptedStringRetrived()
        {
            var testClass = new TestClass { TestInt = 7, KnownDescription = "Desc", UnknownDescription = "Udesc" };
            var passphrase = Guid.NewGuid().ToString().Replace("-", "");
            var jsonClass = JsonConvert.SerializeObject(testClass);

            var encryptedText = EncryptationHelper.Encrypt(jsonClass, passphrase);

            Assert.IsFalse(string.IsNullOrEmpty(encryptedText));
        }

        [TestMethod]
        public void Given_JsonStringForDeserialize_When_DecryptInvoked_Then_ObjectCouldBeRetrivedAfter()
        {
            var testClass = new TestClass { TestInt = 7, KnownDescription = "Desc", UnknownDescription = "Udesc" };
            var passphrase = Guid.NewGuid().ToString().Replace("-", "");
            var jsonClass = JsonConvert.SerializeObject(testClass);
            var encryptedText = EncryptationHelper.Encrypt(jsonClass, passphrase);
            var decryptedString = EncryptationHelper.Decrypt(encryptedText, passphrase);
            var decryptedClass = JsonConvert.DeserializeObject<TestClass>(decryptedString);

            Assert.AreEqual(testClass.TestInt, decryptedClass.TestInt);
            Assert.AreEqual(testClass.KnownDescription, decryptedClass.KnownDescription);
            Assert.AreEqual(testClass.UnknownDescription, decryptedClass.UnknownDescription);
        }

        [TestMethod]
        public void Given_JsonStringForDeserializeWithRandomKey_When_DecryptInvoked_Then_ObjectCouldBeRetrivedAfter()
        {
            var testClass = new TestClass { TestInt = 7, KnownDescription = "Desc", UnknownDescription = "Udesc" };
            var passphrase = "TestRandomKey_ForTestingPurpose_ShouldWorkAtAnyCase=000=";
            var jsonClass = JsonConvert.SerializeObject(testClass);
            var encryptedText = EncryptationHelper.Encrypt(jsonClass, passphrase);
            var decryptedString = EncryptationHelper.Decrypt(encryptedText, passphrase);
            var decryptedClass = JsonConvert.DeserializeObject<TestClass>(decryptedString);

            Assert.AreEqual(testClass.TestInt, decryptedClass.TestInt);
            Assert.AreEqual(testClass.KnownDescription, decryptedClass.KnownDescription);
            Assert.AreEqual(testClass.UnknownDescription, decryptedClass.UnknownDescription);
        }

    }
}
