using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;


Random rnd = new Random();

int gameMode;
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

String row1 = a1 + a2 + a3;
String row2 = a4 + a5 + a6;
String row3 = a7 + a8 + a9;

String col1 = a1 + a4 + a7;
String col2 = a2 + a5 + a8;
String col3 = a3 + a6 + a9;

String diagonal1 = a1 + a5 + a9;
String diagonal2 = a3 + a5 + a7;

int initialPoints = calculateAllBoard();
int pointsOfHuman = initialPoints;
int pointsOfComputer = initialPoints;

int calculateAllBoard()
{
    int points = 0;
    points += calculatePoints(row1);
    points += calculatePoints(row2);
    points += calculatePoints(row3);

    points += calculatePoints(col1);
    points += calculatePoints(col2);
    points += calculatePoints(col3);

    points += calculatePoints(diagonal1);
    points += calculatePoints(diagonal2);

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
    int max = -1;
    int tryCount = 0;
    switch (gameMode)
    {
        case 0:
            tryCount = 25; break;
        case 1:
            tryCount = 50; break;
        case 2:
            tryCount = 100; break;
    }

    for(int i = 0; i < tryCount; i++)
    {
        String allStrings = a1 + a2 + a3+ a4 + a5+ a6 + a7 + a8 + a9;
        int randomPoint = rnd.Next(1, 10);

        int tempPoint = -1;
        String tempLetter = "";

        String randomLetter = initializeBoard();
        switch(randomPoint)
        {
            case 1: 
                a1 = randomLetter; break;
            case 2:
                a2 = randomLetter; break;
            case 3:
                a3 = randomLetter; break;
            case 4:
                a4 = randomLetter; break;
            case 5:
                a5 = randomLetter; break;
            case 6:
                a6 = randomLetter; break;
            case 7:
                a7 = randomLetter; break;
            case 8:
                a8 = randomLetter; break;
            case 9:
                a9 = randomLetter; break;
        }
        max = calculateAllBoard();
    }

    }