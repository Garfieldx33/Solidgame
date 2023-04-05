using SolidGame.SettingsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGame.GameClasses
{
    internal class GuessTheNumberGame : IGame
    {
        public GuessTheNumberGame()
        {

        }
        public void StartGame(IGameSettings gameSettings)
        {
            bool isGuessed = false;
            Random guessRnd = new Random();
            int guessedNumber = guessRnd.Next(gameSettings.RangeFrom, gameSettings.RangeTo);

            Console.WriteLine($"Я загадал число от {gameSettings.RangeFrom} до {gameSettings.RangeTo} \r\n У тебя {gameSettings.TriesCount} попыток");
            Console.WriteLine($"Если Вам надоест игра, введите q");
            for (int t = 1; t <= gameSettings.TriesCount; t++)
            {
                string strCnt = $"У вас осталось {gameSettings.TriesCount - t} попыток";
                Console.WriteLine($"Введите предполагаемое целое число");
                string inpitStr = Console.ReadLine();
                if (inpitStr != "q")
                {
                    int inputNumber = 0;
                    if (int.TryParse(inpitStr, out inputNumber))
                    {
                        if (inputNumber >= gameSettings.RangeFrom && inputNumber <= gameSettings.RangeTo)
                        {
                            isGuessed = guessedNumber == inputNumber;

                            if (!isGuessed)
                            {
                                if (guessedNumber < inputNumber)
                                {
                                    Console.WriteLine($"Загаданное число меньше.{strCnt}");

                                }
                                else
                                {
                                    Console.WriteLine($"Загаданное число больше. {strCnt}");
                                }

                            }
                            else
                            {
                                Console.WriteLine($"Поздравляю, Вы угадали число {inputNumber} за {t} попыток");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели число вне диапазона. Штрафная попытка");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели число не число. Штрафная попытка");
                    }
                }
                else
                {
                    Console.WriteLine("Досвидули");
                    return;
                }

            }
            Console.WriteLine("Вы исчерпали количество попыток");
        }
    }
}
