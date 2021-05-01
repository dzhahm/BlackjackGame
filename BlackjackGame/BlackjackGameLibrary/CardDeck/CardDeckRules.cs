using BlackjackGameLibrary.Properties;
using System.IO;
using System.Xml.Serialization;

namespace BlackjackGameLibrary.CardDeck
{
  [XmlRoot("Standard")]
  public class CardDeckRules
  {
    [XmlElement("NumberOfCardsInASuit")] public int NumberOfCardsInASuit { get; private set; }

    [XmlElement("NumberOfNumericalCardsInASuit")]
    public int NumberOfNumericalCardsInASuit { get; private set; }

    [XmlElement("SmallestValueOfNumericalCards")]
    public int SmallestValueOfNumericalCards { get; private set; }

    [XmlElement("FaceCardValue")] public int FaceCardValue { get; private set; }

    [XmlElement("DefaultAceValue")] public int DefaultAceValue { get; private set; }

    public CardDeckRules()
    {
      DeserializeObject();
    }

    private void DeserializeObject()
    {
      XmlSerializer serializer = new XmlSerializer(typeof(CardDeckRules));
      using (Stream reader = new FileStream(Resources.CardDeckRules, FileMode.Open))
      {
        CardDeckRules temp = (CardDeckRules) serializer.Deserialize(reader);
        NumberOfCardsInASuit = temp?.NumberOfCardsInASuit ?? 0;
        NumberOfNumericalCardsInASuit = temp?.NumberOfNumericalCardsInASuit ?? 0;
        SmallestValueOfNumericalCards = temp?.SmallestValueOfNumericalCards ?? 0;
        FaceCardValue = temp?.FaceCardValue ?? 0;
        DefaultAceValue = temp?.DefaultAceValue ?? 0;
      }
    }
  }
}