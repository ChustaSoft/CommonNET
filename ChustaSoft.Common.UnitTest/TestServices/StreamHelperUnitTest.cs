using ChustaSoft.Common.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace ChustaSoft.Common.UnitTest.TestServices
{
    [TestClass]
    public class StreamHelperUnitTest
    {

        [TestMethod]
        public void Given_StreamFromString_When_Compress_Then_StreamCompressedRetrived() 
        {
            var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var stream = Encoding.UTF8.GetBytes(text);

            var result = stream.Compress();

            Assert.IsTrue(stream.Length > result.Length);
        }

        [TestMethod]
        public void Given_StreamCompressed_When_Decompress_Then_StreamDecompressedRetrived()
        {
            var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var stream = Encoding.UTF8.GetBytes(text);
            var streamCompressed = stream.Compress();

            var result = streamCompressed.Decompress();
            
            Assert.IsTrue(StreamHelper.AreEquals(stream, result));
        }

        [TestMethod]
        public void Given_TwoSameStreams_When_AreEquals_Then_TrueRetrived()
        {
            var text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var stream1 = Encoding.UTF8.GetBytes(text);
            var stream2 = Encoding.UTF8.GetBytes(text);

            var result = StreamHelper.AreEquals(stream1, stream2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Given_TwoDifferentStreams_When_AreEquals_Then_FalseRetrived()
        {
            var text1 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ";
            var text2 = "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            var stream1 = Encoding.UTF8.GetBytes(text1);
            var stream2 = Encoding.UTF8.GetBytes(text2);

            var result = StreamHelper.AreEquals(stream1, stream2);

            Assert.IsFalse(result);
        }
    }
}
