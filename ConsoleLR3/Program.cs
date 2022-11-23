using System;

namespace ConsoleLR3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDeque deque = new MyDeque();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    Console.WriteLine($"Введите {i + 1}-е целочисленное число:");
                    int number = int.Parse(Console.ReadLine());
                    deque.AddLastNode(number);
                }
                catch(Exception)
                {
                    Console.WriteLine($"Введите {i + 1}-е ЦЕЛОЧИСЛЕННОЕ ЧИСЛО:");
                    int number = int.Parse(Console.ReadLine());
                    deque.AddLastNode(number);
                }            
            }
            while (true)
            {
                Console.WriteLine("\nВведите:\n1 - для просмотра всех элементов дэка" +
               "\n2 - для вставки элемента в начало" +
               "\n3 - для вставки элемента в конец" +
               "\n4 - для удаления элемента в начале" +
               "\n5 - для удаления элемента в конце" +
               "\n6 - для очистки дека" +
               "\n7 - для удаления максимального элемента");
                int number = 0;
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        deque.Show();
                        break;
                    case 2:
                        Console.WriteLine("Введите число для добавления:");
                        number = int.Parse(Console.ReadLine());
                        deque.AddFirstNode(number);
                        Console.WriteLine("Элемент добавлен!");
                        break;
                    case 3:
                        Console.WriteLine("Введите число для добавления:");
                        number = int.Parse(Console.ReadLine());
                        deque.AddLastNode(number);
                        Console.WriteLine("Элемент добавлен!");
                        break;
                    case 4:
                        deque.RemoveFirstNode();
                        Console.WriteLine("Элемент удалён!");
                        break;
                    case 5:
                        deque.RemoveLastNode();
                        Console.WriteLine("Элемент удалён!");
                        break;
                    case 6:
                        deque.Clear();
                        Console.WriteLine("Дек полностью очищен!");
                        break;
                    case 7:
                        deque.RemoveMaxNode();
                        Console.WriteLine("Элемент удалён!");
                        break;
                    default:
                        Console.WriteLine("Функция на данную кнопку не найдена");
                        break;
                }
            }
        }
        class MyDequeNode
        {
            public int Value;
            public MyDequeNode Prev { get; set; }
            public MyDequeNode Next { get; set; }

            public MyDequeNode(int value)
            {
                Value = value;
            }
        }
        class MyDeque
        {
            MyDequeNode Head;
            MyDequeNode Tail;
            int Count;

            public void AddFirstNode(int value)
            {
                MyDequeNode node = new MyDequeNode(value);
                MyDequeNode tmp = Head;
                node.Next = tmp;
                Head = node;
                if (Count == 0)
                    Tail = Head;
                else
                    tmp.Prev = node;
                Count++;
            }
            public void AddLastNode(int value)
            {
                MyDequeNode node = new MyDequeNode(value);
                if (Head == null)
                    Head = node;
                else
                {
                    Tail.Next = node;
                    node.Prev = Tail;
                }
                Tail = node;
                Count++;
            }
            public void RemoveFirstNode()
            {
                if (Count == 0)
                    Console.WriteLine("Дек пуст!");
                int number = Head.Value;
                if (Count == 1)
                    Head = Tail = null;
                else
                {
                    Head = Head.Next;
                    Head.Prev = null;
                }
                Count--;
            }
            public void RemoveLastNode()
            {
                if (Count == 0)
                    Console.WriteLine("Дек пуст!");
                int number = Head.Value;
                if (Count == 1)
                    Head = Tail = null;
                else
                {
                    Tail = Tail.Prev;
                    Tail.Next = null;
                }
                Count--;
            }
            public void Show()
            {
                Console.WriteLine("Вывод всех элементов однонаправленного списка:");
                MyDequeNode tmp = Head;
                while (tmp != null)
                {
                    Console.Write(tmp.Value + " ");
                    tmp = tmp.Next;
                }
            }
            public void RemoveMaxNode()
            {
                if (Count == 0)
                    Console.WriteLine("Дек пуст!");
                else
                {
                    int max = int.MinValue;
                    MyDequeNode node = Head;

                    while (node != null)
                    {
                        if (max < node.Value)
                            max = node.Value;
                        node = node.Next;
                    }
                    node = Head;
                    while (node.Value != max)
                        node = node.Next;
                    MyDequeNode tmp = node;

                    if (Count == 1)
                    {
                        Head = Tail = null;
                        Count--;
                    }

                    else if (node == Head)
                    {
                        Head = Head.Next;
                        Head.Prev = null;
                        Count--;
                    }

                    else if (node == Tail)
                    {
                        Tail = Tail.Prev;
                        Tail.Next = null;
                        Count--;
                    }

                    else
                    {
                        tmp = node.Next;
                        node = node.Prev;
                        node.Next = tmp;
                        Count--;
                    }
                }              
            }
            public void Clear()
            {
                while(Head != null)
                    RemoveLastNode();
            }
        }
    }
}

