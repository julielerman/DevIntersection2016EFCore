using System.Collections.Generic;

namespace Mappings
{
  public class Samurai {
    public Samurai(string name) {
      _name = name;
      _quotes = new List<Quote>();
    }

    private Samurai()
    {
     _quotes=new List<Quote>();
    }

    public int Id { get; private set; }

    private  string _name;
    public string ImmutableName => _name;

    private List<Quote> _quotes;

    public List<Quote> Quotes
    {
      get { return _quotes; }
      set {  }
    }




    //public IEnumerable<Quote> Quotes {
    //  get {
    //    return _quotes.AsReadOnly(); //AsReadOnly can't be cast to a list!
    //  }
    //   set {
    //    _quotes = (List<Quote>)value;
    //  }
    //}

    public void AddQuote(string text) {
      _quotes.Add(Quote.Create(text, Id));
    }
  }
}