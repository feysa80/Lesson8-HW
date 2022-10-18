// Дополнительная задача 2 (задача со звёздочкой):. Напишите программу, которая заполнит спирально массив 4 на 4.


Console.Clear();
Console.Write("Введите размер квадратного массива: ");
int n = Convert.ToInt32(Console.ReadLine());
Console.Write("Массив будет заполняться по спирали числами по возрастанию, введите первое число: ");
int min = Convert.ToInt32(Console.ReadLine());
int start = 0;
int end = n - 1;
int [,] array = new int[n,n];
int count = array.Length;
while(count > 0){
    for(int i = start; i <= end; i++){
        array[start,i] = min;
        min++;
        count --;
    }
    start ++;
    for(int i = start; i <= end; i++ ){
        array[i,end] = min;
        min++;
        count--;
    }
    start--;
    end --;
    for(int i = end; i >= start; i--){
        array[end+1, i] = min;
        min++;
        count --;
    }
    for(int i = end; i > start; i--){
        array[i, start] = min;
        min++;
        count--;
    }
    start++;
}
Console.WriteLine();
 for(int i = 0; i < n; i++){
     for(int j = 0; j < n; j++){
        Console.Write(array[i,j] + "\t");
    }
    Console.WriteLine();
 }
