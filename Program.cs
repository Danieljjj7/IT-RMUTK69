using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demro007zAINW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ข่้ิอ1
            string[,] str = {
            {"Nong", "10"},
            {"Popeye", "5"},
            {"Olive", "4"},
            {"Nobita", "7"},
            {"Jiant", "9"},
            {"Oshin", "2"}
        };
            for (int i = 0; i < str.GetLength(0); i++)
            {
                string name = str[i, 0];
                int count = int.Parse(str[i, 1]);

                string stars = new string('*', count);
                Console.WriteLine("{0}\t{1,-12}{2,-8}{3}", i + 1, name, count, stars);
            }
            Console.WriteLine();

            //ข้อ2
            string[,] data = {
            {"Pom", "170", "55"},
            {"Koi", "165", "40"},
            {"Mai", "150", "38"},
            {"Nam", "155", "80"},
            {"Tue", "155", "49"},
            {"Yak", "180", "50"}
        };

            Console.WriteLine("{0,-8}{1,-8}{2,-8}{3,-20}{4,-12}{5}", "Name", "Height", "Weight", "Standard", "Compare", "Message");

            for (int i = 0; i < data.GetLength(0); i++)
            {
                string nam = data[i, 0];
                int height = int.Parse(data[i, 1]);
                int weight = int.Parse(data[i, 2]);

                int stdWeight = height - 110;
                int compare = weight - stdWeight;

                string message = "";
                if (compare < -5)
                {
                    message = "you are thin";
                }
                else if (compare >= -5 && compare <= 5)
                {
                    message = "you are normal";
                }
                else
                {
                    message = "you are fat";
                }
                string stdFormat = $"{height} - 110 = {stdWeight}";

                Console.WriteLine("{0,-8}{1,-8}{2,-8}{3,-20}{4,-12}{5}", nam, height, weight, stdFormat, compare, message);
            }
            Console.ReadKey();
        }
    }
}
