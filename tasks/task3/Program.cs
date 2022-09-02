// Задача 57: 
// Составить частотный словарь элементов
// двумерного массива. 
// Частотный словарь содержит
// информацию о том, сколько раз 
// встречается элемент входных данных

void PrintArray(int[] array)
{
    Console.Write("[ ");
    for (int i = 0; i < array.Length; i++)
    {
        if (i < array.Length - 1) Console.Write($"{array[i]}, ");
        else Console.Write(array[i]);
    }
    Console.Write(" ]");
    Console.WriteLine();
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

int[,] matrix = CreateMatrixRndInt(3, 3, 1, 9);

int row = matrix.GetLength(0);
int col = matrix.GetLength(1);

int[] matrixNew = new int[row * col];

void ConvertMatrixToArray(int[,] matrix, int[] array)
{
    int count = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            array[count] = matrix[i,j];
            count++;
        }
    }
}

void CountElemNum(int[] array)
{
    int temp = array[0];
    int count = 1;
    for (int i = 1; i < array.Length; i++)
    {
        if (array[i] == temp) 
        {
            count++;
        }
        else
        {
            Console.WriteLine($"{temp} встречается {count} раз");
            temp = array[i];
            count = 1;
        }
    }
    Console.WriteLine($"{temp} встречается {count} раз");
    
}

PrintMatrix(matrix);
Console.WriteLine();

ConvertMatrixToArray(matrix, matrixNew);
PrintArray(matrixNew);

Array.Sort(matrixNew);
PrintArray(matrixNew);

CountElemNum(matrixNew);