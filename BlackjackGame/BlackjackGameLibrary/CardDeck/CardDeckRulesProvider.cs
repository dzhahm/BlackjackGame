using BlackjackGameLibrary.Properties;
using System.IO;
using System.Xml.Serialization;

namespace BlackjackGameLibrary.CardDeck
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
        CardDeckRules temp = (CardDeckRules) serializer.Deserialize(reader);
        _rules.NumberOfCardsInASuit = temp?.NumberOfCardsInASuit ?? 0;
        _rules.NumberOfNumericalCardsInASuit = temp?.NumberOfNumericalCardsInASuit ?? 0;
        _rules.SmallestValueOfNumericalCards = temp?.SmallestValueOfNumericalCards ?? 0;
        _rules.FaceCardValue = temp?.FaceCardValue ?? 0;
        _rules.DefaultAceValue = temp?.DefaultAceValue ?? 0;
      }
    }
  }
}