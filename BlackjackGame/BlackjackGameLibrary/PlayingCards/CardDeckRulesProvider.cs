using BlackjackGameLibrary.Properties;
using System.IO;
using System.Xml.Serialization;

namespace BlackjackGameLibrary.PlayingCards
{
  public class CardDeckRulesProvider
  {
    private CardDeckRules _rules;

    public CardDeckRules GetRules()
    {
      DeserializeObject();
      return _rules;
    }

    private void DeserializeObject()
    {
      _rules = new CardDeckRules();
      XmlSerializer serializer = new XmlSerializer(typeof(CardDeckRules));
      using (StringReader reader = new StringReader(Resources.CardDeckRules))
      {
        _rules = (CardDeckRules) serializer.Deserialize(reader);
      }
    }
  }
}