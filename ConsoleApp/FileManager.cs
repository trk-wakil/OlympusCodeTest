using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace ConsoleApp
{

    /// <summary>
    /// This class will manage file operations
    /// </summary>

    public class FileManager
    {

        private readonly string _filePath;
        private readonly object _lockObj;

        /// <summary>
        /// The constructor will initialize the file path, the lock object,
        /// and it will make sure the file exists in the required path
        /// </summary>
        public FileManager()
        {
            _filePath = Path.Combine(Environment.CurrentDirectory, @"log/out.txt");
            _lockObj = new object();

            CraeteDirectory();
            InitFile();
        }



        /// <summary>
        /// Add a new line with the given number to the file
        /// </summary>
        /// <param name="number"></param>
        public void AddNewLine(int number)
        {
            Monitor.Enter(_lockObj);
            try
            {
                var lastLine = File.ReadLines(_filePath).Last();
                var currentCounter = int.Parse(lastLine.Split(',')[0]);                
                var newLine = $"{++currentCounter}, {number},  {DateTime.Now:HH:MM:ss.mmm}";
                File.AppendAllText(_filePath, newLine + Environment.NewLine);                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error caused for   {number}:  {ex.Message}");
            }
            finally
            {
                Monitor.Exit(_lockObj);
            }
        }



        /// <summary>
        /// Initialize the file with the first line
        /// </summary>
        private void InitFile()
        {
            try
            {
                if (File.Exists(_filePath)) File.Delete(_filePath);

                var firstLine = $"0, 0,  {DateTime.Now:HH:MM:ss.mmmmm}";
                File.AppendAllText(_filePath, firstLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create init file due to error:  {ex.Message}");
            }
        }


        /// <summary>
        /// Create the Directory if it does not already exists
        /// </summary>
        private void CraeteDirectory()
        {
            try
            {
                var dirName = new FileInfo(_filePath).DirectoryName;
                if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create directory due to error:  {ex.Message}");
            }
        }



    }
}
