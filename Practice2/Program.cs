using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Program
    {
        struct Student
        {
            public string Fio;
            public int NumberOfBook;
            public int[] GradeMark;

            public Student(string fio, int numberOfBook, int[] gradeMark)
            {
                Fio = fio;
                NumberOfBook = numberOfBook;
                GradeMark = gradeMark;
            }

            public void Input()
            {
                Console.Write("Введите ФИО студента : ");
                Fio = Console.ReadLine();
                Console.Write("Введите номер зачетки : ");
                NumberOfBook = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите оценки : ");
                GradeMark = new int[3];
                for (int i = 0; i < GradeMark.Length; i++)
                {
                    GradeMark[i] = int.Parse(Console.ReadLine());
                }
            }

            public void Output()
            {
                Console.Write("Студент : {0, -20} | Номер зачетки : {1, 10} | Оценки : ", Fio, NumberOfBook);
                for (int i = 0; i < GradeMark.Length; i++)
                {
                    Console.Write(GradeMark[i] + "  ");
                }
                
            }
        };

        static void Sort(Student[] students)
        {
            for (int i = 1; i < students.Length; i++)
            {
                for (int j = 0; j < students.Length - i; j++)
                {
                    if (String.Compare(students[j].Fio, students[j + 1].Fio, true) == 1)
                    {
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }

        static void Search(Student[] students)
        {
            bool flag = false;
            Console.WriteLine("Студенты с задолженностью : ");
            for (int i = 0; i < students.Length; i++)
            {
                for (int j = 0; j < students[i].GradeMark.Length; j++)
                {
                    if (students[i].GradeMark[j] < 4)
                    {
                        students[i].Output();
                        flag = true;
                        break;
                    }
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Нет студентов с задолженностью.");
            }
        }

        static void Main(string[] args)
        {
            Student[] stud1 = new Student[3];

            do
            {
                Console.WriteLine();
                Console.WriteLine("Меню : \n 1. Добавить студента. \n 2. Вывести всех студентов. \n 3. Вывести студентов с задолженностью.");
                Console.WriteLine(" 4. Выход. \n");
                Console.Write("Выбор : ");
                int select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        for (int i = 0; i < stud1.Length; i++)
                        {
                            stud1[i].Input();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Список студентов : ");
                        Sort(stud1);
                        for (int i = 0; i < stud1.Length; i++)
                        {
                            stud1[i].Output();
                        }
                        break;
                    case 3:
                        Search(stud1);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверный ввод функции меню.");
                        break;
                }
            }
            while (true);
        }
    }
}
