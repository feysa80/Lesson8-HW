// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.


Console.Clear();
String task54 = "Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.";
String task56 = "Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.";
String task58 = "Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.";
Console.WriteLine(task54);
Console.WriteLine(task56);
Console.WriteLine(task58);
Console.WriteLine("Введите номер задачи: ");
int task = Convert.ToInt32(Console.ReadLine());

switch (task){
    case 54:
        int[,] array54 = BeginTask(task54,0,10);
        PrintArray(array54);
        PrintArray(SortArray(array54));
        break;
    case 56:
        int[,] array56 = BeginTask(task56, 0, 100);
        PrintArray(array56);
        FindMinSum(array56);
        break;
    case 58:
        int[,] array1 = BeginTask(task58,0,10);
        Console.Write("Введите количество строк во стором массиве: ");
        int rows2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите количество столбцов во втором массиве: ");
        int columns2 = Convert.ToInt32(Console.ReadLine());
        int[,] array2 = FillArray(rows2, columns2, 0, 10);
        Console.WriteLine("Первый массив");
        PrintArray(array1);
        Console.WriteLine("Второй массив");
        PrintArray(array2);
        if(array1.GetLength(1) == array2.GetLength(0)){
            Console.WriteLine("Результат:");
            PrintArray(MultiplyArrays(array1, array2));
        
    } else {
        Console.WriteLine("Невозможно выполнить операцию. Число столбцов в первом массиве должно совпадать с количеством строк во втором массиве");
    }
        
        break;
    default: Console.WriteLine("Неправильный ввод");
        break;
}
int[,] MultiplyArrays(int[,] array1, int[,] array2){
    int rowsCount = array1.GetLength(0);
    int columnsCount = array1.GetLength(1);
    int columnsCount2 = array2.GetLength(1);
    int[,] resultArray = new int[rowsCount,columnsCount2];
    int sum = 0;
    for(int i = 0; i < rowsCount; i++){
        for(int j=0; j < columnsCount2; j++){
            for(int k = 0; k < columnsCount; k++){
                sum = sum + array1[i,k]*array2[k,j];
            }
            resultArray[i,j] = sum;
            sum = 0;
        }
    }
    return resultArray;
}
void FindMinSum(int[,] someArray){
    int sum = 0;
    int minSumRowNumber = 0;
    int[] arraySum = new int[someArray.GetLength(0)];
    for(int i = 0; i < someArray.GetLength(0); i++){
        for(int j =0; j < someArray.GetLength(1); j++){
            sum = sum + someArray[i,j];
        }
      Console.WriteLine($"Сумма элементов в строке с индексом {i} равна {sum}");
      arraySum[i] = sum;
      sum = 0;
    }
    int minSum = arraySum[0];
    for(int i = 1; i < arraySum.Length; i++){
        if(arraySum[i] < minSum) {
            minSum = arraySum[i]; 
            minSumRowNumber = i;
        }
    }
    Console.WriteLine($"Минимальная сумма в строке {minSumRowNumber}");
}
int[,] SortArray(int[,] someArray){
    int rowsNumber = someArray.GetLength(0);
    int columnsNumber = someArray.GetLength(1);
    int[] temp = new int[columnsNumber];
    for(int i = 0 ; i < rowsNumber; i ++){
       for(int j = 0; j < columnsNumber; j++){
            temp[j] = someArray[i,j];
       }
       Array.Sort(temp);
       for(int k = 0; k < columnsNumber; k++){
        someArray[i,k] = temp[columnsNumber-1-k];
       }
    }
    return someArray;
}
int[,] BeginTask(String taskName, int min, int max){
    Console.Clear();
    Console.WriteLine(taskName);
    Console.Write("Введите количество строк в массиве: ");
    int rows = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите количество столбцов в массиве: ");
    int columns = Convert.ToInt32(Console.ReadLine());
    int[,] startArray = FillArray(rows, columns, min, max);
    return startArray;
    
}
int[,] FillArray(int rows, int columns, int min, int max){
    int[,] filledArray = new int[rows, columns];
    for(int i = 0; i < rows; i ++){
        for (int j = 0; j < columns; j++){
            filledArray[i,j] = new Random().Next(min, max);
        }
    }
    return filledArray;
}
void PrintArray(int[,] someArray){
    for(int i = 0; i < someArray.GetLength(0); i++){
        for(int j = 0; j < someArray.GetLength(1); j++){
            Console.Write(someArray[i,j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}
