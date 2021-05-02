using BlackjackGameLibrary.Properties;
using System.IO;
using System.Xml.Serialization;

namespace BlackjackGameLibrary.PlayingCards
{
  public class CardDeckConfigurationProvider
  {
    private CardDeckConfiguration _configuration;

    public CardDeckConfiguration GetRules()
    {
      DeserializeObject();
      return _configuration;
    }

    private void DeserializeObject()
    {
      _configuration = new CardDeckConfiguration();
      XmlSerializer serializer = new XmlSerializer(typeof(CardDeckConfiguration));
      using (StringReader reader = new StringReader(Resources.CardDeckConfiguration))
      {
        _configuration = (CardDeckConfiguration) serializer.Deserialize(reader);
      }
    }
  }
}