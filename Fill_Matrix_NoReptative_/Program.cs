using System;
namespace Fill_Matrix_NoReptative_
{
    using System.Collections.Generic;

    internal partial class Program
    {
        public static int possible_patterns_count = 1;
        public static String way = "";
        public static String Temp_way = "";
        private static void Main(string[] args)
        {

            Rep_Matrix Rep_Matrixs = new Rep_Matrix();
            Patterns_Alternative patterns_ = new Patterns_Alternative();
            Console.Title = "Developed by Mr. Touraj Ostovari :) 2019";
            Console.Write("Hi, welcome to my practive project that University Gave Me, It is a project for filling matrix\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Our numbers are: \n\t0 - 1 - 2 - 3 - 4 - 5 - 6 - 7 - 8");
            Console.WriteLine("Our Matrix: \n\t3 × 3 = 9, Our aiming numbers and matrix counts are same so for calculating\npossible patterns of this matrix while none of numbers should not repeat anymore is n!");
            #region Calculating all of possible patterns
            for (byte i = 1; i <= 9; i++)
            {
                possible_patterns_count *= i;
            }
            #endregion
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nAll of possible patterns count is::\t{0}", possible_patterns_count.ToString());
            From_First_Again:
            int Counter = 0;
            System.Collections.Generic.List<int> rep_temp = new List<int>();
            while (Counter != possible_patterns_count)
            {
                byte[] buffer_ = new byte[9] { 1, 2, 3, 7, 4, 8, 0, 6, 5 };
                Random rand = new Random();
                Console.WriteLine("\nDo you want use default values?\ty/n");
                if (Console.ReadLine() == "n")
                {
                    #region Generates_Nine_Numbers
                    for (int i = 0; i < 9;)
                    {
                        int temp_numbers = (byte)rand.Next(0, 9);

                        if (!rep_temp.Contains(temp_numbers))
                        {
                            rep_temp.Add((byte)temp_numbers);
                            buffer_[i] = (byte)temp_numbers;
                            i++;
                        }
                    }
                }
                #endregion
                
            Generate_again:
                rep_temp.Clear();
                
                if (Rep_Matrixs.Contains_(buffer_) == false)
                {
                    if (Rep_Matrixs.Final_Goal_Contains_(buffer_)) Console.WriteLine("\nGOAL PATTERN FOUND!!!!\n");
                    Rep_Matrixs.set_buffer(buffer_);
                    Counter += 1;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("ONE NEW PATTERN OF MATRIX FOUND!!! \n");
                    Console.ForegroundColor = ConsoleColor.White;
                    int temp_counter = 0;
                    for (int satrha = 0; satrha < 3; satrha++)
                    {
                        for (int sotonha = 0; sotonha < 3; sotonha++)
                        {
                            if (buffer_[temp_counter] == 0) Console.ForegroundColor = ConsoleColor.Green;
                            else Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("{0}\t", buffer_[temp_counter]);
                            temp_counter += 1;
                        }
                        Console.Write("\n");
                    }
                    //byte[] buffer_clean = new byte[9];
                    //Rep_Matrixs.set_buffer(buffer_clean);
                }
                Console.ForegroundColor = ConsoleColor.Red;

                switch (Array.IndexOf<byte>(buffer_, 0))
                {

                    case 0:
                        #region Main_Seprate_Process
                        Console.WriteLine("\n>>>>>>>  Replacing 0   >>>>>>> \n");
                        for (int i = 0; i < 2; i++)
                        {
                            byte[] temp_buffer = new byte[9];
                            buffer_.CopyTo(temp_buffer, 0);
                            #region First_Step
                            if (i == 0)
                            {
                                temp_buffer[0] = temp_buffer[1];
                                temp_buffer[1] = 0;
                                Temp_way = way + "-Right";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Right"));
                            }
                            #endregion
                            #region Second_Step
                            if (i == 1)
                            {
                                temp_buffer[0] = temp_buffer[3];
                                temp_buffer[3] = 0;
                                Temp_way = way + "-Down";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer,way+"-Down"));
                            }
                            #endregion
                            #region Print_Job
                            int temp_counter = 0;
                            if (Rep_Matrixs.Final_Goal_Contains_(temp_buffer) == true) Goal_Found = true;
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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n>>>>>>>>>> DONE!!!  >>>>>>>\n");
                            #endregion
                        }
                        #endregion
                        break;
                    case 1:
                        #region Main_Seprate_Process
                        Console.WriteLine("\n>>>>>>>  Replacing 0   >>>>>>> \n");
                        for (int i = 0; i < 3; i++)
                        {
                            byte[] temp_buffer = new byte[9];
                            buffer_.CopyTo(temp_buffer, 0);
                            #region First_Step
                            if (i == 0)
                            {
                                temp_buffer[1] = temp_buffer[0];
                                temp_buffer[0] = 0;
                                Temp_way = way + "-Left";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer,way+"-Left"));
                            }
                            #endregion
                            #region Second_Step
                            if (i == 1)
                            {
                                temp_buffer[1] = temp_buffer[2];
                                temp_buffer[2] = 0;
                                Temp_way = way + "-Right";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer,way+"-Right"));
                            }
                            #endregion
                            #region Third_Step
                            if (i == 2)
                            {
                                temp_buffer[1] = temp_buffer[4];
                                temp_buffer[4] = 0;
                                Temp_way = way + "-Down";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer,way+"-Down"));
                            }
                            #endregion
                            #region Print_Job
                            int temp_counter = 0;
                            if (Rep_Matrixs.Final_Goal_Contains_(temp_buffer) == true) Goal_Found = true;
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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n>>>>>>>>>> DONE!!!  >>>>>>>\n");
                            #endregion
                        }
                        #endregion
                        break;
                    case 2:
                        #region Main_Seprate_Process
                        Console.WriteLine("\n>>>>>>>  Replacing 0   >>>>>>> \n");
                        for (int i = 0; i < 2; i++)
                        {
                            byte[] temp_buffer = new byte[9];
                            buffer_.CopyTo(temp_buffer, 0);
                            #region First_Step
                            if (i == 0)
                            {
                                temp_buffer[2] = temp_buffer[1];
                                temp_buffer[1] = 0;
                                Temp_way = way + "-Left";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer,way+"-Left"));
                            }
                            #endregion
                            #region Second_Step
                            if (i == 1)
                            {
                                temp_buffer[2] = temp_buffer[5];
                                temp_buffer[5] = 0;
                                Temp_way = way + "-Down";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer,way+"-Down"));
                            }
                            #endregion
                            #region Print_Job
                            int temp_counter = 0;
                            if (Rep_Matrixs.Final_Goal_Contains_(temp_buffer) == true) Goal_Found = true;
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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n>>>>>>>>>> DONE!!!  >>>>>>>\n");
                            #endregion
                        }
                        #endregion
                        break;
                    case 3:
                        #region Main_Seprate_Process
                        Console.WriteLine("\n>>>>>>>  Replacing 0   >>>>>>> \n");
                        for (int i = 0; i < 3; i++)
                        {
                            byte[] temp_buffer = new byte[9];
                            buffer_.CopyTo(temp_buffer, 0);
                            #region First_Step
                            if (i == 0)
                            {
                                temp_buffer[3] = temp_buffer[0];
                                temp_buffer[0] = 0;
                                Temp_way = way + "-Up";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer,way+"-Up"));
                            }
                            #endregion
                            #region Second_Step
                            if (i == 1)
                            {
                                temp_buffer[3] = temp_buffer[4];
                                temp_buffer[4] = 0;
                                Temp_way = way + "-Right";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Right"));
                            }
                            #endregion
                            #region Third_Step
                            if (i == 2)
                            {
                                temp_buffer[3] = temp_buffer[6];
                                temp_buffer[6] = 0;
                                Temp_way = way + "-Down";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Down"));
                            }
                            #endregion
                            #region Print_Job
                            int temp_counter = 0;
                            if (Rep_Matrixs.Final_Goal_Contains_(temp_buffer) == true) Goal_Found = true;
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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n>>>>>>>>>> DONE!!!  >>>>>>>\n");
                            #endregion
                        }
                        #endregion
                        break;
                    case 4:
                        #region Main_Seprate_Process
                        Console.WriteLine("\n>>>>>>>  Replacing 0   >>>>>>> \n");
                        for (int i = 0; i < 4; i++)
                        {
                            byte[] temp_buffer = new byte[9];
                            buffer_.CopyTo(temp_buffer, 0);
                            #region First_Step
                            if (i == 0)
                            {
                                temp_buffer[4] = temp_buffer[1];
                                temp_buffer[1] = 0;
                                Temp_way = way + "-Up";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Up"));
                            }
                            #endregion
                            #region Second_Step
                            if (i == 1)
                            {
                                temp_buffer[4] = temp_buffer[3];
                                temp_buffer[3] = 0;
                                Temp_way = way + "-Left";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Left"));
                            }
                            #endregion
                            #region Third_Step
                            if (i == 2)
                            {
                                temp_buffer[4] = temp_buffer[5];
                                temp_buffer[5] = 0;
                                Temp_way = way + "-Right";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Right"));
                            }
                            #endregion
                            #region Fourth_Step
                            if (i == 3)
                            {
                                temp_buffer[4] = temp_buffer[7];
                                temp_buffer[7] = 0;
                                Temp_way = way + "-Down";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Down"));
                            }
                            #endregion

                            #region Print_Job
                            int temp_counter = 0;
                            if (Rep_Matrixs.Final_Goal_Contains_(temp_buffer) == true) Goal_Found = true;

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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n>>>>>>>>>> DONE!!!  >>>>>>>\n");
                            #endregion
                        }
                        #endregion
                        break;
                    case 5:
                        #region Main_Seprate_Process
                        Console.WriteLine("\n>>>>>>>  Replacing 0   >>>>>>> \n");
                        for (int i = 0; i < 3; i++)
                        {
                            byte[] temp_buffer = new byte[9];
                            buffer_.CopyTo(temp_buffer, 0);
                            #region First_Step
                            if (i == 0)
                            {
                                temp_buffer[5] = temp_buffer[2];
                                temp_buffer[2] = 0;
                                Temp_way = way + "-Up";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Up"));
                            }
                            #endregion
                            #region Second_Step
                            if (i == 1)
                            {
                                temp_buffer[5] = temp_buffer[4];
                                temp_buffer[4] = 0;
                                Temp_way = way + "-Left";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Left"));
                            }
                            #endregion
                            #region Third_Step
                            if (i == 2)
                            {
                                temp_buffer[5] = temp_buffer[8];
                                temp_buffer[8] = 0;
                                Temp_way = way + "-Down";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Down"));
                            }
                            #endregion
                            #region Print_Job
                            int temp_counter = 0;
                            if (Rep_Matrixs.Final_Goal_Contains_(temp_buffer) == true) Goal_Found = true;
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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n>>>>>>>>>> DONE!!!  >>>>>>>\n");
                            #endregion
                        }
                        #endregion
                        break;
                    case 6:
                        #region Main_Seprate_Process
                        Console.WriteLine("\n>>>>>>>  Replacing 0   >>>>>>> \n");
                        for (int i = 0; i < 2; i++)
                        {
                            byte[] temp_buffer = new byte[9];
                            buffer_.CopyTo(temp_buffer, 0);
                            #region First_Step
                            if (i == 0)
                            {
                                temp_buffer[6] = temp_buffer[3];
                                temp_buffer[3] = 0;
                                Temp_way = way + "-Up";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Up"));
                            }
                            #endregion
                            #region Second_Step
                            if (i == 1)
                            {
                                temp_buffer[6] = temp_buffer[7];
                                temp_buffer[7] = 0;
                                Temp_way = way + "-Right";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Right"));
                            }
                            #endregion

                            #region Print_Job
                            int temp_counter = 0;
                            if (Rep_Matrixs.Final_Goal_Contains_(temp_buffer) == true) Goal_Found = true;
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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n>>>>>>>>>> DONE!!!  >>>>>>>\n");
                            #endregion
                        }
                        #endregion
                        break;
                    case 7:
                        #region Main_Seprate_Process
                        Console.WriteLine("\n>>>>>>>  Replacing 0   >>>>>>> \n");
                        for (int i = 0; i < 3; i++)
                        {
                            byte[] temp_buffer = new byte[9];
                            buffer_.CopyTo(temp_buffer, 0);
                            #region First_Step
                            if (i == 0)
                            {
                                temp_buffer[7] = temp_buffer[4];
                                temp_buffer[4] = 0;
                                Temp_way = way + "-Up";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Up"));
                            }
                            #endregion
                            #region Second_Step
                            if (i == 1)
                            {
                                temp_buffer[7] = temp_buffer[6];
                                temp_buffer[6] = 0;
                                Temp_way = way + "-Left";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Left"));
                            }
                            #endregion
                            #region Third_Step
                            if (i == 2)
                            {
                                temp_buffer[7] = temp_buffer[8];
                                temp_buffer[8] = 0;
                                Temp_way = way + "-Right";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Right"));
                            }
                            #endregion

                            #region Print_Job
                            int temp_counter = 0;
                            if (Rep_Matrixs.Final_Goal_Contains_(temp_buffer) == true) Goal_Found = true;
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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n>>>>>>>>>> DONE!!!  >>>>>>>\n");
                            #endregion
                        }
                        #endregion
                        break;
                    case 8:
                        #region Main_Seprate_Process
                        Console.WriteLine("\n>>>>>>>  Replacing 0   >>>>>>> \n");
                        for (int i = 0; i < 2; i++)
                        {
                            byte[] temp_buffer = new byte[9];
                            buffer_.CopyTo(temp_buffer, 0);
                            #region First_Step
                            if (i == 0)
                            {
                                temp_buffer[8] = temp_buffer[5];
                                temp_buffer[5] = 0;
                                Temp_way = way + "-Up";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Up"));
                            }
                            #endregion
                            #region Second_Step
                            if (i == 1)
                            {
                                temp_buffer[8] = temp_buffer[7];
                                temp_buffer[7] = 0;
                                Temp_way = way + "-Left";
                                patterns_.Patterns_Alt.Push(new Rep_Data_Struct(temp_buffer, way + "-Left"));
                            }
                            #endregion

                            #region Print_Job
                            int temp_counter = 0;
                            if (Rep_Matrixs.Final_Goal_Contains_(temp_buffer) == true) Goal_Found = true;
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
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\n>>>>>>>>>> DONE!!!  >>>>>>>\n");
                            #endregion
                        }
                        #endregion
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nPattern number:\t{0}", Counter);
                Console.ForegroundColor = ConsoleColor.White;
                System.Threading.Thread.Sleep(50);
                buffer_ = (byte[]) patterns_.Patterns_Alt.Peek().Pattern;
                way = patterns_.Patterns_Alt.Peek().Pattern_way;
                patterns_.Patterns_Alt.Pop();
                if (Rep_Matrixs.Final_Goal_Contains_(buffer_) == true) Goal_Found = true;
                if (Goal_Found == true)
                {
                    Console.Write("\nDo you want continue generating job?? y/n   "); if (Console.ReadLine() == "n") break; else { Goal_Found = false; Console.Clear(); goto From_First_Again; }
                }
                goto Generate_again;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);

        }
    }
}
