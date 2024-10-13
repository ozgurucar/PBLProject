using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;


Random rnd = new Random();

int gameMode;
double turn = 0;

String a1 = initializeBoard();
String a2 = initializeBoard();
String a3 = initializeBoard();
String a4 = initializeBoard();
String a5 = initializeBoard();
String a6 = initializeBoard();
String a7 = initializeBoard();
String a8 = initializeBoard();
String a9 = initializeBoard();
String allStrings = a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9;

int initialPoints = calculateAllBoard(a1,a2,a3,a4,a5,a6,a7,a8,a9);
int pointsOfHuman = initialPoints;
int pointsOfComputer = initialPoints;



    int calculateAllBoard(String l1, String l2, String l3, String l4, String l5, String l6, String l7, String l8, String l9)
    {
        int points = 0;
        points += calculatePoints(l1 + l2 + l3);
        points += calculatePoints(l4 + l5 + l6);
        points += calculatePoints(l7 + l8 + l9);

        points += calculatePoints(l1 + l4 + l7);
        points += calculatePoints(l2 + l5 + l8);
        points += calculatePoints(l3 + l6 + l9);

        points += calculatePoints(l1 + l5 + l9);
        points += calculatePoints(l3 + l5 + l7);

        return points;
    }

    // Initiliaze Board
    String initializeBoard()
    {

        String letters = "DEU";
        String colorRepresentations = " ._";
        int randomLetter = rnd.Next(0, 3);
        int randomColor = rnd.Next(0, 3);
        String returnValue;
        returnValue = letters[randomLetter].ToString() + colorRepresentations[randomColor].ToString();
        return returnValue;
    }

    void printTheBoard()
    {
        Console.WriteLine("");
        Console.WriteLine("    1" + "  2" + "  3");
        Console.WriteLine("  +----------+");
        Console.WriteLine("1 " + "| " + a1 + " " + a2 + " " + a3 + " |");
        Console.WriteLine("2 " + "| " + a4 + " " + a5 + " " + a6 + " |");
        Console.WriteLine("3 " + "| " + a7 + " " + a8 + " " + a9 + " |");
        Console.WriteLine("  +----------+");
        Console.WriteLine("");
        Console.WriteLine("Board Score: " + getBoardScore());

    }


    void humanPlayChanger(int row, int col, String Letter, String Color)
    {
        int location = row * col;
        if (Color == "B")
        {
            Color = "_";
        }
        else if (Color == "G")
        {
            Color = ".";
        }
        else if (Color == "R")
        {
            Color = " ";
        }

        if (location == 1)
        {
            a1 = Letter.ToString() + Color.ToString();
        }
        else if (location == 2)
        {
            a2 = Letter.ToString() + Color.ToString();
        }
        else if (location == 3)
        {
            a3 = Letter.ToString() + Color.ToString();
        }
        else if (location == 4)
        {
            a4 = Letter.ToString() + Color.ToString();
        }
        else if (location == 5)
        {
            a5 = Letter.ToString() + Color.ToString();
        }
        else if (location == 6)
        {
            a6 = Letter.ToString() + Color.ToString();
        }
        else if (location == 7)
        {
            a7 = Letter.ToString() + Color.ToString();
        }
        else if (location == 8)
        {
            a8 = Letter.ToString() + Color.ToString();
        }
        else if (location == 9)
        {
            a9 = Letter.ToString() + Color.ToString();
        }

    }

    int calculatePoints(String toCalculate)
    {
        String toCalculateLetters = toCalculate[0].ToString() + toCalculate[2].ToString() + toCalculate[4].ToString();
        String toCalculateColors = toCalculate[1].ToString() + toCalculate[3].ToString() + toCalculate[5].ToString();
        int colorCheck;
        int point = 0;

        if (toCalculateColors.Count(c => c == '_') == 3 || toCalculateColors.Count(c => c == '.') == 3 || toCalculateColors.Count(c => c == ' ') == 3)
        {
            colorCheck = 0;
        }
        else if (toCalculateColors.Count(c => c == '_') == 1 && toCalculateColors.Count(c => c == '.') == 1 && toCalculateColors.Count(c => c == ' ') == 1)
        {
            colorCheck = 1;
        }
        else
        {
            colorCheck = 2;
        }


        if (toCalculateLetters == "DEU" || toCalculateLetters == "UED")
        {
            if (colorCheck == 0)
            {
                point = 120;
            }
            else if (colorCheck == 1)
            {
                point = 110;
            }
            else
            {
                point = 100;
            }
        }
        else if (toCalculateLetters.Contains('D') && toCalculateLetters.Contains('E') && toCalculateLetters.Contains('U'))
        {
            if (colorCheck == 0)
            {
                point = 90;
            }
            else if (colorCheck == 1)
            {
                point = 80;
            }
            else
            {
                point = 70;
            }
        }
        else if (toCalculateLetters == "DDD" || toCalculateLetters == "EEE" || toCalculateLetters == "UUU")
        {
            if (colorCheck == 0)
            {
                point = 60;
            }
            else if (colorCheck == 1)
            {
                point = 50;
            }
            else
            {
                point = 40;
            }
        }
        else
        {
            if (colorCheck == 0)
            {
                point = 30;
            }
            else if (colorCheck == 1)
            {
                point = 20;
            }
            else
            {
                point = 0;
            }
        }
        //Console.WriteLine(point);
        return point;
    }

    void AIPlay()
    {
        int tryCount = 0;



        int max = calculateAllBoard(a1, a2, a3, a4, a5, a6, a7, a8, a9);
        String maxString = "";
        int maxLocation = -1;



        switch (gameMode)
        {
            case 0:
                tryCount = 25; break;
            case 1:
                tryCount = 50; break;
            case 2:
                tryCount = 100; break;
        }


        for (int i = 0; i < tryCount; i++)
        {

            String tryStr = initializeBoard();

            String b1 = a1;
            String b2 = a2;
            String b3 = a3;
            String b4 = a4;
            String b5 = a5;
            String b6 = a6;
            String b7 = a7;
            String b8 = a8;
            String b9 = a9;
            int location = rnd.Next(1, 10);
            if (location == 1)
            {
                b1 = tryStr;
                if (calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9) > max)
                {
                    max = calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9);
                    maxString = tryStr;
                    maxLocation = location;

                }
            }

            else if (location == 2)
            {
                b2 = tryStr;
                if (calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9) > max)
                {
                    max = calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9);
                    maxString = tryStr;
                    maxLocation = location;

                }
            }

            else if (location == 3)
            {
                b3 = tryStr;
                if (calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9) > max)
                {
                    max = calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9);
                    maxString = tryStr;
                    maxLocation = location;

                }
            }

            else if (location == 4)
            {
                b4 = tryStr;
                if (calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9) > max)
                {
                    max = calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9);
                    maxString = tryStr;
                    maxLocation = location;

                }
            }

            else if (location == 5)
            {
                b5 = tryStr;
                if (calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9) > max)
                {
                    max = calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9);
                    maxString = tryStr;
                    maxLocation = location;

                }
            }

            else if (location == 6)
            {
                b6 = tryStr;
                if (calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9) > max)
                {
                    max = calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9);
                    maxString = tryStr;
                    maxLocation = location;

                }
            }

            else if (location == 7)
            {
                b7 = tryStr;
                if (calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9) > max)
                {
                    max = calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9);
                    maxString = tryStr;
                    maxLocation = location;

                }
            }

            else if (location == 8)
            {
                b8 = tryStr;
                if (calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9) > max)
                {
                    max = calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9);
                    maxString = tryStr;
                    maxLocation = location;

                }
            }

            else if (location == 9)
            {
                b9 = tryStr;
                if (calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9) > max)
                {
                    max = calculateAllBoard(b1, b2, b3, b4, b5, b6, b7, b8, b9);
                    maxString = tryStr;
                    maxLocation = location;

                }
            }



            if (i == (tryCount - 1))
            {
                if (maxLocation == 1)
                {
                    a1 = maxString;
                }
                else if (maxLocation == 2)
                {
                    a2 = maxString;
                }
                else if (maxLocation == 3)
                {
                    a3 = maxString;
                }
                else if (maxLocation == 4)
                {
                    a4 = maxString;
                }
                else if (maxLocation == 5)
                {
                    a5 = maxString;
                }
                else if (maxLocation == 6)
                {
                    a6 = maxString;
                }
                else if (maxLocation == 7)
                {
                    a7 = maxString;
                }
                else if (maxLocation == 8)
                {
                    a8 = maxString;
                }
                else if (maxLocation == 9)
                {
                    a9 = maxString;
                }


            }
        }
        int currentBoard = calculateAllBoard(a1, a2, a3, a4, a5, a6, a7, a8, a9);
        pointsOfComputer += currentBoard;

    }

    void humanPlay()
    {
        Console.Write("Enter row: ");
        int row = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter row: ");
        int col = Convert.ToInt32(Console.ReadLine());
        Console.Write("Letter: ");
        String letter = Console.ReadLine()!;
        Console.Write("Color: ");
        String color = Console.ReadLine()!;

        humanPlayChanger(row, col, letter, color);
        int currentBoard = calculateAllBoard(a1, a2, a3, a4, a5, a6, a7, a8, a9);
        pointsOfHuman += currentBoard;

    }

    int getBoardScore()
{
    return calculateAllBoard(a1, a2, a3, a4, a5, a6, a7, a8, a9);
}
void printTurn() {
    Console.WriteLine("");
    Console.WriteLine("    1" + "  2" + "  3");
    Console.WriteLine("  +----------+");
    Console.WriteLine("1 " + "| " + a1 + " " + a2 + " " + a3 + " |" + "H.Score: " + pointsOfHuman);
    Console.WriteLine("2 " + "| " + a4 + " " + a5 + " " + a6 + " |" + "C.Score: " + pointsOfComputer);
    Console.WriteLine("3 " + "| " + a7 + " " + a8 + " " + a9 + " |");
    Console.WriteLine("  +----------+");
    Console.WriteLine("");
}

Console.WriteLine("Game Mode:");
Console.WriteLine("");
Console.WriteLine("1.Easy");
Console.WriteLine("2.Moderate");
Console.WriteLine("3.Hard");
Console.WriteLine("");
Console.Write("Enter the game mode: ");
gameMode = Convert.ToInt32(Console.ReadLine());

while (turn <= 10)
{
    if (turn == 0)
    {

        Console.WriteLine("");
        Console.WriteLine("---- Initial Board ----");
        printTheBoard();
    }
    else
    {
        if (turn % 2 == 1)
        {
            Console.WriteLine("");
            Console.WriteLine("---- Round " + Math.Ceiling(turn / 2) + " ----" + "Turn: Human");
            pointsOfHuman -= 10;
            printTurn();
            humanPlay();
            printTurn();
            getBoardScore();
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("---- Round " + Math.Ceiling(turn / 2) + " ----" + "Turn: Computer");
            pointsOfComputer -= 10;
            printTurn();
            AIPlay();
            printTurn();
            getBoardScore();

        }
    }
    turn++;
}