// Задача 60. ...
// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.

// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

void PrintArray(int[] matrix)
{
    Console.Write("[");
    for (int i = 0; i < matrix.Length; i++)
    {
        if (i < matrix.Length - 1) Console.Write($"{matrix[i],4},");
        else Console.Write($"{matrix[i],4} ");
    }
    Console.WriteLine("]");

}

int[] CreateIntRndNumFor3DMatrix(int minNum, int maxNum)
{
    int[] resource = new int[((maxNum + 1) - minNum)];
    for (int i = 0; i < resource.Length; i++)
    {
        resource[i] = minNum + i;
    }
    return resource;
}

int[,,] Create3DMatrixRndInt(int row, int col, int zol) // Метод создания Трехмерного массива
{
    int[,,] matrix3d = new int[row, col, zol];
    Random rnd = new Random(); // Создаем объект рандом
    int[] array = CreateIntRndNumFor3DMatrix(10, 99);
    int saveIndexNum = -1;
    int newIndexNum = 0;
    int element = 0;
    PrintArray(array);
    if ((row * col * zol) > array.Length)
    {
        Console.WriteLine("Задайте больший интервал чисел!");
        Console.WriteLine("Недостаточно элементов для заполнения матрицы");
        return matrix3d;
    }
    else
    {
        for (int i = 0; i < matrix3d.GetLength(0); i++) // Забираем количество строк в матрице
        {
            for (int j = 0; j < matrix3d.GetLength(1); j++) // Забираем количество столбцов матрицы
            {
                for (int k = 0; k < matrix3d.GetLength(2); k++) // Забираем глубину матрицы
                {
                    if (saveIndexNum == -1) 
                    {
                        newIndexNum = rnd.Next(0, array.Length);
                        element = array[newIndexNum];
                        array[newIndexNum] = array[0];
                        array[0] = element;
                        saveIndexNum = 0;
                    }
                    else 
                    {
                        newIndexNum = rnd.Next(saveIndexNum + 1, array.Length);
                        element = array[newIndexNum];
                        array[newIndexNum] = array[saveIndexNum + 1];
                        array[saveIndexNum + 1] = element;
                        saveIndexNum++;
                    }
                    matrix3d[i, j, k] = element;
                }
            }
        }
        return matrix3d;
    }

}

void Print3DMatrixIndexes(int[,,] matrix3d)
{
    for (int i = 0; i < matrix3d.GetLength(0); i++)
    {
        for (int j = 0; j < matrix3d.GetLength(1); j++)
        {
            for (int k = 0; k < matrix3d.GetLength(2); k++)
            {
                Console.Write($"{matrix3d[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
}

// int[] array = CreateIntRndNumFor3DMatrix(45, 68);
// PrintArray(array);

int[,,] matrix3D = Create3DMatrixRndInt(10, 2, 2);
Print3DMatrixIndexes(matrix3D);

// int[] array = CreateIntRndNumFor3DMatrix(45, 68);
// PrintArray(array);