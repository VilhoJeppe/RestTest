using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new ServiceReference1.Service1Client();

            var list = new List<int> { 1, 2, 3, 4, 5 };

            Parallel.For(0, 1000, i => obj.GetData(i));
            //for (int i = 0; i < 5; i++)
            //{
            //    obj.GetData(i);
            //    //Thread.Sleep(2000);
            //}

            Console.WriteLine(obj.GetData(222222));
            Console.ReadKey();
        }
    }
}
