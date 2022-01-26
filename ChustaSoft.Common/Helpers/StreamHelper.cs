using System.Collections;
using System.IO;
using System.IO.Compression;

namespace ChustaSoft.Common.Helpers
{
    public static class StreamHelper
    {

        /// <summary>
        /// Compress an array of bytes
        /// </summary>
        /// <param name="bytes">Original bytes array</param>
        /// <returns>Compressed bytes array</returns>
        public static byte[] Compress(this byte[] bytes) 
        {
            using (var stream = new MemoryStream()) 
            {
                using (var gzs = new GZipStream(stream, CompressionMode.Compress))
                { 
                    gzs.Write(bytes, 0, bytes.Length);                
                }

                byte[] result = stream.ToArray();

                return result;
            }
        }

        /// <summary>
        /// Decompress a previously compressed array of bytes
        /// </summary>
        /// <param name="bytes">Original compressed array of bytes</param>
        /// <returns>Decompressed array of bytes resultant</returns>
        public static byte[] Decompress(this byte[] bytes) 
        {
            using (var compressedStream = new MemoryStream(bytes)) 
            {
                using (var decompressedStream = new MemoryStream()) 
                {
                    using (var gzs = new GZipStream(compressedStream, CompressionMode.Decompress))
                    {
                        gzs.CopyTo(decompressedStream);                        
                    }

                    var result = decompressedStream.ToArray();

                    return result;
                }
            }
        }

        /// <summary>
        /// Determines if two array of bytes are equals or not, using System StructuralComparisons
        /// <seealso cref="StructuralComparisons.StructuralEqualityComparer"/>
        /// </summary>
        /// <param name="bytes1">One of the array of bytes to compare</param>
        /// <param name="bytes2">The other array of bytes to compare</param>
        /// <returns>True if are equals, false otherwise</returns>
        public static bool AreEquals(byte[] bytes1, byte[] bytes2) 
        {
            return StructuralComparisons.StructuralEqualityComparer.Equals(bytes1, bytes2);
        }

    }
}
