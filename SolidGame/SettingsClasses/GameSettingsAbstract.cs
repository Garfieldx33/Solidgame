using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGame.SettingsClasses
{
    public class GameSettingsAbstract : IGameSettings
    {
        public int TriesCount { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }

        public bool CheckSettings()
        {
            bool isTiesCountCorrect = TriesCount > 0;
            if (!isTiesCountCorrect) Console.WriteLine("Количество попыток должно быть больше нуля");

            bool isRangeFromCorrect = RangeFrom < RangeTo;
            if (!isRangeFromCorrect) Console.WriteLine("Начало диапазона чисел должно быть меньше конца диапазона");

            return isTiesCountCorrect && isRangeFromCorrect;
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
            int defaultTriesCount = TriesCount;
            int defaultRangeFrom = RangeFrom;
            int defaultRangeTo = RangeTo;

            bool isNewSettingsCorrect = false;
            while (!isNewSettingsCorrect)
            {
                Console.WriteLine("Введите желаемое количество попыток");
                TriesCount = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите желаемое начало диапазона");
                RangeFrom = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите желаемый конец диапазона");
                RangeTo = int.Parse(Console.ReadLine());

                if (CheckSettings())
                {
                    UpdateSettings(TriesCount, RangeFrom, RangeTo);
                    isNewSettingsCorrect = true;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверные настройки");
                    Console.WriteLine("Если вы хотите сбросить настройки и выйти, то нажмите q");
                    if (Console.ReadKey().KeyChar == 'q')
                    {
                        TriesCount = defaultTriesCount;
                        RangeFrom = defaultRangeFrom;
                        RangeTo = defaultRangeTo;

                        return;
                    }
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
            Console.WriteLine("\n\rОтлично, погнали");
        }

        public virtual void UpdateSettings(int newTriesCount, int newRangeFrom, int newRangeTo)
        {
            throw new NotImplementedException("Метод внесения изменений в конфигурационный файл не реализован");
        }
    }
}
