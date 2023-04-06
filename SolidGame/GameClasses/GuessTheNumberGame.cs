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
        GuessTheNumberGameConfiguratorAbstract gameSettings;
        public IGameSettings GameSettings 
        { 
            get => gameSettings; 
            set => gameSettings = (GuessTheNumberGameConfiguratorAbstract)value; 
        }

        public GuessTheNumberGame()
        {

        }

        public void StartGame(string GamerName)
        {
            Random guessRnd = new Random();
            int guessedNumber = guessRnd.Next(gameSettings._rangeFrom, gameSettings._rangeTo);

            Console.WriteLine($"Я загадал число от {gameSettings._rangeFrom} до {gameSettings._rangeTo} \r\n У тебя {gameSettings._triesCount} попыток");
            Console.WriteLine($"Если Вам надоест игра, введите q");
            
            for (int t = 1; t <= gameSettings._triesCount; t++)
            {
                string strCnt = $"У вас осталось {gameSettings._triesCount - t} попыток";
                Console.WriteLine($"Введите предполагаемое целое число");
                string inpitStr = Console.ReadLine();
                if (inpitStr != "q")
                {
                    int inputNumber = 0;
                    if (int.TryParse(inpitStr, out inputNumber))
                    {
                        if (inputNumber >= gameSettings._rangeFrom && inputNumber <= gameSettings._rangeTo)
                        {

                            if (guessedNumber != inputNumber)
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
                                Console.WriteLine($"Поздравляю,{GamerName}, Вы угадали число {inputNumber} за {t} попыток");
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
