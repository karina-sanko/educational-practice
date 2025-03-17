using System.Text;

namespace GuessNumberApp
{
    class Program
    {
        public static bool IsNewGame()
        {
            Console.Write("Почати нову гру? 1 - так, інше - ні: ");
            if (int.TryParse(Console.ReadLine(), out int number) && number == 1)
            {
                return true;
            }

            return false;
        }

        public static void Main()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            GuessNumber guessNumber = new GuessNumber();

            while (true)
            {
                Console.Write("Введіть число від 1 до 100 (або -1, щоб здатися): ");
                if (int.TryParse(Console.ReadLine(), out int userNumber))
                {
                    if (userNumber == -1)
                    {
                        Console.WriteLine("Загадане число: " + guessNumber.Number);
                        Console.WriteLine();

                        if (IsNewGame())
                        {
                            Console.WriteLine("Нову гру розпочато!");
                            guessNumber.NewGame();
                        }
                        else break;
                    }
                    else if(guessNumber.CheckNumber(userNumber))
                    {
                        Console.WriteLine($"Ура ура! Ви перемогли за {guessNumber.CounterAttempts} спроб!");
                        Console.WriteLine();

                        if (IsNewGame())
                        {
                            Console.WriteLine("Нову гру розпочато!");
                            guessNumber.NewGame();
                        }
                        else break;
                    }
                    else
                    {
                        Console.WriteLine(guessNumber.GetHint(userNumber));
                        Console.WriteLine("Кількість використаних спроб: " + guessNumber.CounterAttempts);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
