using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _13December2024
{
    internal class Program
    {
        static Random Random = new Random();



        static void stage3(char[,] table, int numberOfLines)
        {
            //constructing a new 5x5 table
            char[,] shift = new char[5, 5];

            //placing connected random lines
            bool flag = true;

            while (flag)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (i % 2 == 1)
                        {
                            shift[i, j] = ' ';
                        }
                        else
                        {
                            if (j % 2 == 0)
                            {
                                shift[i, j] = '+';
                            }
                            else
                            {
                                shift[i, j] = ' ';
                            }
                        }
                    }
                }



                for (int i = 1; i <= numberOfLines; i++)
                {
                    int row = Random.Next(1, 5);
                    int column = Random.Next(1, 5);


                    if ((shift[row, column] == ' ') && (row % 2 != column % 2))
                    {
                        if (row % 2 == 1)
                        {
                            shift[row, column] = '|';
                        }
                        else
                        {
                            shift[row, column] = '-';
                        }
                    }
                    else
                    {
                        i--;
                    }

                }

                //evaluating whether lines are connected

                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                    {
                        if (shift[i, j] == '-')
                        {
                            shift[i, j + 1] = '1';
                            shift[i, j - 1] = '1';
                        }

                        else if (shift[i, j] == '|')
                        {
                            shift[i + 1, j] = '1';
                            shift[i - 1, j] = '1';
                        }
                    }

                int counter = 0;

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (shift[i, j] == '1') counter++;
                    }
                }

                if (counter == numberOfLines + 1) flag = false;



                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (shift[i, j] == '1') shift[i, j] = '+';
                    }
                }

            }


            //shifting

            if (shift[0, 1] == ' ' && shift[0, 3] == ' ' && shift[1, 0] == ' ' && shift[1, 2] == ' ' && shift[1, 4] == ' ')
            {
                shift[0, 1] = shift[2, 1];
                shift[0, 3] = shift[2, 3];
                shift[1, 0] = shift[3, 0];
                shift[1, 2] = shift[3, 2];
                shift[1, 4] = shift[3, 4];
                shift[2, 1] = shift[4, 1];
                shift[2, 3] = shift[4, 3];

                shift[3, 0] = ' ';
                shift[3, 2] = ' ';
                shift[3, 4] = ' ';
                shift[4, 1] = ' ';
                shift[4, 3] = ' ';

            }
            if (numberOfLines == 2 && shift[2, 1] == '-' && shift[2, 3] == '-')
            {
                shift[0, 1] = '-';
                shift[0, 3] = '-';
                shift[2, 1] = ' ';
                shift[2, 3] = ' ';
            }

            if (numberOfLines == 1 && (shift[2, 1] == '-' || shift[2, 3] == '-'))
            {
                if (shift[2, 1] == '-')
                {
                    shift[0, 1] = '-';
                    shift[2, 1] = ' ';
                }
                else
                {
                    shift[0, 3] = '-';
                    shift[2, 3] = ' ';
                }
            }




            if (shift[1, 0] == ' ' && shift[3, 0] == ' ' && shift[0, 1] == ' ' && shift[2, 1] == ' ' && shift[4, 1] == ' ')
            {
                shift[1, 0] = shift[1, 2];
                shift[3, 0] = shift[3, 2];
                shift[0, 1] = shift[0, 3];
                shift[2, 1] = shift[2, 3];
                shift[4, 1] = shift[4, 3];
                shift[1, 2] = shift[1, 4];
                shift[3, 2] = shift[3, 4];

                shift[0, 3] = ' ';
                shift[2, 3] = ' ';
                shift[4, 3] = ' ';
                shift[1, 4] = ' ';
                shift[3, 4] = ' ';

            }
            if (numberOfLines == 2 && shift[1, 2] == '|' && shift[2, 3] == '|')
            {
                shift[1, 0] = '|';
                shift[3, 0] = '|';
                shift[1, 2] = ' ';
                shift[3, 2] = ' ';
            }

            if (numberOfLines == 1 && (shift[1, 2] == '|' || shift[3, 2] == '|'))
            {
                if (shift[1, 2] == '|')
                {
                    shift[1, 0] = '|';
                    shift[1, 2] = ' ';
                }
                else
                {
                    shift[3, 0] = '|';
                    shift[3, 2] = ' ';
                }
            }





            //adding this table to main game table
            for (int i = 1; i <= 100; i++)
            {

                int mainX = 1;
                int mainY = 1;


                while (table[mainY, mainX] != '+')
                {
                    mainX = Random.Next(0, 28);
                    mainY = Random.Next(0, 14);

                }


                bool Flag = true;
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {

                        if ((j % 2 != k % 2) && shift[j, k] != ' ' && table[mainY + j, mainX + k] != ' ')
                        {
                            Flag = false;
                            break;
                        }

                    }
                }



                if (Flag)
                {
                    for (int j = 0; j < 5; j++)
                    {

                        for (int k = 0; k < 5; k++)
                        {
                            if (j % 2 != k % 2 && shift[j, k] != ' ')
                            {
                                table[mainY + j, mainX + k] = shift[j, k];
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(mainX + k, mainY + j);
                                Console.Write(table[mainY + j, mainX + k]);
                            }

                        }
                    }
                    break;
                }



            }






        }

        static bool IsItRegular(char[,] table, int x, int y)
        {
            //these two variables will hold the square coordinate info
            int col = x;
            int row = y;

            if (y % 2 == 1)
            {
                if (((table[y, x + 2] == '|' && table[y - 1, x + 1] == '-' && table[y + 1, x + 1] == '-') &&//forming two squares with one line
                     (table[y, x - 2] == '|' && table[y - 1, x - 1] == '-' && table[y + 1, x - 1] == '-')) ||
                     (table[y, x - 2] == '|' && table[y - 1, x - 1] == '-' && table[y + 1, x - 1] == '-'))
                {
                    row = y;
                    col = x - 1;
                }

                else if (table[y, x + 2] == '|' && table[y - 1, x + 1] == '-' && table[y + 1, x + 1] == '-')
                {
                    row = y;
                    col = x + 1;
                }
            }


            else
            {

                if (((table[y - 1, x - 1] == '|' && table[y - 2, x] == '-' && table[y - 1, x + 1] == '|') && //forming two squares with one lines
                     (table[y + 1, x - 1] == '|' && table[y + 2, x] == '-' && table[y + 1, x + 1] == '|')) ||
                     ((table[y - 1, x - 1] == '|' && table[y - 2, x] == '-' && table[y - 1, x + 1] == '|')))
                {
                    row = y - 1;
                    col = x;
                }

                else if (table[y + 1, x - 1] == '|' && table[y + 2, x] == '-' && table[y + 1, x + 1] == '|')
                {
                    row = y + 1;
                    col = x;
                }


            }



            if (row < 2 && col < 2)
            {
                if (table[row, col + 2] == '#' || table[row + 2, col] == '#')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (row > 16 && col < 2)
            {
                if (table[row, col + 2] == '#' || table[row - 2, col] == '#')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (row > 2 && col < 2)
            {
                if (table[row, col + 2] == '#' || table[row - 2, col] == '#' || table[row + 2, col] == '#')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (row < 2 && col > 30)
            {
                if (table[row, col - 2] == '#' || table[row + 2, col] == '#')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (row > 16 && col > 30)
            {
                if (table[row, col - 2] == '#' || table[row - 2, col] == '#')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (row > 2 && col > 30)
            {
                if (table[row, col - 2] == '#' || table[row - 2, col] == '#' || table[row + 2, col] == '#')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


            else if (row < 2 && col > 2)
            {
                if (table[row, col - 2] == '#' || table[row, col + 2] == '#' || table[row + 2, col] == '#')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (row > 16 && col > 2)
            {
                if (table[row, col - 2] == '#' || table[row, col + 2] == '#' || table[row - 2, col] == '#')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if (row > 2 && col > 2)
            {
                if (table[row, col - 2] == '#' || table[row, col + 2] == '#' || table[row - 2, col] == '#' || table[row + 2, col] == '#')
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            else
            {
                return false;
            }



        }

        static void SwitcthToP(char[,] table, int x, int y)
        {
            int row = y;
            int col = x;

            if (y % 2 == 1)
            {
                if (((table[y, x + 2] == '|' && table[y - 1, x + 1] == '-' && table[y + 1, x + 1] == '-') &&//forming two squares with one line
                     (table[y, x - 2] == '|' && table[y - 1, x - 1] == '-' && table[y + 1, x - 1] == '-')) ||
                     (table[y, x - 2] == '|' && table[y - 1, x - 1] == '-' && table[y + 1, x - 1] == '-'))
                {
                    row = y;
                    col = x - 1;
                }

                else if (table[y, x + 2] == '|' && table[y - 1, x + 1] == '-' && table[y + 1, x + 1] == '-')
                {
                    row = y;
                    col = x + 1;
                }
            }

            else
            {
                if (((table[y - 1, x - 1] == '|' && table[y - 2, x] == '-' && table[y - 1, x + 1] == '|') && //forming two squares with one lines
                     (table[y + 1, x - 1] == '|' && table[y + 2, x] == '-' && table[y + 1, x + 1] == '|')) ||
                     ((table[y - 1, x - 1] == '|' && table[y - 2, x] == '-' && table[y - 1, x + 1] == '|')))
                {
                    row = y - 1;
                    col = x;
                }

                else if (table[y + 1, x - 1] == '|' && table[y + 2, x] == '-' && table[y + 1, x + 1] == '|')
                {
                    row = y + 1;
                    col = x;
                }
            }






            if (row < 2 && col < 2)
            {
                if (table[row, col + 2] == '#')
                {
                    table[row, col + 2] = 'P';
                }

                if (table[row + 2, col] == '#')
                {
                    table[row + 2, col] = 'P';
                }

            }

            else if (row > 16 && col < 2)
            {

                if (table[row, col + 2] == '#')
                {
                    table[row, col + 2] = 'P';
                }

                if (table[row - 2, col] == '#')
                {
                    table[row - 2, col] = 'P';
                }


            }

            else if (row > 2 && col < 2)
            {

                if (table[row, col + 2] == '#')
                {
                    table[row, col + 2] = 'P';
                }
                if (table[row - 2, col] == '#')
                {
                    table[row - 2, col] = 'P';
                }
                if (table[row + 2, col] == '#')
                {
                    table[row + 2, col] = 'P';
                }

            }

            else if (row < 2 && col > 30)
            {

                if (table[row, col - 2] == '#')
                {
                    table[row, col - 2] = 'P';
                }


                if (table[row + 2, col] == '#')
                {
                    table[row + 2, col] = 'P';
                }


            }

            else if (row > 16 && col > 30)
            {

                if (table[row, col - 2] == '#')
                {
                    table[row, col - 2] = 'P';
                }

                if (table[row - 2, col] == '#')
                {
                    table[row - 2, col] = 'P';
                }

            }

            else if (row > 2 && col > 30)
            {
                if (table[row, col - 2] == '#')
                {
                    table[row, col - 2] = 'P';
                }

                if (table[row - 2, col] == '#')
                {
                    table[row - 2, col] = 'P';
                }

                if (table[row + 2, col] == '#')
                {
                    table[row + 2, col] = 'P';
                }


            }


            else if (row < 2 && col > 2)
            {
                if (table[row, col - 2] == '#')
                {
                    table[row, col - 2] = 'p';
                }

                if (table[row, col + 2] == '#')
                {
                    table[row, col + 2] = 'P';
                }

                if (table[row + 2, col] == '#')
                {
                    table[row + 2, col] = 'P';
                }


            }

            else if (row > 16 && col > 2)
            {

                if (table[row, col - 2] == '#')
                {
                    table[row, col - 2] = 'P';
                }

                if (table[row, col + 2] == '#')
                {
                    table[row, col + 2] = 'P';
                }

                if (table[row - 2, col] == '#')
                {
                    table[row - 2, col] = 'P';
                }


            }

            else if (row > 2 && col > 2)
            {
                if (table[row, col - 2] == '#')
                {
                    table[row, col - 2] = 'P';
                }

                if (table[row, col + 2] == '#')
                {
                    table[row, col + 2] = 'P';
                }

                if (table[row - 2, col] == '#')
                {
                    table[row - 2, col] = 'P';
                }

                if (table[row + 2, col] == '#')
                {
                    table[row + 2, col] = 'P';
                }


            }


        }

        static int Square(char[,] table, int x, int y)
        {

            try
            {
                if (y % 2 == 1)
                {
                    if ((table[y, x - 2] == '|' && table[y - 1, x - 1] == '-' && table[y + 1, x - 1] == '-') &&
                        (table[y, x + 2] == '|' && table[y - 1, x + 1] == '-' && table[y + 1, x + 1] == '-'))
                    {
                        return 1;
                    }

                    else if (table[y, x - 2] == '|' && table[y - 1, x - 1] == '-' && table[y + 1, x - 1] == '-')
                    {
                        return 2;
                    }

                    else if (table[y, x + 2] == '|' && table[y - 1, x + 1] == '-' && table[y + 1, x + 1] == '-')
                    {
                        return 3;
                    }

                    else return 100;


                }

                else
                {
                    if ((table[y - 2, x] == '-' && table[y - 1, x - 1] == '|' && table[y - 1, x + 1] == '|') &&
                        (table[y + 2, x] == '-' && table[y + 1, x - 1] == '|' && table[y + 1, x + 1] == '|'))
                    {
                        return 4;
                    }

                    else if (table[y - 2, x] == '-' && table[y - 1, x - 1] == '|' && table[y - 1, x + 1] == '|')
                    {
                        return 5;
                    }

                    else if (table[y + 2, x] == '-' && table[y + 1, x - 1] == '|' && table[y + 1, x + 1] == '|')
                    {
                        return 6;
                    }

                    else { return 100; }

                }

            }
            catch (System.IndexOutOfRangeException)
            {
                return 100;
            }






        }

        static int AImovement(char[,] table, int x, int y)
        {
            int AIcursor;
            int returned = 0;
            for (AIcursor = 0; AIcursor < 4; AIcursor++)
            {
                if (AIcursor == 0)
                {
                    if (table[y - 1, x + 2] == ' ' && Square(table, x + 2, y - 1) == 6)
                    {
                        Console.SetCursorPosition(0, 24);
                        Console.WriteLine("1,2");
                        returned = 1;
                    }
                    else if (table[y, x + 3] == ' ' && Square(table, x + 3, y) == 2)
                    {
                        Console.SetCursorPosition(0, 25);
                        Console.WriteLine("1,1");
                        returned = 2;
                    }
                    else if (table[y + 1, x + 2] == ' ' && Square(table, x + 2, y + 1) == 5)
                    {
                        Console.SetCursorPosition(0, 26);
                        Console.WriteLine("1,4");
                        returned = 3;
                    }
                }
                if (AIcursor == 1)
                {
                    if (table[y - 2, x - 1] == ' ' && Square(table, y - 2, x - 1) == 3)
                    {
                        Console.SetCursorPosition(5, 24);
                        Console.WriteLine("2,3");
                        returned = 4;
                    }
                    else if (table[y - 3, x] == ' ' && Square(table, x, y - 3) == 6)
                    {
                        Console.SetCursorPosition(5, 25);
                        Console.WriteLine("2,2");
                        returned = 5;
                    }
                    else if (table[y - 2, x + 1] == ' ' && Square(table, x + 1, y - 2) == 2)
                    {
                        Console.SetCursorPosition(5, 26);
                        Console.WriteLine("2,1");
                        returned = 6;
                    }
                }

                if (AIcursor == 2)
                {
                    if (table[y + 1, x - 2] == ' ' && Square(table, x - 2, y + 1) == 5)
                    {
                        Console.SetCursorPosition(10, 24);
                        Console.WriteLine("3,4");
                        returned = 7;
                    }
                    else if (table[y, x - 3] == ' ' && Square(table, x - 3, y) == 3)
                    {
                        Console.SetCursorPosition(10, 25);
                        Console.WriteLine("3,3");
                        returned = 8;
                    }
                    else if (table[y - 1, x - 2] == ' ' && Square(table, x - 2, y - 1) == 6)
                    {
                        Console.SetCursorPosition(10, 26);
                        Console.WriteLine("3,2");
                        returned = 9;
                    }
                }

                if (AIcursor == 3)
                {
                    if (table[y + 2, x - 1] == ' ' && Square(table, x - 1, y + 2) == 3)
                    {
                        Console.SetCursorPosition(15, 24);
                        Console.WriteLine("4,3");
                        returned = 10;
                    }
                    else if (table[y + 3, x] == ' ' && Square(table, x, y + 3) == 5)
                    {
                        Console.SetCursorPosition(15, 25);
                        Console.WriteLine("4,4");
                        returned = 11;
                    }
                    else if (table[y + 2, x + 1] == ' ' && Square(table, x + 1, y + 2) == 2)
                    {
                        Console.SetCursorPosition(15, 26);
                        Console.WriteLine("4,1");
                        returned = 12;
                    }
                }
            }
            returned = 0;
            return returned;


        }

        static void Main(string[] args)
        {
            //selecting game mode
            int numberOfTrials = 0;
            bool IsInvalid = true;
            Console.WriteLine("Please select game mode. \n1.Easy \n2.Moderate \n3.Hard");
            while (IsInvalid)
            {
                string game_mode = Console.ReadLine();

                if (game_mode == "1")
                {
                    numberOfTrials = 5;
                    IsInvalid = false;
                }
                else if (game_mode == "2")
                {
                    numberOfTrials = 50;
                    IsInvalid = false;
                }
                else if (game_mode == "3")
                {
                    numberOfTrials = 500;
                    IsInvalid = false;
                }
                else
                {
                    Console.WriteLine("Invalid input, Try again (1-easy, 2-moderate, 3-hard)");
                }
            }

            Console.Clear();



            int human_score = 0;
            int pc_score = 0;
            char[,] Table = new char[19, 33];

            for (int i = 0; i < Table.GetLength(0); i++)
            {
                if (i == 0 || i == 18)
                {
                    for (int j = 0; j < Table.GetLength(1); j++)
                    {
                        if (j % 2 == 0) Table[i, j] = '+';
                        else Table[i, j] = '-';
                    }

                }

                else if (i % 2 == 0)
                {
                    for (int j = 0; j < Table.GetLength(1); j++)
                    {
                        if (j % 2 == 0) Table[i, j] = '+';
                        else Table[i, j] = ' ';
                    }

                }


                else if (i % 2 == 1)
                {
                    for (int j = 0; j < Table.GetLength(1); j++)
                    {
                        if (j == 0 || j == 32) Table[i, j] = '|';
                        else Table[i, j] += ' ';

                    }

                }
            }





            //random lines
            for (int i = 1; i <= 90; i++)
            {
                int row = Random.Next(1, 18);
                int column = Random.Next(1, 32);


                if ((Table[row, column] == ' ')
                    && (row % 2 != column % 2))
                {
                    if (row % 2 == 0) Table[row, column] = '-';
                    else Table[row, column] = '|';
                }
                else i--;
            }

            //marking squares as ownerless
            int ownerless = 0;
            for (int row = 1; row < Table.GetLength(0); row += 2)
            {
                for (int column = 1; column < Table.GetLength(1); column += 2)
                {
                    if (((Table[row, column - 1] == '|') && (Table[row, column + 1] == '|')) &&
                        Table[row + 1, column] == '-' && Table[row - 1, column] == '-')
                    {
                        Table[row, column] = ':';
                        ownerless += 1;
                    }
                }

            }




            for (int i = 0; i < Table.GetLength(0); i++)
            {
                for (int j = 0; j < Table.GetLength(1); j++)
                {
                    Console.Write(Table[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("ownerless:" + ownerless);
            Console.ReadLine();




            int x = 2, y = 1;
            bool game = true;
            int roundCounter = 1;
            bool firstLineEver = true;
            bool firstsquareAI = true;
            int n = 0;
            int[] pointy = new int[n + 1];
            int[] pointx = new int[n + 1];
            //main game loop
            while (game)
            {
                bool stage1 = true;
                bool stage2 = true;
                Console.SetCursorPosition(38, 2);
                Console.Write("Stage 1, place lines to form squares.");
                Console.SetCursorPosition(38, 3);
                Console.Write("press enter if you want to move onto next stage");
                while (stage1) //bu while döngüsü human kare oluşturamadığı bir hamle yaptığında sona eriyor.
                {
                    Console.SetCursorPosition(x, y);

                    ConsoleKeyInfo info = Console.ReadKey();


                    if (info.Key == ConsoleKey.UpArrow & y > 1)
                    {
                        if (y % 2 == 1)
                        {
                            if (x != 32)
                            {
                                x += 1;
                                y -= 1;

                            }
                            else
                            {
                                x -= 1;
                                y -= 1;
                            }

                        }
                        else if (y % 2 == 0)
                        {
                            if (x != 1)
                            {
                                x -= 1;
                                y -= 1;
                            }
                            else
                            {
                                x += 1;
                                y -= 1;
                            }

                        }
                    }

                    else if (info.Key == ConsoleKey.DownArrow & y < 17)
                    {
                        if (y % 2 == 1)
                        {
                            if (x != 32)
                            {
                                x += 1;
                                y += 1;
                            }
                            else
                            {
                                x -= 1;
                                y += 1;
                            }
                        }
                        else if (y % 2 == 0)
                        {
                            if (x != 1)
                            {
                                x -= 1;
                                y += 1;
                            }

                            else
                            {
                                x += 1;
                                y += 1;
                            }
                        }
                    }

                    else if (info.Key == ConsoleKey.RightArrow & x < 31)
                    {
                        x += 2;
                    }

                    else if (info.Key == ConsoleKey.LeftArrow & x > 2)
                    {
                        x -= 2;
                    }

                    else if (info.Key == ConsoleKey.Spacebar)
                    {
                        bool penalty = false;
                        if (Table[y, x] == ' ')
                        {
                            //First line is special, it can't be neighbor to its previous square, because there isn't square before it
                            //so its case must be specified

                            //important note: # will be used to mark the last square the user has been formed, but it will never be displayed on the screen
                            if (firstLineEver)
                            {
                                if (y % 2 == 1)
                                {
                                    //placing the line
                                    Console.SetCursorPosition(x, y);
                                    Table[y, x] = '|';
                                    Console.Write(Table[y, x]);

                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    //checking if it formed a square and marking the square
                                    if ((Table[y, x + 2] == '|' && Table[y - 1, x + 1] == '-') && Table[y + 1, x + 1] == '-' && //forming two squares with one line
                                        ((Table[y, x - 2] == '|' && Table[y - 1, x - 1] == '-') && Table[y + 1, x - 1] == '-'))
                                    {

                                        Table[y, x - 1] = '#';
                                        Console.SetCursorPosition(x - 1, y);
                                        Console.Write("P");
                                        Console.SetCursorPosition(x + 1, y);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Table[y, x + 1] = ':';
                                        Console.Write(Table[y, x + 1]);

                                    }

                                    else if ((Table[y, x + 2] == '|' && Table[y - 1, x + 1] == '-') && Table[y + 1, x + 1] == '-')
                                    {
                                        Table[y, x + 1] = '#';
                                        Console.SetCursorPosition(x + 1, y);
                                        Console.Write("P");
                                    }

                                    else if ((Table[y, x - 2] == '|' && Table[y - 1, x - 1] == '-') && Table[y + 1, x - 1] == '-')
                                    {

                                        Table[y, x - 1] = '#';
                                        Console.SetCursorPosition(x - 1, y);
                                        Console.Write("P");
                                    }
                                    else
                                    {
                                        penalty = true;
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;


                                }

                                if (y % 2 == 0)
                                {


                                    //placing the line
                                    Console.SetCursorPosition(x, y);
                                    Table[y, x] = '-';
                                    Console.Write(Table[y, x]);


                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    if ((Table[y - 1, x - 1] == '|' && Table[y - 2, x] == '-' && Table[y - 1, x + 1] == '|') && //forming two squares with one lines
                                        (Table[y + 1, x - 1] == '|' && Table[y + 2, x] == '-' && Table[y + 1, x + 1] == '|'))
                                    {

                                        Table[y - 1, x] = '#';
                                        Console.SetCursorPosition(x, y - 1);
                                        Console.Write("P");
                                        Table[y + 1, x] = ':';
                                        Console.SetCursorPosition(x, y + 1);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(Table[y + 1, x]);

                                    }

                                    else if ((Table[y - 1, x - 1] == '|' && Table[y - 2, x] == '-') && Table[y - 1, x + 1] == '|')
                                    {
                                        Table[y - 1, x] = '#';
                                        Console.SetCursorPosition(x, y - 1);
                                        Console.Write("P");
                                    }

                                    else if ((Table[y + 1, x - 1] == '|' && Table[y + 2, x] == '-') && Table[y + 1, x + 1] == '|')
                                    {
                                        Table[y + 1, x] = '#';
                                        Console.SetCursorPosition(x, y + 1);
                                        Console.Write("P");
                                    }

                                    else
                                    {
                                        penalty = true;
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;
                                }


                                firstLineEver = false;
                            }



                            else
                            {
                                if (y % 2 == 1)
                                {
                                    //placing the line
                                    Table[y, x] = '|';
                                    Console.SetCursorPosition(x, y);
                                    Console.Write(Table[y, x]);



                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    if (Square(Table, x, y) == 1) //forming two squares with one line
                                    {

                                        if (IsItRegular(Table, x, y))
                                        {
                                            Table[y, x - 1] = '#';
                                            Console.SetCursorPosition(x - 1, y);
                                            Console.Write("P");
                                            Table[y, x + 1] = ':';
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.SetCursorPosition(x + 1, y);
                                            Console.Write(Table[y, x + 1]);


                                            SwitcthToP(Table, x, y);
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Table[y, x - 1] = ':';
                                            Console.SetCursorPosition(x - 1, y);
                                            Console.Write(Table[y, x - 1]);
                                            Table[y, x + 1] = ':';
                                            Console.SetCursorPosition(x + 1, y);
                                            Console.Write(Table[y, x + 1]);


                                            penalty = true;
                                        }


                                    }


                                    /*
                                     * -
                                     *  |
                                     * -
                                     * 
                                     */

                                    else if (Square(Table, x, y) == 3)

                                    {

                                        if (IsItRegular(Table, x, y))
                                        {
                                            Table[y, x + 1] = '#';
                                            Console.SetCursorPosition(x + 1, y);
                                            Console.Write("P");

                                            SwitcthToP(Table, x, y);
                                        }
                                        else
                                        {
                                            Table[y, x + 1] = ':';
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.SetCursorPosition(x + 1, y);
                                            Console.Write(Table[y, x + 1]);

                                            penalty = true;

                                        }
                                    }


                                    /*
                                     *  -
                                     * |
                                     *  -
                                     * 
                                     */





                                    else if (Square(Table, x, y) == 2)
                                    {

                                        if (IsItRegular(Table, x, y))
                                        {
                                            Table[y, x - 1] = '#';
                                            Console.SetCursorPosition(x - 1, y);
                                            Console.Write("P");

                                            SwitcthToP(Table, x, y);
                                        }

                                        else
                                        {
                                            Table[y, x - 1] = ':';
                                            Console.SetCursorPosition(x - 1, y);
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(":");



                                            penalty = true;
                                        }

                                    }

                                    else
                                    {
                                        penalty = true;
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;
                                }



                                //+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-
                                if (y % 2 == 0)
                                {
                                    //placing the line
                                    Console.SetCursorPosition(x, y);
                                    Table[y, x] = '-';
                                    Console.Write(Table[y, x]);






                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    if (Square(Table, x, y) == 4) //forming two squares with one line 
                                    {

                                        if (IsItRegular(Table, x, y))
                                        {
                                            Table[y - 1, x] = '#';
                                            Console.SetCursorPosition(x, y - 1);
                                            Console.Write("P");

                                            Table[y + 1, x] = ':';
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.SetCursorPosition(x, y + 1);
                                            Console.Write(Table[y + 1, x]);

                                            SwitcthToP(Table, x, y);
                                        }


                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Table[y - 1, x] = ':';
                                            Console.SetCursorPosition(x, y - 1);
                                            Console.Write(":");
                                            Table[y + 1, x] = ':';
                                            Console.SetCursorPosition(x, y + 1);
                                            Console.Write(Table[y + 1, x]);

                                            penalty = true;
                                        }

                                    }


                                    /*
                                     *  -
                                     * | |
                                     *  
                                     * 
                                     */

                                    else if (Square(Table, x, y) == 5)
                                    {

                                        if (IsItRegular(Table, x, y))
                                        {
                                            Table[y - 1, x] = '#';
                                            Console.SetCursorPosition(x, y - 1);
                                            Console.Write("P");

                                            SwitcthToP(Table, x, y);
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Table[y - 1, x] = ':';
                                            Console.SetCursorPosition(x, y - 1);
                                            Console.Write(":");

                                            penalty = true;

                                        }

                                    }

                                    /*
                                     * | |
                                     *  -
                                     * 
                                     * 
                                     */
                                    else if (Square(Table, x, y) == 6)

                                    {

                                        if (IsItRegular(Table, x, y))
                                        {
                                            Table[y + 1, x] = '#';
                                            Console.SetCursorPosition(x, y + 1);
                                            Console.Write("P");

                                            SwitcthToP(Table, x, y);
                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Table[y + 1, x] = ':';
                                            Console.SetCursorPosition(x, y + 1);
                                            Console.Write(":");


                                            penalty = true;
                                        }

                                    }
                                    else
                                    {
                                        penalty = true;
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;


                                }


                            }
                        }


                        //prevent the user from trying to place a line on a line
                        else
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(Table[y, x]);
                        }


                        if (penalty)
                        {
                            Console.SetCursorPosition(38, 1);
                            Console.Write("Penalty");
                            human_score -= 5;
                            stage1 = false;


                        }


                    }

                    else if (info.Key == ConsoleKey.Enter)
                    {
                        stage1 = false;
                    }


                    else//not to write an undesired character
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(Table[y, x]);
                    }


                }



                Console.SetCursorPosition(38, 2);
                Console.Write("                                                               ");
                Console.SetCursorPosition(38, 2);
                Console.Write("Stage 2, add one more line. It doesn't have to be regular.");
                Console.SetCursorPosition(38, 3);
                Console.Write("                                               ");

                while (stage2)
                {
                    Console.SetCursorPosition(x, y);

                    ConsoleKeyInfo info = Console.ReadKey();


                    if (info.Key == ConsoleKey.UpArrow & y > 1)
                    {
                        if (y % 2 == 1)
                        {
                            if (x != 32)
                            {
                                x += 1;
                                y -= 1;

                            }
                            else
                            {
                                x -= 1;
                                y -= 1;
                            }

                        }
                        else if (y % 2 == 0)
                        {
                            if (x != 1)
                            {
                                x -= 1;
                                y -= 1;
                            }
                            else
                            {
                                x += 1;
                                y -= 1;
                            }

                        }
                    }

                    else if (info.Key == ConsoleKey.DownArrow & y < 17)
                    {
                        if (y % 2 == 1)
                        {
                            if (x != 32)
                            {
                                x += 1;
                                y += 1;
                            }
                            else
                            {
                                x -= 1;
                                y += 1;
                            }
                        }
                        else if (y % 2 == 0)
                        {
                            if (x != 1)
                            {
                                x -= 1;
                                y += 1;
                            }

                            else
                            {
                                x += 1;
                                y += 1;
                            }
                        }
                    }

                    else if (info.Key == ConsoleKey.RightArrow & x < 31)
                    {
                        x += 2;
                    }

                    else if (info.Key == ConsoleKey.LeftArrow & x > 2)
                    {
                        x -= 2;
                    }

                    else if (info.Key == ConsoleKey.Spacebar)
                    {
                        if (Table[y, x] == ' ')
                        {
                            if ((y % 2) == 0)
                            {
                                Table[y, x] = '-';
                                Console.SetCursorPosition(x, y);
                                Console.Write(Table[y, x]);


                                //checking whether it shaped a square, and if it did, marking the square with :
                                if (Table[y - 1, x - 1] == '|' && Table[y - 2, x] == '-' && Table[y - 1, x + 1] == '|')
                                {
                                    Table[y - 1, x] = ':';
                                    Console.SetCursorPosition(x, y - 1);
                                    Console.Write(Table[y - 1, x]);
                                }

                                if (Table[y + 1, x - 1] == '|' && Table[y + 2, x] == '-' && Table[y + 1, x + 1] == '|')
                                {
                                    Table[y + 1, x] = ':';
                                    Console.SetCursorPosition(x, y + 1);
                                    Console.Write(Table[y + 1, x]);
                                }
                            }

                            else if (y % 2 == 1)
                            {
                                Table[y, x] = '|';
                                Console.SetCursorPosition(x, y);
                                Console.Write(Table[y, x]);


                                if (Table[y, x + 2] == '|' && Table[y - 1, x + 1] == '-' && Table[y + 1, x + 1] == '-')
                                {
                                    Table[y, x + 1] = ':';
                                    Console.SetCursorPosition(x + 1, y);
                                    Console.Write(Table[y, x + 1]);
                                }

                                if (Table[y, x - 2] == '|' && Table[y - 1, x - 1] == '-' && Table[y + 1, x - 1] == '-')
                                {
                                    Table[y, x - 1] = ':';
                                    Console.SetCursorPosition(x - 1, y);
                                    Console.Write(Table[y, x - 1]);
                                }
                            }

                            stage2 = false;
                        }


                        //preventing the user from trying to place a line on a line
                        else
                        {
                            Console.SetCursorPosition(x, y);
                            Console.Write(Table[y, x]);
                        }

                    }

                    //preventing the user from writing undesired characters
                    else
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write(Table[y, x]);
                    }
                }


                Console.SetCursorPosition(38, 1);
                Console.Write("                       ");
                Console.SetCursorPosition(38, 2);
                Console.Write("                                                                               ");
                Console.SetCursorPosition(38, 2);
                Console.Write("Stage 3.");

                stage3(Table, 3);
                stage3(Table, 2);
                stage3(Table, 1);


                Console.ForegroundColor = ConsoleColor.White;
                //computer AI
                char[,] temp = new char[1, 1];


                bool computerplay = true;
                int Cx = 0;
                int Cy = 0;
                if (firstsquareAI == true)
                {
                    int AIx = 8;
                    int AIy = 8;
                    // Choosing first square
                    while (AIx % 2 == AIy % 2 || Table[AIy, AIx] != ' ' || Square(Table, AIx, AIy) == 100)
                    {
                        AIx = Random.Next(2, 31);
                        AIy = Random.Next(2, 17);
                    }
                    try
                    {
                        for (int cy = 0; cy < Table.GetLength(0); cy++)
                        {
                            for (int cx = 0; cx < Table.GetLength(1); cx++)
                            {
                                if (cx % 2 == Cy % 2 || Table[cy, cx] != ' ' || Square(Table, cx, cy) == 100)
                                {
                                }
                                else
                                {
                                    pointx[n] = cx;
                                    pointy[n] = cy;

                                    n++;
                                }


                            }
                            Console.WriteLine();
                        }

                        for (int py = 0; py < pointy.Length; py++)
                        {
                            for (int px = 0; px < pointx.Length; px++)
                            {
                                if (AImovement(Table, px, py) != 0)
                                {
                                    Console.Write("(" + pointy[py] + "," + pointx[px] + ")");
                                }
                            }
                        }
                    }
                    catch (System.IndexOutOfRangeException)
                    {

                    }
                    Console.SetCursorPosition(AIx, AIy);
                    if (AIy % 2 == 0 && AIx % 2 == 1)
                    {
                        Table[AIy, AIx] = '-';
                    }
                    else
                    {
                        Table[AIy, AIx] = '|';
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Table[AIy, AIx]);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (Square(Table, AIx, AIy) == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Table[AIy, AIx - 1] = '*';
                        Cx = AIx - 1; Cy = AIy;
                        Console.SetCursorPosition(AIx - 1, AIy);
                        Console.WriteLine("C");
                        Table[AIy, AIx + 1] = ':';
                        Console.SetCursorPosition(AIx + 1, AIy);
                        Console.WriteLine(Table[AIy, AIx + 1]);

                    }
                    else if (Square(Table, AIx, AIy) == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Table[AIy, AIx - 1] = '*';
                        Cx = AIx - 1; Cy = AIy;
                        Console.SetCursorPosition(AIx - 1, AIy);
                        Console.WriteLine("C");

                    }
                    else if (Square(Table, AIx, AIy) == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Table[AIy, AIx + 1] = '*';
                        Cx = AIx + 1; Cy = AIy;
                        Console.SetCursorPosition(AIx + 1, AIy);
                        Console.WriteLine("C");
                    }
                    else if (Square(Table, AIx, AIy) == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Table[AIy - 1, AIx] = '*';
                        Cx = AIx; Cy = AIy - 1;
                        Console.SetCursorPosition(AIx, AIy - 1);
                        Console.WriteLine("C");
                        Table[AIy + 1, AIx] = ':';
                        Console.SetCursorPosition(AIx, AIy + 1);
                        Console.WriteLine(Table[AIy + 1, AIx]);

                    }
                    else if (Square(Table, AIx, AIy) == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Table[AIy - 1, AIx] = '*';
                        Cx = AIx; Cy = AIy - 1;
                        Console.SetCursorPosition(AIx, AIy - 1);
                        Console.WriteLine("C");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Table[AIy + 1, AIx] = '*';
                        Cx = AIx; Cy = AIy + 1;
                        Console.SetCursorPosition(AIx, AIy + 1);
                        Console.WriteLine("C");

                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    AImovement(Table, Cx, Cy);
                    Console.WriteLine(AImovement(Table, Cx, Cy));
                    temp[0, 0] = Table[Cy, Cy];
                    firstsquareAI = false;
                }

                //roundCounter++;


            }
        }
    }

}