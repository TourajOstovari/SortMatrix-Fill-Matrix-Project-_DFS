using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fill_Matrix_NoReptative_
{
    class Rep_Data_Struct
    {
        public Array Pattern;
        public String Pattern_way;
        public Rep_Data_Struct(Array pattern,String pattern_way)
        {
            this.Pattern = pattern; this.Pattern_way = pattern_way;
        }
    }
    class Patterns_Alternative
    {
        public Stack<Rep_Data_Struct> Patterns_Alt = new Stack<Rep_Data_Struct>();
    }
    internal partial class Program
    {
        public class Rep_Matrix
        {
            private Stack<Array> arrays = new Stack<Array>();
            byte[] goal_rep1_ = new byte[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] goal_rep2 = new byte[9] { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            /// <summary>
            /// Checks for array pattern 3x3 is available and if was not avilable before returns false.
            /// </summary>
            /// <param name="buffered_">Pass the array that you want be checked</param>
            /// <returns></returns>
            public bool Contains_(byte[] buffered_)
            {
                if (arrays.Contains(buffered_)) return true;
                else return false;
            }
            public bool Final_Goal_Contains_(byte[] buffered_)
            {
                if (goal_rep1_.SequenceEqual<byte>(buffered_) || goal_rep2.SequenceEqual<byte>(buffered_)) { Print_Arrays(buffered_); System.Threading.Thread.Sleep(5000); return true; }
                else return false;
            }
            public void set_buffer(byte[] buffered_)
            {
                arrays.Push(buffered_);
            }
        }
        private static bool Goal_Found = false;
        public static void Print_Arrays(byte[] temp_buffer)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n<<<<<<<<  GOAL IS FOUND  >>>>>>>>\n");
            int temp_counter = 0;

            for (int satrha = 0; satrha < 3; satrha++)
            {
                for (int sotonha = 0; sotonha < 3; sotonha++)
                {
                    if (temp_buffer[temp_counter] == 0) Console.ForegroundColor = ConsoleColor.Green;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("{0}\t", temp_buffer[temp_counter]);
                    temp_counter += 1;
                }
                Console.Write("\n");
            }
            Console.WriteLine("\n\t WAY FOR SOLVING MATRIX AND SORTING : {0}\n", Temp_way);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t With Moving Zero According Published Directions, You Can Solve The Matrix And Make IT Sorted  ");
            Console.ForegroundColor = ConsoleColor.White;
            Goal_Found = true;
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
