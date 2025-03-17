using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberApp
{
    public class GuessNumber
    {
        public int Number { get; private set; }
        public int CounterAttempts { get; private set; } = 0;

        public GuessNumber()
        {
            Random rand = new Random();
            Number = rand.Next(1, 101);
        }

        public void NewGame()
        {
            int oldNum = Number;

            Random rand = new Random();
            Number = rand.Next(1, 101);
            CounterAttempts = 0;

            if (oldNum == Number) 
            {
                if (oldNum > 15) Number -= 14; 
                else Number += 14;
            }

        }
        public bool CheckNumber(int userNumber)
        {
            ++CounterAttempts;
            
            if (userNumber == Number)
                return true;

            return false;
        }

        public string GetHint(int userNumber)
        {
            if (userNumber < Number)
            {
                return "Більше!";
            }
            else if (userNumber > Number)
            {
                return "Менше!";
            }

            return "Числа однакові";
        }

    }
}
