using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Exam
{
    public class MyClass
    {
        /// <summary>
        /// Метод записывает результат вычислений  в отдельный файл
        /// </summary>
        /// <param name="res"> результат по расчету вклада из главного метода программы</param>
        public void conclusionFile(double res)
        {
            StreamWriter sw = new StreamWriter("Result.txt");
            sw.WriteLine(res);
            sw.Close();
        }

    }
}
