// Задача 59: 
// Задайте двумерный массив из целых чисел.
// Напишите программу, которая удалит строку и столбец, на
// пересечении которых расположен наименьший элемент
// массива.

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

int[,] matrix = CreateMatrixRndInt(3, 3, 1, 9);

int row = matrix.GetLength(0);
int col = matrix.GetLength(1);

int[] FindElementMatrix(int[,] matrix)
{
    int minIndexRow = 0;
    int minIndexCol = 0;
    int min = matrix[0, 0];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < min)
            {
                min = matrix[i, j];
                minIndexRow = i;
                minIndexCol = j;
            }
        }
    }
    int[] arr = new int[2] { minIndexRow, minIndexCol };
    return arr;
}

int[,] ReduceMatrix(int[,] matrix, int rows, int cols, int[] minRowColIndex)
{
    int[,] reduceMatrix = new int[rows - 1, cols - 1];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (i == minRowColIndex[0]) i++;
        else
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j == minRowColIndex[1]) j++;
                else reduceMatrix[i, j] = matrix[i, j];
            }
        }
    }
    return reduceMatrix;
}

PrintMatrix(matrix);

int[] findElement = FindElementMatrix(matrix);

Console.WriteLine();

int[,] reduceMatrix = ReduceMatrix(matrix, row, col, findElement);
PrintMatrix(reduceMatrix);