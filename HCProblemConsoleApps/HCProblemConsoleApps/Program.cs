using HCProblemConsoleApps.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCProblemConsoleApps
{
    class Program
    {
        const string filestart = @"../../Input/";

        static void CreateOutput(string fileName)
        {
            var photobook = Photobook.FromFile(fileName);
            File.WriteAllText($"{fileName}_out.txt", photobook.DoJob2().SlideshowOUT());
        }

        static List<string> files = new List<string>()
        {
            //"a_example.txt",
            //"b_lovely_landscapes.txt",
            "c_memorable_moments.txt",
            //"d_pet_pictures.txt",
           // "e_shiny_selfies.txt"
        };

        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Enter file name: ");
            string fileName = filestart + Console.ReadLine();

            try
            {
                CreateOutput(fileName);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Done!");
                Console.ReadLine();
            }
            */

            try
            {
                foreach (var fileName in files)
                {
                    CreateOutput(filestart + fileName);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Done!");
                Console.ReadLine();
            }
        }
    }
}
