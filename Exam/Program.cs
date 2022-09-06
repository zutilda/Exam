using System;
using System.Diagnostics;
using System.IO;

namespace Exam // Note: actual namespace depends on the project name.
{
    public class Program
    {
        /// <summary>
        /// Метод для рассчета процентов
        /// </summary>
        /// <param name="cash">сумма вклада</param>
        /// <returns>результат подсчета ставки</returns>
        public static double interestСalculation(double cash)
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
        /// <summary>
        /// Метод для начисления процентов по вкладу
        /// </summary>
        /// <param name="cash"> сумма вклада</param>
        /// <param name="procent">процентная ставка</param>
        /// <param name="years">временной промежуток за который будут начисляться проценты</param>
        /// <returns></returns>
        public static double interestAccrual(double cash, double procent, int years) // метод 
        {
            double betBank = 0.08;
            for (int i = 1; i <= years * 12; i++)
            {
                if (i % 3 == 0)
                {
                    procent += 0.005;
                }

                if (procent - betBank > 5)
                {
                    cash += cash * procent * 0.7;
                }
                else
                {
                    cash += cash * procent;
                }
            }
            return Math.Round(cash, 2);
        }

        public static double calculationMax() // метод для подсчета максимального дохода за год
        {
            double max = 0;
            double maxMoney = 0;
            double money = 0;
            double procent;
            while (money <= 1000000)
            {
                procent = interestСalculation(money);
                if (interestAccrual(money, procent, 1) > max)
                {
                    max = interestAccrual(money, procent, 1);
                    maxMoney = money;
                }
                money = money + 1;
            }
            return Math.Round(maxMoney, 2);
        }


        static void Main(string[] args)
        {
         while(true) // цикл для диалога с пользователем
            {
                conclusionDebag("Начало работы программы");
                Console.Write("Хотите начать рассчет вклада? Введите 'да' или 'нет' (ввод чувствителен к регистру):");
                string answer = Console.ReadLine();
                if (answer == "да")
                {
                    Console.Write("Введите сумму вклада: ");
                    double cash = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Количество лет: ");
                    int years = Convert.ToInt32(Console.ReadLine());
                    double procent = interestСalculation(cash);
                    Console.WriteLine("Первоначальный вклад: {0:f2} руб.", Math.Round(cash, 2));
                    Console.WriteLine("Процент: {0:0}%", procent * 100);
                    if (years % 10 == 1) // циклы для вывода суммы полученной по вкладу в зависимости от количества лет
                    {
                        Console.WriteLine("Сумма на счету через {0} год: {1} руб.", years, interestAccrual(cash, procent, years));
                    }
                    else if (years % 10 == 2 || years % 10 == 3 || years % 10 == 4)
                    {
                        Console.WriteLine("Сумма на счету через {0} года: {1} руб.", years, interestAccrual(cash, procent, years));
                    }
                    else
                    {
                        Console.WriteLine("Сумма на счету через {0} лет: {1} руб.", years, interestAccrual(cash, procent, years));
                    }                   
                    Console.WriteLine("Для получения максимального дохода через 1 год необходимо вложить следующую сумму: {0:f2} руб.", calculationMax());
                    conclusionDebag("Рассчет максимального дохода за год");
                    double res = calculationMax();                     
                    MyClass obj = new MyClass();
                    obj.conclusionFile(res);
                    conclusionDebag("Запись ответа в файл");
                }
                else Environment.Exit(0); // осуществление выхода из программы
                Debug.WriteLine("Завершение работы программы");
            }

        }

        /// <summary>
        /// Метод записывает информацию об отладке в файл
        /// </summary>
        /// <param name="diagnostic">строка передающаяся для записи в отладочный файл</param>
        public static void conclusionDebag(string diagnostic)
        {
         
            TextWriterTraceListener tr = new TextWriterTraceListener(File.AppendText("Diagnostic.txt"));
            Trace.Listeners.Add(tr);
            Debug.WriteLine(diagnostic);
            Debug.Flush();
            tr.Close();
        }

       
    }
}