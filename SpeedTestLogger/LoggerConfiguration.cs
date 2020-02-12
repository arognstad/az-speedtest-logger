using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SpeedTestLogger
{
  public class LoggerConfigration
  {

    public readonly RegionInfo LoggerLocation;
    public readonly int LoggerId;
    public readonly string UserId;
    public readonly Uri ApiUrl;

    public LoggerConfigration()
    {
      var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

      var config = builder.Build();

      var countryCode = config["loggerLocationCountryCode"];
      LoggerLocation = new RegionInfo(countryCode);

      Console.WriteLine("Logger located in {0}", LoggerLocation.EnglishName);

      UserId = config["userId"];
      LoggerId = int.Parse(config["loggerId"]);
      ApiUrl = new Uri(config["speedTestApiUrl"]);
    }
  }
}