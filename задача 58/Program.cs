/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/


int GetNumber(string message)
{
    int result = 0;

    while (true)
    {
        Console.WriteLine(message);

        if (int.TryParse(Console.ReadLine(), out result) && result > 0)
            break;
        else
            Console.WriteLine("Вы ввелин не корректное число. Повторите ввод");
    }

    return result;
}

int[,] InitMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = rnd.Next(0, 10);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]} ");
        }
        System.Console.WriteLine();
    }
}



int[,] TooMatrixMultiplaer(int[,] matrix1, int[,] matrix2)
{

    int[,] matrixTemp = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix1.GetLength(1); j++)
        {
            for (int k = 0; k < matrix2.GetLength(0); k++)
            {
                matrixTemp[i, j] =matrixTemp[i, j]+ matrix1[i, k]*matrix2[k, j];
            }
         }
        }
      
    return matrixTemp;
}



Console.WriteLine("здравствуйте, задайте размеры матриц");
int rows = GetNumber("Введите количество строк: ");
int columns = GetNumber("Введите количество столбцов: ");
Console.WriteLine();
int[,] matrixOne = InitMatrix(rows, columns);
PrintMatrix(matrixOne);
Console.WriteLine();
int[,] matrixTwo = InitMatrix(rows, columns);
PrintMatrix(matrixTwo);
Console.WriteLine();
int[,] NewMatrix = TooMatrixMultiplaer(matrixOne, matrixTwo);
PrintMatrix(NewMatrix);






