using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Demo_FileHandling
{
    internal class Program
    {
        static void Main(String[]args)
        {
            //creating a file using File.Create() method in default directory
            string filePath = "demo.txt";
            using (FileStream fs = File.Create(filePath))
            {
                // File created successfully
                if (File.Exists(filePath))
                {
                    Console.WriteLine("File created successfully: " + filePath);
                }
            }

            //Writing to the file using StreamWriter class
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Hello, this is a demo file created today.");
                sw.WriteLine("This file is created to demonstrate file handling in C#.");
            }
            using(StreamReader sr = new StreamReader(filePath))
            {
                string Content = sr.ReadToEnd();
                Console.WriteLine("here are the file Content:");
                Console.WriteLine(Content);
            }
            File.Delete(filePath);
            {
                Console.WriteLine("File deleted successfully:" + filePath);
            }
        }
    }
}
