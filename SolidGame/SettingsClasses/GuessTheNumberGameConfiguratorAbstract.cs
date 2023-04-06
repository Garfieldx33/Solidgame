using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGame.SettingsClasses
{
    public class GuessTheNumberGameConfiguratorAbstract : IGameSettings
    {
        public Dictionary<string, string> _settings = new();

        public int _triesCount;
        public int _rangeFrom;
        public int _rangeTo;

        Dictionary<string, string> IGameSettings.Settings
        {
            get => _settings;
        }

        public void InitSettings()
        {
            _triesCount = int.Parse(_settings["TriesCount"]);
            _rangeFrom = int.Parse(_settings["RangeFrom"]);
            _rangeTo = int.Parse(_settings["RangeTo"]);
        }

        public bool CheckSettings()
        {
            bool isTiesCountCorrect = _triesCount > 0;
            if (!isTiesCountCorrect) Console.WriteLine("Количество попыток должно быть больше нуля");

            bool isRangeFromCorrect = _rangeFrom < _rangeTo;
            if (!isRangeFromCorrect) Console.WriteLine("Начало диапазона чисел должно быть меньше конца диапазона");

            return isTiesCountCorrect && isRangeFromCorrect;
        }

        public override string ToString()
        {
            return $"Количество попыток = {_triesCount}\r\nДиапазон значений от {_rangeFrom} до {_rangeTo}";
        }

        public bool IsNeedToChangeSettings()
        {
            Console.WriteLine("Если хотите изменить настройки перед началом игры, то введите 1");
            return Console.ReadKey().KeyChar == '1';
        }

        public void ChangeSettings()
        {
            int defaultTriesCount = _triesCount;
            int defaultRangeFrom = _rangeFrom;
            int defaultRangeTo = _rangeTo;

            bool isNewSettingsCorrect = false;
            while (!isNewSettingsCorrect)
            {
                Console.WriteLine("Введите желаемое количество попыток");
                _triesCount = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите желаемое начало диапазона");
                _rangeFrom = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите желаемый конец диапазона");
                _rangeTo = int.Parse(Console.ReadLine());

                if (CheckSettings())
                {
                    UpdateSettings(new Dictionary<string, string> { 
                        { "RangeTo", _rangeTo.ToString() }, 
                        { "RangeFrom", _rangeFrom.ToString() }, 
                        { "TriesCount", _triesCount.ToString() } 
                    });

                    isNewSettingsCorrect = true;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверные настройки");
                    Console.WriteLine("Если вы хотите сбросить настройки и выйти, то нажмите q");
                    if (Console.ReadKey().KeyChar == 'q')
                    {
                        _triesCount = defaultTriesCount;
                        _rangeFrom = defaultRangeFrom;
                        _rangeTo = defaultRangeTo;

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

        public virtual void UpdateSettings(Dictionary<string, string> settings)
        {
            throw new NotImplementedException("Метод внесения изменений в конфигурационный файл не реализован");
        }

        public virtual void ReadSettings()
        {
            throw new NotImplementedException("Метод чтения настроек из конфигурационного файла не реализован");
        }

    }
}
