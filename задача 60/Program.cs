/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
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

int[,,] InitMatrix(int rows, int columns, int depth)
{
    int[,,] matrix = new int[rows, columns, depth];
    Random rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = 0; k < depth; k++)
            {
                matrix[i, j, k] = rnd.Next(0, 100);

            }
        }
    }
    return matrix;
}

Dictionary<int, int> GetDictionery(int[,,] matrix)
{
    Dictionary<int, int> Slovar = new Dictionary<int, int>();

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int l = 0; l < matrix.GetLength(2); l++)
            {

                if (Slovar.ContainsKey(matrix[i, j, l]))
                {
                    Slovar[matrix[i, j, l]] = Slovar[matrix[i, j, l]] + 1;
                }
                else
                {
                    Slovar.Add(matrix[i, j, l], 1);
                }
            }
        }
    }
    return Slovar;
}

bool GetCheker(int[,,] matrix, Dictionary<int, int> Slovar)
{
    bool temp = true;
    foreach (var item in Slovar.OrderBy(x => x.Key))
    {
        if (item.Value > 1)
        {
            temp = false;
        }
    }

    return temp;
}


void PrintMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int l = 0; l < matrix.GetLength(2); l++)
            {
                Console.Write($"{matrix[i, j, l]}({i},{j},{l})  ");

            }
            System.Console.WriteLine();
        }

    }
}





int rows = GetNumber("Введите количество строк: ");
int columns = GetNumber("Введите количество столбцов: ");
int depth = GetNumber("Введите высоту: ");

if ((rows * columns * depth) < 100)
{
    int[,,] matrix = InitMatrix(rows, columns, depth);
    Dictionary<int, int> Slovar = GetDictionery(matrix);

    while (true)
    {
        if (GetCheker(matrix, Slovar))
        {
            break;
        }
        else
        {
            matrix = InitMatrix(rows, columns, depth);
            Slovar = GetDictionery(matrix);
        }
    }

    PrintMatrix(matrix);
    Console.WriteLine();
}
else
{
    System.Console.WriteLine("Уникальность элементов матрицы невозможна.");
    System.Console.WriteLine("Запустите программу заново и задайте меньшие измерения для матрицы");
}






