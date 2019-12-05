using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Cryptography
{
    static class Program
    {

        static ulong gcd(ulong a, ulong b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }

        static ulong boundCheck(ulong a, ulong b)
        {
            ulong i = 1;
           
            while ((ulong)Math.Pow(a, i) <= b)
            {
                i++;
            }

            i--;
            return (ulong)Math.Pow(a, i);
        }

        static bool isPrime(ulong n)
        {
            if (n <= 1)
                return false;

            for (ulong i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        static void Main(string[] args)
        {

            int a;
            ulong bound, n;
            bool ok = true;
            while (ok)
            {

                ulong k = 1;

                Console.Write("Please input n:");
                String input = Console.ReadLine();
                n = (ulong)Convert.ToUInt64(input);

                Console.Write("Please input bound:");
                input = Console.ReadLine();
                bound = (ulong)Convert.ToUInt64(input);

                Console.Write("Please input a:");
                input = Console.ReadLine();
                a = Convert.ToInt32(input);

                ulong b = bound;

                while (b > 1)
                {
                    if (isPrime(b))
                    {
                        k *= boundCheck(b, bound);
                    }
                    b--;
                }

                ulong nr = (ulong)Math.Pow(a, k) - 1;

                ulong gcdNr = gcd(nr, n);

                if ((gcdNr > 1 && gcdNr < n) && (isPrime(n/gcdNr)))
                {
                    Console.WriteLine(n + " = " + gcdNr + " * " + n / gcdNr);
                }
                else if ((gcdNr > 1 && gcdNr < n) && (!isPrime(n / gcdNr)))
                {
                    Console.WriteLine(n / gcdNr + " is not prime!");
                }
                else if (gcdNr == 1)
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine("Greatest common divisor = 1");
                }
                else
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine("Greatest common divisor = n");
                }


                
                Console.WriteLine("Try again? 1/0");
                input = Console.ReadLine();
                if (input == "0")
                    ok = false;
                else if (input == "1")
                    continue;
                else
                    throw new Exception("Invalid input! 1/0");
            }
        }
    }
}
