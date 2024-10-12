using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;


Random rnd = new Random();

int gameMode = 2;
int turn = 1;

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

AIPlay();

int calculateAllBoard(String l1, String l2, String l3, String l4, String l5, String l6, String l7, String l8, String l9)
{
    int points = 0;
    points += calculatePoints(l1+l2+l3);
    points += calculatePoints(l4+l5+l6);
    points += calculatePoints(l7+l8+l9);

    points += calculatePoints(l1+l4+l7);
    points += calculatePoints(l2+l5+l8);
    points += calculatePoints(l3+l6+l9);

    points += calculatePoints(l1+l5+l9);
    points += calculatePoints(l3+l5+l7);

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

    

Console.WriteLine(a1 + a2 + a3);
Console.WriteLine(a4 + a5 + a6);
Console.WriteLine(a7 + a8 + a9);

Console.WriteLine(pointsOfComputer);

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
        Console.WriteLine(max + maxString + " " + maxLocation);

    }
    }