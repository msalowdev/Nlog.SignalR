using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = LogManager.GetLogger("Test");

            logger.Trace("This is a trace");
            logger.Error("Error");
            logger.Fatal("This is Fatal");
            Console.ReadLine();
        }
    }
}
