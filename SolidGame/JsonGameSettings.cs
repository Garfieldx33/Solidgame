using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGame
{
    // Данный класс показывает принцип единой ответственности. В данном случае - за настройки игры.
    public class JsonGameSettings : IGameSettings
    {
        public int TriesCount { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }

        /*public JsonGameSettings(int TriesCnt, int RngForm, int RngTo) 
        {
            TriesCount = TriesCnt;
            RangeFrom = RngForm;
            RangeTo = RngTo;
        }*/

        public bool CheckSettings()
        {
            bool isTiesCountCorrect = TriesCount > 0;
            if (!isTiesCountCorrect) Console.WriteLine("Количество попыток должно быть больше нуля");

            bool isRangeFromCorrect = (RangeFrom < RangeTo);
            if (!isRangeFromCorrect) Console.WriteLine("Начало диапазона чисел должно быть меньше конца диапазона");

            return (isTiesCountCorrect && isRangeFromCorrect);
        }

        public override string ToString()
        {
            return $"Количество попыток = {TriesCount}\r\nДиапазон значений от {RangeFrom} до {RangeTo}";
        }

        public bool IsNeedToChangeSettings()
        {
            Console.WriteLine("Если хотите изменить настройки перед началом игры, то введите 1");
            return Console.ReadKey().KeyChar == '1';

        }

        public void ChangeSettings()
        {
            bool isNewSettingsCorrect = false;
            while(!isNewSettingsCorrect)
            {
                Console.WriteLine("Введите желаемое количество попыток");
                int newTriesCount = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите желаемое начало диапазона");
                int newRangeFrom = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите желаемый конец диапазона");
                int newRangeto = int.Parse(Console.ReadLine());

                var newGameSettings = new JsonGameSettings
                {
                    TriesCount = newTriesCount,
                    RangeFrom = newRangeFrom,
                    RangeTo = newRangeto
                };
                
                if (newGameSettings.CheckSettings())
                {
                    TriesCount = newGameSettings.TriesCount;
                    RangeFrom = newGameSettings.RangeFrom;
                    RangeTo = newGameSettings.RangeTo;

                    isNewSettingsCorrect = true;
                }
                else
                {
                    Console.WriteLine("Если вы передумали изменять настройки, то нажмите q");
                    if (Console.ReadKey().KeyChar == 'q') return;
                }
            }
        }

        public void PrepairingToGame()
        {
            if (!CheckSettings())
            {
                Console.WriteLine("Как видишь, настройки не верны, введи корректные, будь так добр");
                ChangeSettings();
            }
            else
            {
                if (IsNeedToChangeSettings())
                {
                    ChangeSettings();
                }
            }
            Console.WriteLine("Отлично, погнали");
        }

        public void UpdateSettings()
        {
            //to do реализовать изменение файла конфигурации
        }
    }
}
