using System.Collections.Generic;
using System.Xml.Serialization;

namespace BlackjackGameLibrary.PlayingCards
{
  [XmlRoot("Standard")]
  public class CardDeckRules
  {
    [XmlArray("CardSuitTypes")]
    [XmlArrayItem("type")]
    public List<ECardSuitTypes> CardSuits { get; set; }

    [XmlElement("NumberOfCardsInASuit")] public int NumberOfCardsInASuit { get; set; }

    [XmlElement("NumberOfNumericalCardsInASuit")]
    public int NumberOfNumericalCardsInASuit { get; set; }

    [XmlElement("SmallestValueOfNumericalCards")]
    public int SmallestValueOfNumericalCards { get; set; }

    [XmlElement("FaceCardValue")] public int FaceCardValue { get; set; }

    [XmlElement("DefaultAceValue")] public int DefaultAceValue { get; set; }
  }
}