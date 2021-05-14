using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class GivePlayerAdditionalCardCommand
  {
    private readonly List<Card> _cards;
    private readonly Dictionary<EPlayers, List<Card>> _playerCards;

    public GivePlayerAdditionalCardCommand(List<Card> cards, Dictionary<EPlayers, List<Card>> playerCards)
    {
      _cards = cards;
      _playerCards = playerCards;
    }

    public void Execute(EPlayers player)
    {
      _playerCards[player].Add(_cards.First());
      _cards.RemoveAt(0);
    }
  }
}