using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console22App2
{
    class Program
    {
        static bool CheckLogAndPass(string login, string password)  // Для 4 задания
        {
            if (login == "root" && password == "GeekBrains")
                return true;
            else
                return false;
        }

        static string CheckNorm(double imt, double heigth) // для 5 задания
        {
            string result = "";
            if (imt >= 18.5 && imt <= 24.99)
            {
                result = "Всё в норме!";
            }
            else if (imt < 18.5)
            {
                double recommendation = (18.5 - imt) * heigth * heigth;
                result = String.Format("Необходимо набрать {0:0.00} кг для нормализации веса!", recommendation);
            }
            else if (imt > 24.99)
            {
                double recommendation = (imt - 24.99) * heigth * heigth;
                result = String.Format("Необходимо сбросить {0:0.00} кг для нормализации веса!", recommendation);
            }

            return result;
        }

        static void PrintFromTo(int start, int end) // для 7 задания
        {
            if (start == end)
            {
                return;
            }
            else
            {
                Console.Write(start + ", ");
                start++;
                PrintFromTo(start, end);
            }
        }

        static long SumFromTo(int start, int end, long res)
        {
            if (start == end) return res;
            else
            {
                res += start;
                start++;
                return SumFromTo(start, end, res);
            }
        }

        static void Main(string[] args)
        {

            // Автор: Николай Ильичев

            // 1. Написать метод, возвращающий минимальное из трёх чисел.

            Console.WriteLine("1. Определим минимальное из трех чисел: ");
            Console.Write("Введите первое число: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите третье число: ");
            int c = Convert.ToInt32(Console.ReadLine());

            if (a < b && a < c)
            {
                Console.WriteLine("Минимальное значение: " + a);
            }
            else
            {
                if (b < c)
                {
                    Console.WriteLine("Минимальное значение: " + b);
                }
                else
                {
                    Console.WriteLine("Минимальное значение: " + c);
                }
            }

            // Console.WriteLine((a < b && a < c) ? a : ((b < c) ? b : c));
            Console.ReadLine();


            // 2. Написать метод подсчета количества цифр числа


            Console.WriteLine("2. Подсчитаем количество цифр числа: ");
            Console.WriteLine("Введите многозначное число: ");
            String s = Convert.ToString(Console.ReadLine());

            int i = s.Length;
            Console.WriteLine("В числе " + s + " " + i + " цифр");
            Console.ReadLine();


            // 3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.


            Console.WriteLine("3. Подсчитаем количество нечетных положительных чисел: ");
            Console.WriteLine("Вводите числа по одному, для завершения введите 0: ");

            int count = 0;
            while (true)
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number == 0)
                {
                    break;
                }
                else if (number > 0 && number % 2 == 1)
                {
                    count++;
                }
            }

            Console.WriteLine("Количество  нечетных положительных чисел: " + count);

            Console.ReadLine();


            // 4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.
            // На выходе истина, если прошел авторизацию, и ложь, если не прошел(Логин: root, Password: GeekBrains). 
            // Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, 
            // программа пропускает его дальше или не пропускает.С помощью цикла do while ограничить ввод пароля тремя попытками.


            Console.WriteLine("4. Проверка логина и пароля, у Вас 3 попытки: ");

            int TryCounts = 3;

            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();

                if (CheckLogAndPass(login, password) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Успешная авторизация");
                    break;
                }
                else
                {
                    TryCounts--;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Неверный ввод логина или пароля." + " У Вас осталось " + TryCounts + " попыток");
                }
                if ((TryCounts) == 0) ;
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Авторизация не пройдена");
                }

            } while (TryCounts > 0);


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Продолжаем дальше: ");
            Console.ReadLine();


            // 5. а) Написать программу, которая запрашивает массу и рост человека, 
            // вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
            // 5. б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.

            #region Info IMT
            //Индекс массы тела  / Соответствие между массой человека и его ростом
            //16 и менее  Выраженный дефицит массы тела
            //16—18,5 Недостаточная(дефицит) масса тела
            //18,5—25 Норма
            //25—30   Избыточная масса тела(предожирение)
            //30—35   Ожирение
            //35—40   Ожирение резкое
            //40 и более  Очень резкое ожирение
            #endregion

            double height;
            double weight;
            Console.WriteLine("5. Рассчитаем индекс массы тела (ИМТ): ");
            Console.WriteLine("Рост в сантиметрах: ");
            height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Вес в килограммах: ");
            weight = Convert.ToDouble(Console.ReadLine());
            height = height / 100;
            double imt = Convert.ToDouble(weight / (height * height));
            Console.Write("Индекс массы тела " + ("{0:0.00}"), imt);
            Console.WriteLine(" (Норма 18.5 - 25)");
            Console.WriteLine(CheckNorm(imt, height));
            Console.ReadLine();


            // 6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
            // «Хорошим» называется число, которое делится на сумму своих цифр.
            // Реализовать подсчёт времени выполнения программы, используя структуру DateTime.




            // 7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
            // 7. б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.


            Console.WriteLine("7. Рекурсивный подсчет чисел от a до b (a < b): ");
            Console.WriteLine("Введите число а: ");
            int a1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число b: ");
            int b1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nЧисла, входящие в промежуток: ");
            PrintFromTo(a1, b1);
            Console.WriteLine("\nСумма чисел: " + SumFromTo(a1, b1, 0));
            Console.ReadLine();

            string txt = ("Благодарю за внимание!!! С Уважением, Н. Ильичев");
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth/2 - txt.Length/2, Console.WindowHeight/2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(txt);
            Console.ReadLine();


        }
    }
}
