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