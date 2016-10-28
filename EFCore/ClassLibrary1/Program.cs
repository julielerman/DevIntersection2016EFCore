using Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleApplication
{
  public class Program
  {
    private static void Main(string[] args) {
      using (var _context = new SamuraiContext()) {
        var samurai = new Samurai("Julie");

        samurai.AddQuote("Eat more kale!");
        _context.Add(samurai);
        _context.SaveChanges();
      }
      Console.WriteLine("Changes Saved");
      using (var _newcontext = new SamuraiContext()) {
        var samurai = _newcontext.Samurais.Include(s => s.Quotes).FirstOrDefault();
        Console.WriteLine(samurai.ImmutableName);
        foreach (var quote in samurai.Quotes) {
          Console.WriteLine(quote.Text);
        }
      }
    }
  }
}