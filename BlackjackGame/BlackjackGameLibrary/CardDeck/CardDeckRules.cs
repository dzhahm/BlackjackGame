using BlackjackGameLibrary.Properties;
using System.IO;
using System.Xml.Serialization;

namespace BlackjackGameLibrary.CardDeck
{
  [XmlRoot("Standard")]
  public class CardDeckRules
  {
    [XmlElement("NumberOfCardsInASuit")] public int NumberOfCardsInASuit { get; set; }

    [XmlElement("NumberOfNumericalCardsInASuit")]
    public int NumberOfNumericalCardsInASuit { get; set; }

    [XmlElement("SmallestValueOfNumericalCards")]
    public int SmallestValueOfNumericalCards { get; set; }

    [XmlElement("FaceCardValue")] public int FaceCardValue { get; set; }

    [XmlElement("DefaultAceValue")] public int DefaultAceValue { get; set; }
  }
}