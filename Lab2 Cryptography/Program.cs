using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//used to efficiently find any prime factor p of an odd composite
//number n for which p − 1 has only small prime divisors
namespace Lab2_Cryptography
{
    static class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            //varbiables
            int a = 2;
            ulong bound = 13, n = 1241143;
            List<int> usedA = new List<int>();
            String input;
            bool ok = true;

            //input n
            while (ok)
            {
                Console.Write("Please input n (by default it is set to 1241143):");
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                    n = (ulong)Convert.ToUInt64(input);

                if (n % 2 == 0)
                    Console.WriteLine("The number is even, we need an odd number!");
                else
                    ok = false;
            }

            //input bound
            Console.Write("Please input bound (by default it is set to 13):");
            input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
                bound = (ulong)Convert.ToUInt64(input);

            ok = true;

            while (ok)
            {
                ulong k = 1;
                
                //check if a is already in the list to not be used again
                if (usedA.Contains(a))
                    lock (random)
                        a = random.Next(2, (int)n-1);
                else
                    usedA.Add(a);
                
                //creates the power k
                ulong b = bound;
                while (b > 1)
                {
                    if (Utils.isPrime(b))
                    {
                        k *= Utils.boundCheck(b, bound);
                    }
                    b--;
                }

                ulong nr = Utils.binaryPow((ulong)a, k, n);

                ulong gcdNr = Utils.gcd(nr, n);

                if ((gcdNr > 1 && gcdNr < n) && (Utils.isPrime(n / gcdNr)))
                {
                    Console.WriteLine("\n" + n + " = " + gcdNr + " * " + n / gcdNr);
                    ok = false;
                }
                //else if (gcdNr == 1)
                //{
                //    Console.WriteLine("Failed!");
                //    Console.WriteLine("Greatest common divisor = 1\n");
                //}
                //else
                //{
                //    Console.WriteLine("Failed!");
                //    Console.WriteLine("Greatest common divisor = n\n");
                //}


            }
            Console.WriteLine("n = " + n + "\na = " + a + "\nB = " + bound);
            Console.Read();
        }
    }
}
