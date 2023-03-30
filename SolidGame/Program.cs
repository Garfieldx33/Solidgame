// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using SolidGame;

Console.WriteLine("Здравствуй, друг. Скажи мне, как тебя зовут?");

string _playername = Console.ReadLine();
var settings = InitGameSettingsJson();

Console.WriteLine($"Приятно познакомиться, {_playername}.\r\nВот текущие настройки игры:\r\n{settings.ToString()}");
settings.PrepairingToGame();

Game CurrentGame = new Game(_playername, settings);





JsonGameSettings InitGameSettingsJson()
{
    var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("JsonAppSettings.json", optional: false);
    IConfiguration config = builder.Build();
    return config.GetSection("GameSettings").Get<JsonGameSettings>();
}

InitGameSettingsXml

