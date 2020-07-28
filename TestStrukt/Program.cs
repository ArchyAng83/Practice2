using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStrukt
{
    class Program
    {
        struct Student
        {
            public string Fio;            
            public int[] GradeMark;

            public Student(string fio, int[] gradeMark)
            {
                Fio = fio;                
                GradeMark = gradeMark;
            }

            public void Input()
            {
                Console.Write("Введите ФИО студента : ");
                Fio = Console.ReadLine();                
                GradeMark = new int[3];// исправить на 5
                Console.WriteLine("Введите оценки : ");
                for (int i = 0; i < GradeMark.Length; i++)
                {
                    GradeMark[i] = int.Parse(Console.ReadLine());
                }

                StreamWriter studentsData = new StreamWriter("data.txt", true);
                studentsData.Write("{0, -20}  ", Fio);
                for (int i = 0; i < GradeMark.Length; i++)
                {
                    studentsData.Write("|{0, 2}", GradeMark[i]);
                }
                studentsData.WriteLine();
                studentsData.Close();

            }

            public void Output()
            {
                StreamReader studentsData1 = new StreamReader("data.txt");
                studentsData1.DiscardBufferedData();
                studentsData1.BaseStream.Position = 0;
                string s;
                while ((s = studentsData1.ReadLine()) != null)
                {
                    string[] elements = s.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    Fio = elements[0];                    
                    for (int i = 0; i < GradeMark.Length; i++)
                    {
                        GradeMark[i] = int.Parse(elements[i + 1]);
                    }
                    Console.Write("{0, -20}\t", Fio);
                    for (int i = 0; i < GradeMark.Length; i++)
                    {
                        Console.Write("{0, 2}", GradeMark[i]);
                    }
                    Console.WriteLine();
                }
                studentsData1.Close();
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
            
            Student stud1 = new Student();

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
                        stud1.Input();
                        break;
                    case 2:
                        Console.WriteLine("Список студентов : ");
                        //Sort(stud1.Fio);

                        stud1.Output();                        
                        break;
                    //case 3:
                    //    Search(stud1);
                    //    break;
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
