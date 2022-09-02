// Урок 8. Как не нужно писать код. Часть 2
// Задача 54: Задайте двумерный массив. 
// Напишите программу, которая упорядочит по убыванию 
// элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

void SortMatrixDescending(int[,] matr)
{
    int rows = matr.GetLength(0);
    int cols = matr.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
           for (int k = 0; k < cols; k++)
           {
                if (matr[i, j] <= matr[i, k]) continue;
                int temp = matr[i, j];
                matr[i, j] = matr[i, k];
                matr[i, k] = temp;
           }
        }
    }
}

int[,] matrix = CreateMatrixRndInt(5, 4, 1, 10);

PrintMatrix(matrix);

SortMatrixDescending(matrix);
Console.WriteLine();

PrintMatrix(matrix);