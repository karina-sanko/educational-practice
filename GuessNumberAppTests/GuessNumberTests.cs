using GuessNumberApp;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GuessNumberAppTests
{
    public class GuessNumberTests
    {
        [Fact]
        public void GuessNumber_CreateGuessNumber_NumberInRange()
        {
            // Arrange
            GuessNumber guessNumber = new GuessNumber();
            
            // Assert
            Assert.InRange(guessNumber.Number, 1, 100);
        }

        [Fact]
        public void NewGame_StartNewGame_NumberInRange()
        {
            // Arrange
            GuessNumber guessNumber = new GuessNumber();

            // Act
            guessNumber.NewGame();

            // Assert
            Assert.InRange(guessNumber.Number, 1, 100);
        }

        [Fact]
        public void GuessNumber_EnterCorrectNumber_UserWin()
        {
            // Arrange
            GuessNumber guessNumber = new GuessNumber();
            int number = guessNumber.Number;

            // Assert
            Assert.True(guessNumber.CheckNumber(number));
            Assert.Equal("Числа однакові", guessNumber.GetHint(number));
        }

        [Fact]
        public void GuessNumber_EnterBelowNumber_NumberBelow()
        {
            // Arrange
            GuessNumber guessNumber = new GuessNumber();
            int number = guessNumber.Number - 1;

            // Assert
            Assert.False(guessNumber.CheckNumber(number));
            Assert.Equal("Більше!", guessNumber.GetHint(number));
        }

        [Fact]
        public void GuessNumber_EnterHigherNumber_NumberHigher()
        {
            // Arrange
            GuessNumber guessNumber = new GuessNumber();
            int number = guessNumber.Number + 1;

            // Assert
            Assert.False(guessNumber.CheckNumber(number));
            Assert.Equal("Менше!", guessNumber.GetHint(number));
        }

        [Fact]
        public void CheckNumber_NotGuessFewTimes_AttemptsIncrease()
        {
            // Arrange
            GuessNumber guessNumber = new GuessNumber();
            int number = guessNumber.Number + 1;

            // Act
            guessNumber.CheckNumber(number);
            guessNumber.CheckNumber(number);
            guessNumber.CheckNumber(number);

            // Assert
            Assert.Equal(3, guessNumber.CounterAttempts);
        }

        [Fact]
        public void NewGame_StartNewGame_AttemptsReset()
        {
            // Arrange
            GuessNumber guessNumber = new GuessNumber();
            int number = guessNumber.Number + 1;

            // Act
            guessNumber.CheckNumber(number);
            guessNumber.CheckNumber(number);
            guessNumber.CheckNumber(number);

            guessNumber.NewGame();

            // Assert
            Assert.Equal(0, guessNumber.CounterAttempts);
        }

        [Fact]
        public void NewGame_StartNewGame_NumberChanged()
        {
            // Arrange
            GuessNumber guessNumber = new GuessNumber();
            int oldNumber = guessNumber.Number;

            // Act
            guessNumber.NewGame();

            // Assert
            Assert.NotEqual(oldNumber, guessNumber.Number);
        }

        [Fact]
        public void CheckNumber_NotGuess_NumberNotChange()
        {
            // Arrange
            GuessNumber guessNumber = new GuessNumber();
            int oldNumber = guessNumber.Number;

            // Act
            guessNumber.CheckNumber(oldNumber + 1);

            // Assert
            Assert.Equal(oldNumber, guessNumber.Number);
        }
    }
}