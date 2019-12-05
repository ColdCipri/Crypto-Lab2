using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Cryptography
{
    public static class Utils
    {

        public static ulong gcd(ulong a, ulong b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }

        public static ulong boundCheck(ulong a, ulong b)
        {
            ulong i = 1;

            while ((ulong)Math.Pow(a, i) <= b)
            {
                i++;
            }

            i--;
            return (ulong)Math.Pow(a, i);
        }

        public static bool isPrime(ulong n)
        {
            if (n < 2)
                return false;
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;

            for (ulong i = 3; i < Math.Floor(Math.Sqrt(n)); i += 2)
                if (n % i == 0)
                    return false;

            return true;
        }

        public static ulong binaryPow(ulong a, ulong k, ulong n)
        {
            a %= n;
            ulong res = 1;
            while (k > 0)
            {
                if ((k & 1) != 0)
                    res = res * a % n;
                a *= a % n;
                k >>= 1;
            }
            return res;
        }
    }
}
