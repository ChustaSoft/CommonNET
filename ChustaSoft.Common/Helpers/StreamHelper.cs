﻿using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ChustaSoft.Common.Helpers
{
    public static class StreamHelper
    {

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
        /// Convert a string in a compressed array of bytes
        /// </summary>
        /// <param name="text">Text to convert</param>
        /// <returns>Array of bytes converted</returns>
        public static byte[] ToCompressedArray(this string text)
        {
            var compressedStream = Encoding.UTF8.GetBytes(text);

            return compressedStream.Compress();
        }

        /// <summary>
        /// Recover a previously compressed string as an array of bytes
        /// </summary>
        /// <param name="bytes">Compressed string into array of bytes</param>
        /// <returns>String recovered</returns>
        public static string ToDecompressedString(this byte[] bytes) 
        {
            var decompressedString = bytes.Decompress();

            return Encoding.UTF8.GetString(decompressedString);
        }

        /// <summary>
        /// Extension method to retrieve a file embedded from an assembly
        /// </summary>
        /// <param name="assembly">The assembly from we want to extract a resource as stream</param>
        /// <param name="fileName">The filename incuding extension to retrieve</param>
        /// <param name="folderName">The folderName, by default it will look in a Resources folder</param>
        /// <returns></returns>
        public static Stream GetEmbeddedResource(this System.Reflection.Assembly assembly, string fileName, string folderName = "Resources")
        {
            var resourceStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{folderName}.{fileName}");

            return resourceStream;
        }

        /// <summary>
        /// Converts an stream to plain text string
        /// </summary>
        /// <param name="stream">Stream to be translated</param>
        /// <returns>Text</returns>
        public static string AsString(this Stream stream) 
        {
            var reader = new StreamReader(stream);
            var streamText = reader.ReadToEnd();

            return streamText;
        }

    }
}
