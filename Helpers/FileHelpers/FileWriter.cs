using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Utilities.Helpers.FileHelpers
{
    public class FileWriter
    {
        /// <summary>
        /// By default, this will reference AppDomain.CurrentDomain.BaseDirectory, which references the bin/Debug path of the project
        /// </summary>
        private string _baseDirectory;
        private string _domain;
        private string _username;
        private string _password;
        private IFileNameGenerator _fileNameGenerator;

        // Constructors
        public FileWriter()
        {
            _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _fileNameGenerator = new DefaultFileNameGenerator();
        }
        /// <summary>
        /// Overrides the built in DefaultFileNameGenerator with a custom implementation
        /// </summary>
        /// <param name="fileNameGenerator">
        ///     new DefaultFileNameGenerator(), 
        ///     new RandomDateFileNameGenerator(),
        ///     new CurrentDateFileNameGenerator()
        /// </param>
        public FileWriter(IFileNameGenerator fileNameGenerator)
            :this()
        {
            _fileNameGenerator = fileNameGenerator;
        }
        public FileWriter(string domain, string username, string password)
            : this()
        {
            _domain = domain;
            _username = username;
            _password = password;
        }
        public FileWriter(string domain, string username, string password, IFileNameGenerator fileNameGenerator)
            : this(domain, username, password)
        {
            _fileNameGenerator = fileNameGenerator;
        }
        public FileWriter(string baseDirectory, string domain, string username, string password)
            : this(domain, username, password)
        {
            _baseDirectory = baseDirectory;
        }
        public FileWriter(string baseDirectory, string domain, string username, string password, IFileNameGenerator fileNameGenerator)
            : this(baseDirectory, domain, username, password)
        {
            _fileNameGenerator = fileNameGenerator;
        }
        // End Constructors



        // Methods
        public void WriteToFile(string fileName, string logContent)
        {
            WriteToFile(fileName, new string[] { logContent });
        }
        public void WriteToFile(string fileName, List<string> logContents)
        {
            WriteToFile(fileName, logContents.ToArray());
        }

        // Write To File Method 
        public void WriteToFile(string fileName, string[] logContents)
        {
            Impersonation impersonationContext = null;

            try
            {
                impersonationContext = new Impersonation(_domain, _username, _password);
            }
            catch (Exception) { }
            finally
            {
                var fullPathToFile = _fileNameGenerator.GenerateFullPathToFile(_baseDirectory, fileName);

                _writeToFile(fullPathToFile, logContents);

                if (impersonationContext != null) impersonationContext.Dispose();
            }
        }
        private void _writeToFile(string fullPathToFile, string[] logContents)
        {
            var sb = new StringBuilder();

            foreach (var s in logContents)
            {
                sb.AppendLine(s);
            }

            File.WriteAllText(fullPathToFile, sb.ToString());
        }
    }
}
