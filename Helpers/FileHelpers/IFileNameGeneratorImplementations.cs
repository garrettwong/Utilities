using System;
using System.IO;

namespace Utilities.Helpers.FileHelpers
{
    public class DefaultFileNameGenerator : IFileNameGenerator
    {
        /// <summary>
        /// Generates a full file path which looks like "C:/Application/Debug/bin/1501434826948.53_GoogleTrendsSearchResults"
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GenerateFullPathToFile(string pathToFile, string fileName)
        {
            // add fwd slash character '/' if not present
            if (!string.IsNullOrEmpty(pathToFile) &&
                pathToFile[pathToFile.Length - 1] != '/')
            {
                pathToFile += '/';
            }

            var fullPathToFile = $"{pathToFile}{fileName}";
            return fullPathToFile;
        }
    }

    public class RandomDateFileNameGenerator : IFileNameGenerator
    {
        /// <summary>
        /// Generates a full file path which looks like "C:/Application/Debug/bin/1501434826948.53_GoogleTrendsSearchResults"
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GenerateFullPathToFile(string pathToFile, string fileName)
        {
            var randomDateMsString = DateTime.Now.ToUniversalTime()
                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

            // add fwd slash character '/' if not present
            if (!string.IsNullOrEmpty(pathToFile) &&
                pathToFile[pathToFile.Length - 1] != '/')
            {
                pathToFile += '/';
            }

            var fullPathToFile = $"{pathToFile}{randomDateMsString}_{fileName}";
            return fullPathToFile;
        }
    }

    public class CurrentDateFileNameGenerator : IFileNameGenerator
    {
        /// <summary>
        /// Generates a file path which looks like "2017-07-30_1_GoogleTrendsSearchResults.txt"
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GenerateFullPathToFile(string pathToFile, string fileName)
        {
            var currentDateString = DateTime.Now.ToString("yyyy-MM-dd");

            // add fwd slash character '/' if not present
            if (!string.IsNullOrEmpty(pathToFile) &&
                pathToFile[pathToFile.Length - 1] != '/')
            {
                pathToFile += '/';
            }

            string fullPathToFile = "";

            // if the fullPathExists, we'll need to find the max runNumber
            var runNumber = 1;
            do
            {
                fullPathToFile = $"{pathToFile}{currentDateString}_{runNumber}_{fileName}";
                runNumber++;
            }
            while (File.Exists(fullPathToFile));

            return fullPathToFile;
        }
    }
}
