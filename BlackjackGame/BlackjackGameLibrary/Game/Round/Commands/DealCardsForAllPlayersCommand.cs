using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class DealCardsForAllPlayersCommand
  {
    private readonly int _numberOfPlayers;
    private readonly Dictionary<EPlayers, List<Card>> _playerCards;
    private readonly List<Card> _cards;

    public DealCardsForAllPlayersCommand(List<Card> cards, Dictionary<EPlayers, List<Card>> playerCards, int numberOfPlayers)
    {
      _cards = cards;
      _playerCards = playerCards;
      _numberOfPlayers = numberOfPlayers;
    }

    public void Execute(int numberOfCardSet)
    {
      for (int i = 0; i < numberOfCardSet; i++)
      {
        Deal();
      }
    }


    private void Deal()
    {
      if (_numberOfPlayers <= 0)
      {
        return;
      }

      if (_numberOfPlayers >= 4)
      {
        return;
      }

      _playerCards[EPlayers.Dealer].Add(new PlayedCard(_cards.First(), true));
      _cards.RemoveAt(0);

      if (_numberOfPlayers > 0)
      {
        _playerCards[EPlayers.Player1].Add(new PlayedCard(_cards.First(), true));
        _cards.RemoveAt(0);
      }

      if (_numberOfPlayers > 1)
      {
        _playerCards[EPlayers.Player2].Add(new PlayedCard(_cards.First(), true));
        _cards.RemoveAt(0);
      }

      if (_numberOfPlayers > 2)
      {
        _playerCards[EPlayers.Player3].Add(new PlayedCard(_cards.First(), true));
        _cards.RemoveAt(0);
      }
    }
  }
}