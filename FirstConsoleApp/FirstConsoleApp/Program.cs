using FirstConsoleApp;

OperatorExamples();
LoopExamples();
TryAnIf();
TrySomeLoops();
TryAnIfElse();

void OperatorExamples()
{
    int width = 3;
    width++;

    int height = 2 + 4;
    int area = width * height;
    Console.WriteLine(area);

    while (area < 50)
    {
        height++;
        area = width * height;
    }

    do
    {
        width--;
        area = width * height;
    } while (area > 25);

    string result = "The area";
    result = result + " is " + area;
    Console.WriteLine(result);

    bool truthValue = true;
    Console.WriteLine(truthValue);
}


void LoopExamples()
{
    // Loop #1
    int count = 5;
    while (count > 0)
    {
        count = count * 3;
        count = count * -1;
    }
    // Loop 1 is runs once
    // count = 5, count = 15, count = -15
    // fails condition

    // Loop #2
    int j = 2;
    for (int i = 1; i < 100;
     i = i * 2)
    {
        j = j - 1;
        while (j < 25)
        {
            // How many times will
            // the next statement
            // be executed?
            j = j + 5;
        }
        // A: 1:j=6, 2:j=11, 3:j=16 4:j=21, 5:j=26. Breaks
        // Outter i loop, runs 7 times, 1, 2, 4, 8, 16, 32, 64, 128
        // during i loop, j loop runs one more time due to j = j-1, for a total of 7 times
    }

    // Loop #3
    int p = 2;
    for (int q = 2; q < 32;
     q = q * 2)
    {
        while (p < q)
        {
            // How many times will
            // the next statement
            // be executed?
            p = p * 2;
        }
        q = p - q;
    }
    // p & q = 2 first run, so while loop doesnt execute, then p - q = 0,
    // total of 8 executes as q gets reset to 0, then q gets set to p value as p - 0 = p


    // Loop #4
    //int i = 0;
    //int count2 = 2;
    //while (i == 0)
    //{
    //    count2 = count2 * 3;
    //    count2 = count2 * -1;
    //}
    // infinite loop

    // Loop #5
    //while (true) { int k = 1; }
    // infinite loop
}

void TryAnIf()
{
    int someValue = 4;
    string name = "Bobbo Jr.";
    if ((someValue == 3) && (name == "Joe"))
    {
        Console.WriteLine("x is 3 and the name is Joe");
    }
    Console.WriteLine("This line runs no matter what");
}

void TryAnIfElse()
{
    int x = 5;
    if (x ==10)
    {
        Console.WriteLine("x must be 10");
    }
    else
    {
        Console.WriteLine("x isn't 10");
    }
}

void TrySomeLoops()
{
    int count = 0;
    while (count < 10)
    {
        count = count + 1;
    }

    for (int i = 0; i < 5; i++)
    {
        count = count - 1;
    }

    Console.WriteLine("The answer is " + count);
}


//Chapter 3: Sharpen your pencil exercise p163

double[] randomDoubles = new double[20];
for (int i = 0; i < 20; i++)
{
    double value = Random.Shared.NextDouble();
    randomDoubles[i] = value;
}


Guy joe = new Guy();
joe.Name = "Joe";
joe.Cash = 50;

Guy bob = new Guy();
bob.Name = "Bob";
bob.Cash = 50;

joe.WriteMyInfo();
joe.GiveCash(25);
bob.ReceiveCash(25);


// object initializer
Guy mark = new Guy() { Name = "Mark", Cash = 50 };

TradeMoney();

void TradeMoney()
{
    while (true)
    {
        Console.WriteLine("Time to Trade Money!");
        Guy[] guys = [joe, bob, mark];
        foreach (Guy guy in guys)
        {
            guy.WriteMyInfo();
        }
        Console.Write("Enter an amount: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int amount))
        {
            Console.WriteLine("Invalid amount");
            continue;
        }

        Guy? giverGuy = null;
        while (true)
        {
            Console.Write("Who should give the cash? ");
            string? giver  = Console.ReadLine();
            giverGuy = guys.FirstOrDefault(g => g.Name == giver);
            if (giverGuy != null)
            {
                break; // valid name
            }
            else
            {
                Console.WriteLine($"{giver} is not in guys!");
            }
        }

        Guy? receiverGuy = null;
        while (true)
        {
            Console.Write("Who should receive the cash? ");
            string? receiver = Console.ReadLine();
            receiverGuy = guys.FirstOrDefault(g => g.Name == receiver);
            if (receiverGuy == null)
            {
                Console.WriteLine($"{receiver} is not in guys!");
            }
            else if (giverGuy == receiverGuy) 
            {
                Console.WriteLine($"{receiver} can't give himself money");
            }
            else
            {
                break; // valid name
            }
        }

        if (giverGuy.GiveCash(amount) <= 0)
        {
            Console.WriteLine("Invalid trade...");
            Console.WriteLine("Try again");
        }
        else
        {
            receiverGuy.ReceiveCash(amount);
        }
        
    }
}

/*
Chapter 4 Console Exercise p 202
*/

float myFloatValue = 10;
int myIntValue = (int)myFloatValue;
Console.WriteLine("myIntValue is " + myIntValue);
// Cannot implicitly convert type 'float' to 'int'. An explicit conversion exists (are you missing a cast?)

/*
Chapter 4 Console Exercise p 203
Comment out type casting that isnt allowed
*/
int myInt = 10;
byte myByte = (byte)myInt;
double myDouble = (double)myByte;
// bool myBool = (bool)myDouble;
string myString = "false";
// myBool = (bool)myString;
//myString = (string)myInt;
myString = myInt.ToString();
//myBool = (bool)myByte;
//myByte = (byte)myBool;
short myShort = (short)myInt;
char myChar = 'x';
//myString = (string)myChar;
long myLong = (long)myInt;
decimal myDecimal = (decimal)myLong;
myString = myString + myInt + myByte +
myDouble + myChar;