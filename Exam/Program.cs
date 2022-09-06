using System;
using System.Diagnostics;
using System.IO;

namespace Exam // Note: actual namespace depends on the project name.
{
    public class Program
    {
        double betBank = 0.08;

       

        static void Main(string[] args)
        {
         while(true)
            {

                conclusionDebag("Начало работы программы");
                Console.Write("Хотите начать работу программы? Введите 'да' или 'нет' (ввод чувствителен к регистру):");
                string answer = Console.ReadLine();
                if (answer=="да")
                {
                   
                }
                else Environment.Exit(0);
            }

        }

        public static void conclusionDebag(string diagnostic)
        {
            string location = Environment.CurrentDirectory;
            location = location.Insert(location.Length, "Diagnostic.txt");
            FileStream file = new FileStream(location, FileMode.Create);
            file.Close();
            TextWriterTraceListener tr = new TextWriterTraceListener(File.AppendText("Diagnostic.txt"));
            Trace.Listeners.Add(tr);
            Debug.WriteLine(diagnostic);
            Debug.Flush();
            tr.Close();
        }

       
    }
}