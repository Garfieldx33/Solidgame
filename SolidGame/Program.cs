// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using SolidGame.ConfigClasses;
using SolidGame.GameClasses;
using SolidGame.SettingsClasses;

Console.WriteLine("Здравствуй, друг. Скажи мне, как тебя зовут?");
string _playername = Console.ReadLine();

IConfigurator configurator = new JsonConfigurator(); // тут можно использовать еще и JsonConfigurator
var settings = configurator.InitGameSettings();

Console.WriteLine($"Приятно познакомиться, {_playername}.\r\nВот текущие настройки игры:\r\n{settings.ToString()}");
settings.PrepairingToGame();

IGame g = new GuessTheNumberGame();
GameStarter CurrentGame = new GameStarter(_playername, settings, g);

CurrentGame.OkLetsPlay();




