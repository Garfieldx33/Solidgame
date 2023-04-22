// See https://aka.ms/new-console-template for more information
using SolidGame.GameClasses;
using SolidGame.SettingsClasses;

Console.WriteLine("Здравствуй, друг. Скажи мне, как тебя зовут?");
string _playername = Console.ReadLine();
Console.WriteLine($"Приятно познакомиться, {_playername}.\r\n Начинаем считывание конфигурации...");
IGameSettings configReader = new JsonGameConfigurator(); // Можно использовать XmlGameSettings()
configReader.ReadSettings();
configReader.InitSettings();
Console.WriteLine(configReader.ToString());
configReader.PrepairingToGame();

IGame g = new GuessTheNumberGame { GameSettings = configReader };
GameStarter CurrentGame = new GameStarter(_playername, g);

CurrentGame.OkLetsPlay();




