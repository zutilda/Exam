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
        public void conclusionFile(double res)
        {
            StreamWriter sw = new StreamWriter("Result.txt");
            sw.WriteLine(res);
            sw.Close();
        }

    }
}
