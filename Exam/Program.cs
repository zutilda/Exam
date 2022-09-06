using System;
using System.Diagnostics;
using System.IO;

namespace Exam // Note: actual namespace depends on the project name.
{
    public class Program
    {        
        private static double interestСalculation(double cash)
        {
            double money = 0;
            double procent = 0;
            while (money <= cash)
            {
                if (cash >= 700000 && cash <= 749999.99)
                {
                    procent = 0.2;
                    break;
                }

                if (money == 700000)
                {
                    procent = 0.2;
                    money += 50000;
                    continue;
                }

                if (money < 750000)
                {
                    money += 49999.99;
                    procent += 0.01;
                    money += 0.01;
                }
                else
                {
                    money += 49999.99;
                    procent -= 0.01;
                    money += 0.01;
                }
            }
            return Math.Round(procent, 2);
        }

        static void Main(string[] args)
        {
         while(true)
            {
                conclusionDebag("Начало работы программы");
                
                    MyClass obj = new MyClass();
                    obj.conclusionFile(res);
                }
                else Environment.Exit(0);
            }

        }

        /// <summary>
        /// Метод записывает информацию об отладке в файл
        /// </summary>
        /// <param name="diagnostic">строка передающаяся для записи в отладочный файл</param>
        public static void conclusionDebag(string diagnostic)
        {
            string location = Environment.CurrentDirectory;
            location = location.Insert(location.Length, "Diagnostic.txt"); // указание пути к файлу в который будет записываться отладочная информация
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