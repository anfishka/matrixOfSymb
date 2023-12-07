bool IsValid(int val)
{
    return val >= 2 && val <= 10;
}

int ValidateInput(string message)
{
    int size;
    bool isValid = false;

    do
    {
        Console.WriteLine(message);
        size = int.Parse(Console.ReadLine());
        isValid =  IsValid(size);

        if (!isValid)
        {
            Console.WriteLine("Invalid size of matrix! Please enter correct values");
        }
    } while (!isValid);

    return size;
}


int rowSize = ValidateInput("Enter size of matrix for rows (from 2 to 20)");
int collSize = ValidateInput("Enter size of matrix for colls (from 2 to 20)");


Random randomVals = new Random();

char[,] matrix2D = new char[rowSize, collSize];

Console.WriteLine($"\nArray rank:{matrix2D.Rank}");
Console.WriteLine($"1D size: {matrix2D.GetLength(0)}");
Console.WriteLine($"2D size: {matrix2D.GetLength(1)}\n");

for (int i = 0; i < rowSize; i++)
{
    for (int j = 0; j < collSize; j++)
    {
        char randomChar;
        bool isUnique;

        do
        {
            isUnique = true;
            randomChar = (char)randomVals.Next(32, 128);

            for (int k = 0; k < i && isUnique; k++)
            {
                for (int l = 0; l < collSize; l++)
                {
                    if (matrix2D[k,l] == randomChar)
                    {
                        isUnique = false;
                        break;
                    }
                }
            }
        } while (!isUnique);

    matrix2D[i, j] = randomChar;

    }
}

for (int i = 0; i < rowSize; i++)
{
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = ConsoleColor.Magenta;

    for (int j = 0; j < collSize; j++)
    {
        if (matrix2D[i,j] % 2 == 0)
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        Console.Write($"{matrix2D[i, j]}");
       

        if (j != matrix2D.GetLength(1) - 1)
            Console.Write("  ");
    }
    Console.WriteLine();
   

}
Console.BackgroundColor = ConsoleColor.Black;
Console.ForegroundColor = ConsoleColor.White;

