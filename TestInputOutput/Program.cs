using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestInputOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            string fio, s;
            int numberOfBook;
            int[] GradeMark;
            Console.Write("Введите ФИО студента : ");
            fio = Console.ReadLine();
            Console.Write("Введите номер зачетки : ");
            numberOfBook = int.Parse(Console.ReadLine());
            GradeMark = new int[3];// исправить на 5
            Console.WriteLine("Введите оценки : ");
            for (int i = 0; i < GradeMark.Length; i++)
            {
                GradeMark[i] = int.Parse(Console.ReadLine());
            }

            StreamWriter studentsData = new StreamWriter("data.txt", true);
            studentsData.Write("{0, -20}|{1, 10}  ", fio, numberOfBook);
            for (int i = 0; i < GradeMark.Length; i++)
            {
                studentsData.Write("|{0, 2}", GradeMark[i]);
            }
            studentsData.WriteLine();
            studentsData.Close();

            StreamReader studentsData1 = new StreamReader("data.txt");
            
            while ((s = studentsData1.ReadLine()) != null)
            {
                string[] elements = s.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                fio = elements[0];
                numberOfBook = int.Parse(elements[1]);
                for (int i = 0; i < GradeMark.Length; i++)
                {
                    GradeMark[i] = int.Parse(elements[i + 2]);
                }
                Console.Write("{0, -20}\t{1, 10}\t", fio, numberOfBook);
                for (int i = 0; i < GradeMark.Length; i++)
                {
                    Console.Write("{0, 2}", GradeMark[i]);
                }
                Console.WriteLine();
            }
            studentsData1.Close();

            Console.ReadKey();
        }
    }
}
