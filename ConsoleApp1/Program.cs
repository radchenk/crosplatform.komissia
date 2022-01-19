using System;
using System.IO;



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "INPUT.txt";
            string outputPAth = "OUTPUT.txt";
            int maxNum;
            int searchedNum;
            using (StreamReader sr = new StreamReader(inputPath))
            {
                maxNum = int.Parse(sr.ReadLine());
                searchedNum = int.Parse(sr.ReadLine());
                Console.WriteLine("Шукане число знаходить в промужку: вiд 1 до " + maxNum);
            }

            int min = 1;
            int max = maxNum;
            int totalCandy = 0;
            int resultNum;


            while (true)
            {
                if (CandyFounder.isNumInSeries(min, max - (max - min) / 2, searchedNum) == 1)
                {
                    totalCandy += 1;
                    max = max - (max - min) / 2;
                }
                else
                {
                    totalCandy += 2;
                    min = (max + min) / 2;
                }
                if (max - min == 1)
                {
                    if (min == searchedNum)
                    {
                        totalCandy += 1;
                        resultNum = min;
                        break;
                    }
                    else
                    {
                        totalCandy += 2;
                        resultNum = max;
                        break;
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(outputPAth))
            {
                sw.Write("Для знаходження числа " + resultNum + " з проміжку від 1 до " + maxNum +
                    " було витрачено " + totalCandy + " цукерок.");
            }

            Console.WriteLine("Шукане число:" + resultNum);
            Console.WriteLine("Витрачено цукерок:" + totalCandy);
        }
    }

    public static class CandyFounder
    {
        public static int isNumInSeries(int min, int max, int num)
        {
            if (num >= min && num <= max) return 1;
            return 2;
        }
    }
}
