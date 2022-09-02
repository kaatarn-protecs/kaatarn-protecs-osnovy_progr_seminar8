// Задача 53: 
// Задайте двумерный массив. 
// Напишите программу,которая поменяет местами 
// первую и последнюю строку массива.



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

void ReplaceMatrix(int[,] matrix)
{   
    int temp = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        temp = matrix[0,j];
        matrix[0,j] = matrix[matrix.GetLength(0) - 1, j];
        matrix[matrix.GetLength(0) - 1, j] = temp;
    }
}

int[,] newMatrix = CreateMatrixRndInt(6, 6, 1, 9);
PrintMatrix(newMatrix);
Console.WriteLine();

ReplaceMatrix(newMatrix);
PrintMatrix(newMatrix);