using System.Threading.Tasks;

int task;

string task1 = "1. Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.";
string task2 = "2. Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных индексах.";
string task3 = "3. Найдите произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д. Результат запишите в новом массиве.";
int SelectionTask()
{
    Console.WriteLine(task1);
    Console.WriteLine(task2);
    Console.WriteLine(task3);
    Console.Write("Выберите задачу (от 1 до 3): ");
    if (!int.TryParse(Console.ReadLine(), out int task) || task > 3 || task < 1)
    {
        Console.Clear();
        task = SelectionTask();
    }
    return task;
}

int SetLengthArray()
{
    Console.Write("Введите длину массива: ");
    if (!int.TryParse(Console.ReadLine(), out int number) || number < 0) number = SetLengthArray();
    return number;
}

int[] SetArray(int count, int minValue = 0, int maxValue = 2)
{
    int[] Array = new int[count];
    var rand = new Random();
    for (int i = 0; i < count; i++)
    {
        Array[i] = rand.Next(minValue, maxValue);
    }
    return Array;
}

//Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.

int CountEven(int[] array)
{
    int count = 0;
    foreach (int item in array)
    {
        if (item % 2 != 0) count++;
    }
    return count;
}


//Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных индексах.

int SumOddIndex(int[] array)
{
    int sum = 0;
    for (int i = 1; i < array.Length; i += 2)
    {
        sum += array[i];
    }
    return sum;
}



// Найдите произведение пар чисел в одномерном массиве. Парой считаем первый и последний элемент, второй и предпоследний и т.д. Результат запишите в новом массиве.


int[] MultiplicationOppElements(int[] array)
{
    int length = (array.Length + 1) / 2;
    int[] MultArray = new int[length];
    for (int i = 0; i < length; i++)
    {
        MultArray[i] = array[i] * array[array.Length - 1 - i];
    }
    return MultArray;
}


//--------------------------------------------
while (true)
{
    Console.Clear();
    task = SelectionTask();
    if (task == 1)
    {
        int length = SetLengthArray();
        int[] array = SetArray(length, 100, 1000);
        Console.WriteLine(String.Join(" ", array));
        Console.WriteLine($"Количество чётных чисел в массиве: {CountEven(array)}");
    }
    else if (task == 2)
    {
        int length = SetLengthArray();
        int[] array = SetArray(length, 0, 10000);
        Console.WriteLine(String.Join(" ", array));
        Console.WriteLine($"Сумма чисел с нечётным индексом в массиве: {SumOddIndex(array)}");
    }
    else if (task == 3)
    {
        int length = SetLengthArray();
        int[] array = SetArray(length, 0, 10);
        Console.WriteLine(String.Join(" ", array));
        Console.WriteLine($"Массив состоящий из произведения противоположных элементов массиве: {String.Join(" ", MultiplicationOppElements(array))}");
        Console.WriteLine("*В случае нечётного количества элементов средний возводится в квадрат.");
    }
    Console.WriteLine("Нажмите Enter для продолжения...");
    Console.ReadLine();
}
