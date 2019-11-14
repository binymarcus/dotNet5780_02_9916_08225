using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNet5780_02_9916_08225.Properties;
namespace dotNet5780_02_9916_08225
{
    class Program
    {
        static void Main(string[] args)
        {
            GuestRequest guesty = new GuestRequest();
            Console.WriteLine(guesty.ToString());
            Console.Read();
            
        }
    }
}
