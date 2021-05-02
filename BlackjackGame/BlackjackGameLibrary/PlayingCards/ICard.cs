namespace BlackjackGameLibrary.PlayingCards
{
  public interface ICard
  {
    int Value { get; }
    ECardType CardType { get; }

    ECardSuitTypes CardSuit { get; }

    bool IsEqual(ICard card);

    Card Clone();
  }
}