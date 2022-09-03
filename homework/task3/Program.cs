// Задача 58: 
// Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.

// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3

// Результирующая матрица будет:
// 18 20
// 15 18

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

int[,] MultiplicMatrix(int[,] fMatrix, int[,] sMatrix)
{
    int rows = fMatrix.GetLength(0);
    int cols = fMatrix.GetLength(1);
    int cols2 = sMatrix.GetLength(1);
    int[,] resMatrix = new int[rows, cols2];
    int res = 0;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols2; j++)
        {   
            res = 0;
            for (int k = 0; k < cols; k++)
            {
                res += fMatrix[i, k] * sMatrix[k, j];
            }
            resMatrix[i, j] = res;
        }

    }
    return (resMatrix);
}

int[,] fmMatrix = CreateMatrixRndInt(5, 7, 1, 10);
int[,] smMatrix = CreateMatrixRndInt(7, 8, 1, 10);

if (fmMatrix.GetLength(1) != smMatrix.GetLength(0) ) Console.WriteLine("Матрицы не согласованы! Умножение невозможно");
else
{
PrintMatrix(fmMatrix);
Console.WriteLine();
PrintMatrix(smMatrix);

int[,] resMatrix = MultiplicMatrix(fmMatrix, smMatrix);
Console.WriteLine();
PrintMatrix(resMatrix);
}



