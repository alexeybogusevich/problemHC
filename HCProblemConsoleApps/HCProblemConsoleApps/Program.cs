using HCProblemConsoleApps.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCProblemConsoleApps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file name: ");
            string fileName = Console.ReadLine();

            try
            {
                var photobook = Photobook.FromFile(fileName);
                Console.WriteLine("Photobook created!\n{0}", photobook.ToString());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
