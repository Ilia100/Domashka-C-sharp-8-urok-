/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/



double[,] InitMatrix()
{
    int rows =4;
    int columns =4;
    double[,] matrix = new double[rows, columns];
    matrix[0, 0] = 1;

    for (int i = 0; i <  2; i++)
    {
        for (int l = 0 + i; l < rows - rows + 1 + i; l++)
        {
            for (int j = 1; j < columns - i; j++)
            {
                matrix[l, j] = matrix[l, j - 1] + 1;
            }
        }
        for (int l = 1; l < rows - i; l++)
        {

            for (int j = columns - 1 - i; j < columns - i; j++)
            {
                if(i>0) matrix[l, j] = matrix[l , j-1] + 1;
                else matrix[l, j] = matrix[l - 1, j] + 1;
            }

        }
        for (int l = rows - 1 - i; l > rows - 2 - i; l--)
        {

            for (int j = columns - 2; j >= 0 + i; j--)
            {
                if(i>0) matrix[l, j] = matrix[l-1, j ] + 1;
                else matrix[l, j] = matrix[l, j + 1] + 1;
            }

        }
        for (int l = rows - 2; l >= 1 + i; l--)
        {

            for (int j = 0+i; j < 1+i; j++)
            {
                if(i>0) matrix[l, j] = matrix[l , j+1] + 1;
              else
                matrix[l, j] = matrix[l + 1, j] + 1;

            }

        }
    }
    return matrix;
}



void PrintMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j]<10)  Console.Write($"0{matrix[i, j]} ");
            else Console.Write($"{matrix[i, j]} ");
        }
        System.Console.WriteLine();
    }
}

Console.WriteLine();
double[,] matrix = InitMatrix();
PrintMatrix(matrix);
Console.WriteLine();



