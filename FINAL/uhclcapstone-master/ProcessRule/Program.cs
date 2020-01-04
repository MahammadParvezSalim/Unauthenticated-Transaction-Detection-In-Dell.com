using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessRule
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENGINE STARTS {0} ", DateTime.Now);

            RuleEngine.Run();

            Console.WriteLine("ENGINE ENDS {0} ", DateTime.Now);

            Console.Read();
            //System.Threading.Thread.Sleep(5000);
        }
    }
}
