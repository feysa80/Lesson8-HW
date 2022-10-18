// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
//Дополнительная задача 1(задача со звёздочкой): Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
//которая будет построчно выводить массив, добавляя индексы каждого элемента.
//Дополнительная задача 2 (задача со звёздочкой):. Напишите программу, которая заполнит спирально массив 4 на 4.
using System.Collections;
using System.Diagnostics.Metrics;

Console.Clear();
String task54 = "Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.";
String task56 = "Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.";
String task58 = "Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.";
String task1 = "Дополнительная задача 1(задача со звёздочкой): Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.";
String task2 = "Дополнительная задача 2 (задача со звёздочкой):. Напишите программу, которая заполнит спирально массив 4 на 4.(Сделала общее решение, для любого размера.)";
Console.WriteLine(task54);
Console.WriteLine(task56);
Console.WriteLine(task58);
Console.WriteLine(task1);
Console.WriteLine(task2);
Console.WriteLine("Введите номер задачи: ");
int task = Convert.ToInt32(Console.ReadLine());

switch (task)
{
    case 54:
        int[,] array54 = BeginTask(task54, 0, 10);
        PrintArray(array54);
        PrintArray(SortArray(array54));
        break;
    case 56:
        int[,] array56 = BeginTask(task56, 0, 100);
        PrintArray(array56);
        FindMinSum(array56);
        break;
    case 58:
        int[,] array1 = BeginTask(task58, 0, 10);
        Console.Write("Введите количество строк во стором массиве: ");
        int rows2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов во втором массиве: ");
        int columns2 = Convert.ToInt32(Console.ReadLine());
        int[,] array2 = FillArray(rows2, columns2, 0, 10);
        Console.WriteLine("Первый массив");
        PrintArray(array1);
        Console.WriteLine("Второй массив");
        PrintArray(array2);
        if (array1.GetLength(1) == array2.GetLength(0))
        {
            Console.WriteLine("Результат:");
            PrintArray(MultiplyArrays(array1, array2));

        }
        else
        {
            Console.WriteLine("Невозможно выполнить операцию. Число столбцов в первом массиве должно совпадать с количеством строк во втором массиве");
        }

        break;

    case 1:
        Console.Clear();
        Console.WriteLine(task1);
        Console.Write("Введите первый параметр размера массива: ");
        int sizeX = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второй параметр размера массива: ");
        int sizeY = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите третий параметр размера массива: ");
        int sizeZ = Convert.ToInt32(Console.ReadLine());
        int[,,] arrayTask1 = new int[sizeX, sizeY, sizeZ];
        if (arrayTask1.Length <= 90)
        {
            int[,,] resultArray = FillArray3D(sizeX, sizeY, sizeZ);
            PrintArray3D(resultArray);
        }
        else
        {
            Console.WriteLine("Размер массива не подходит для выполнения задания. Должно быть не более 90 элементов");
        }

        break;
    case 2:
        Task2();
        break;

    default:
        Console.WriteLine("Неправильный ввод");
        break;
}
int[,] MultiplyArrays(int[,] array1, int[,] array2)
{
    int rowsCount = array1.GetLength(0);
    int columnsCount = array1.GetLength(1);
    int columnsCount2 = array2.GetLength(1);
    int[,] resultArray = new int[rowsCount, columnsCount2];
    int sum = 0;
    for (int i = 0; i < rowsCount; i++)
    {
        for (int j = 0; j < columnsCount2; j++)
        {
            for (int k = 0; k < columnsCount; k++)
            {
                sum = sum + array1[i, k] * array2[k, j];
            }
            resultArray[i, j] = sum;
            sum = 0;
        }
    }
    return resultArray;
}
void FindMinSum(int[,] someArray)
{
    int sum = 0;
    int minSumRowNumber = 0;
    int[] arraySum = new int[someArray.GetLength(0)];
    for (int i = 0; i < someArray.GetLength(0); i++)
    {
        for (int j = 0; j < someArray.GetLength(1); j++)
        {
            sum = sum + someArray[i, j];
        }
        Console.WriteLine($"Сумма элементов в строке с индексом {i} равна {sum}");
        arraySum[i] = sum;
        sum = 0;
    }
    int minSum = arraySum[0];
    for (int i = 1; i < arraySum.Length; i++)
    {
        if (arraySum[i] < minSum)
        {
            minSum = arraySum[i];
            minSumRowNumber = i;
        }
    }
    Console.WriteLine($"Минимальная сумма в строке {minSumRowNumber}");
}
int[,] SortArray(int[,] someArray)
{
    int rowsNumber = someArray.GetLength(0);
    int columnsNumber = someArray.GetLength(1);
    int[] temp = new int[columnsNumber];
    for (int i = 0; i < rowsNumber; i++)
    {
        for (int j = 0; j < columnsNumber; j++)
        {
            temp[j] = someArray[i, j];
        }
        Array.Sort(temp);
        for (int k = 0; k < columnsNumber; k++)
        {
            someArray[i, k] = temp[columnsNumber - 1 - k];
        }
    }
    return someArray;
}
int[,] BeginTask(String taskName, int min, int max)
{
    Console.Clear();
    Console.WriteLine(taskName);
    Console.Write("Введите количество строк в массиве: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество столбцов в массиве: ");
    int columns = Convert.ToInt32(Console.ReadLine());
    int[,] startArray = FillArray(rows, columns, min, max);
    return startArray;

}
int[,] FillArray(int rows, int columns, int min, int max)
{
    int[,] filledArray = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            filledArray[i, j] = new Random().Next(min, max);
        }
    }
    return filledArray;
}
void PrintArray(int[,] someArray)
{
    for (int i = 0; i < someArray.GetLength(0); i++)
    {
        for (int j = 0; j < someArray.GetLength(1); j++)
        {
            Console.Write(someArray[i, j] + "\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
int[,,] FillArray3D(int x, int y, int z)
{
    int[,,] result = new int[x, y, z];
    List<int> numbers = FillListWithNumbers(10, 100);
    int index = 0;
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                result[i, j, k] = numbers[index];
                index++;
            }
        }
    }
    return result;
}
List<int> FillListWithNumbers(int min, int max)
{
    List<int> filledList = new List<int>();
    int index = 0;
    for (int i = min; i < max; i++)
    {
        filledList.Add(i);

    }
    Random rand = new Random();
    List<int> shuffled = filledList.OrderBy(_ => rand.Next()).ToList();
    return shuffled;

}
void PrintArray3D(int[,,] someArray)
{
    int x = someArray.GetLength(0);
    int y = someArray.GetLength(1);
    int z = someArray.GetLength(2);
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                Console.Write(someArray[i, j, k] + $"({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }

}
void Task2()
{
    Console.Clear();
    Console.WriteLine(task2);
    Console.Write("Введите размер квадратного массива: ");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.Write("Массив будет заполняться по спирали числами по возрастанию, введите первое число: ");
    int min = Convert.ToInt32(Console.ReadLine());
    int start = 0;
    int end = n - 1;
    int[,] array = new int[n, n];
    int count = array.Length;
    while (count > 0)
    {
        for (int i = start; i <= end; i++)
        {
            array[start, i] = min;
            min++;
            count--;
        }
        start++;
        for (int i = start; i <= end; i++)
        {
            array[i, end] = min;
            min++;
            count--;
        }
        start--;
        end--;
        for (int i = end; i >= start; i--)
        {
            array[end + 1, i] = min;
            min++;
            count--;
        }
        for (int i = end; i > start; i--)
        {
            array[i, start] = min;
            min++;
            count--;
        }
        start++;
    }
    Console.WriteLine();
    PrintArray(array);
}
