using System;
using System.Collections.Generic;

namespace Circular_prime_digits
{
    class SearchingCircularPrimeClass
    {
        static List<int> primeArr = new List<int>();
        static List<int> circlePrimeDigits = new List<int>();

        // searching prime digits by method Sieve of Eratosthenes https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
        static void isPrime(int parametr)
        {
            bool[] primeArray = new bool[parametr];
            for (int i = 0; i < primeArray.Length; i++)
            {
                primeArray[i] = true;
            }

            for (int i = 2; i * i <= parametr; i++)
            {
                if (primeArray[i - 1])
                {
                    for (int j = i * i - 1; j < parametr; j += i)
                    {
                        primeArray[j] = false;
                    }
                }
            }

            for (int i = 1; i < primeArray.Length; i++)
            {
                if (primeArray[i])
                {
                    primeArr.Add(i + 1);
                }
            }
        }

        //check on circular prime
        static void isCircularPrime()
        {
            foreach (int cirk in primeArr)
            {
                string str = cirk.ToString();
                if (cirk < 10) { circlePrimeDigits.Add(cirk); continue; }

                else if (str.IndexOf('0') != -1)
                    continue;


                int newDigit = 0;
                int count = 1;
                bool isAllTrue = true;
                //cyclic shift
                while (count < str.Length)
                {
                    string newDigitStr = "";
                    char temp = str[0];
                    newDigitStr = str.Substring(1);
                    newDigitStr += temp;
                    newDigit = Convert.ToInt32(newDigitStr);
                    if (!primeArr.Contains(newDigit))
                    {
                        isAllTrue = false;
                        goto again;
                    }
                    str = newDigit.ToString();
                    count++;
                }
                if (isAllTrue)
                    circlePrimeDigits.Add(cirk);
                again:
                Console.Write("");
            }
        }

        static void Main()
        {
            isPrime(1000000);
            isCircularPrime();
            
            Console.WriteLine();
            Console.WriteLine("Circle prime digits:\n");
            foreach (var item in circlePrimeDigits)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine("\n\nNubmer  of the prime digits: {0}\n\nNubmer  of the circle prime digits: {1}", primeArr.Count, circlePrimeDigits.Count);

            Console.Read();
        }
    }
}
