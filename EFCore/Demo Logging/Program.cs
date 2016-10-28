using EFLogging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace Demo_Logging
{
  internal class Program
  {
    private static void Main() {
      Startup();
      CreateAndQuery();
    }

    private static void CreateAndQuery() {
      using (var context = new SamuraiContext()) {
        var samurai = new Samurai { Name = "Julie" };

        samurai.Quotes.Add(new Quote { Text = "Eat more kale!" });
        context.Add(samurai);
        context.SaveChanges();
      }
      Console.WriteLine("Changes Saved");
      using (var newcontext = new SamuraiContext()) {
        newcontext.Samurais.Include(s => s.Quotes).FirstOrDefault();
      }
      Console.ReadKey();
    }

    private static void Startup() {
      using (var context = new SamuraiContext()) {
        var serviceProvider = context.GetInfrastructure<IServiceProvider>();
        var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new MyLoggerProvider());
      }
    }
  }
}