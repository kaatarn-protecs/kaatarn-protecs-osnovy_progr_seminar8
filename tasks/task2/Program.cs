// Задача 55: 
// Задайте двумерный массив. 
// Напишите программу,которая заменяет строки на столбцы. 
// В случае, если это невозможно, 
// программа должна вывести сообщение для пользователя.

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

int[,] ReplaceRowColMatrix(int[,] matrix)
{
    int size = matrix.GetLength(1);
    int[,] matrixTemp = new int[matrix.GetLength(0),matrix.GetLength(1)];

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            matrixTemp[i, j] = matrix[j, i];
        }
    }
    return matrixTemp;
}

int[,] newMatrix = CreateMatrixRndInt(3, 3, 1, 9);
PrintMatrix(newMatrix);
Console.WriteLine();

int[,] repMatrix = ReplaceRowColMatrix(newMatrix);
PrintMatrix(repMatrix);