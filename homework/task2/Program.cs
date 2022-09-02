// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

void PrintArray(int[] array)
{
    Console.Write("[");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1) Console.Write($"{array[i]},");
        else Console.Write(array[i]);
    }
    Console.WriteLine("]");
}

int[,] CreateMatrixRndInt(int row, int col, int min, int max) // Метод создания двумерного массива
{
    int[,] matrix = new int[row, col];
    Random rnd = new Random(); // Создаем объект рандом

    for (int i = 0; i < matrix.GetLength(0); i++) // Забираем количество строк в матрице
    {
        for (int j = 0; j < matrix.GetLength(1); j++) // Забираем количество столбцов матрицы
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i, j],4},");
            else Console.Write($"{matrix[i, j],4} ");
        }
        Console.WriteLine("]");
    }
}

void SearchMinElementRow(int[,] matr)
{
    int rows = matr.GetLength(0);
    int cols = matr.GetLength(1);
    int[] temp = new int[rows];
    for (int i = 0; i < rows; i++)
    {
        int strSum = 0;
        for (int j = 0; j < cols; j++)
        {
            strSum += matr[i, j];
        }
        temp[i] = strSum;
    }
    Console.Write("Максимумы по строкам: ");
    PrintArray(temp);

    int min = temp[0];
    int minIndex = 0;
    for (int t = 0; t < temp.Length; t++)
    {
        if (temp[t] <= min)
        {
            min = temp[t];
            minIndex = t + 1;
        }
    }
    Console.WriteLine($"Номер строки с мин. суммой элементов -> {minIndex} строка");
}

int[,] matrix = CreateMatrixRndInt(6, 6, 1, 10);

PrintMatrix(matrix);

// SortMatrixDescending(matrix);
Console.WriteLine();

SearchMinElementRow(matrix);
