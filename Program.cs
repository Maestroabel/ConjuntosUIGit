using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loqueseaqui
{
    class Program
    {
        static void Main(string[] args)
        {           
            List<int> a = new List<int>();
            List<int> b = new List<int>();
            List<int> c = new List<int>();
            a = Numbers(a, 1);
            b = Numbers(b, 2);
            Console.Clear();
            Console.WriteLine("==================MENU====================");
            Console.WriteLine("| 1. Union                               |");
            Console.WriteLine("| 2. Interseccion                        |");
            Console.WriteLine("==========================================");
            int opc = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("=================Valores===================");
            Console.Write("A. ");
            PrintNumber(a);
            Console.Write("B. ");
            PrintNumber(b);
            a.AddRange(b);

            switch (opc)
            {
                case 1:                   
                    Console.WriteLine("==================Union====================");                  
                    while (GetDuplicate(a) != 0)
                    {
                        a.Remove(GetDuplicate(a));
                    }
                    break;

                case 2:
                    Console.WriteLine("===============Interseccion================");
                    while (GetDuplicate(a) != 0)
                    {
                        c.Add(GetDuplicate(a));
                        a.Remove(GetDuplicate(a));
                    }
                    a.Clear();
                    a = c;
                    break;
                default:
                    Console.WriteLine("Ingrese el numero de una opcion valida.");
                    break;
            }           
            a.Sort();
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();
        }
        public static List<int> Numbers(List<int> r, int a)
        {
            Console.WriteLine($"Ingrese los numeros del conjunto {a} separados por coma (1,2,3...)");
            string linea = Console.ReadLine();
            for (int i = 0; i < linea.Split(',').Length; i++)
            {
                r.Add(int.Parse(linea.Split(',').ElementAt(i)));
            }
            return r;
        }
        public static void PrintNumber(List<int> a) {
            foreach (var item in a)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public static int GetDuplicate(List<int> range)
        {
            try
            {
                int Num1 = range[0];
                int Num2 = range[0];

                while (true)
                {
                    Num1 = range[Num1];
                    Num2 = range[range[Num2]];
                    if (Num1 == Num2)
                        break;
                }

                int part1 = range[0];
                int part2 = Num1;
                while (part1 != part2)
                {
                    part1 = range[part1];
                    part2 = range[part2];
                }
                return part1;
            }
            catch (Exception)
            {
                return 0;
            }                      
        }
    }
}
