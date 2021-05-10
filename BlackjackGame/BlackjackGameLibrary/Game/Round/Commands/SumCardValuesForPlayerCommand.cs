using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class SumCardValuesForPlayerCommand
  {
    private readonly Dictionary<EPlayers, List<Card>> _playerCards;
    private readonly Dictionary<EPlayers, int> _playersSumOfCards;

    public SumCardValuesForPlayerCommand(Dictionary<EPlayers, List<Card>> playerCards, Dictionary<EPlayers, int> playersSumOfCards)
    {
      _playerCards = playerCards;
      _playersSumOfCards = playersSumOfCards;
    }

    public void Execute(EPlayers player)
    {
      int sum = new GetSumCardValuesCommand().Execute(_playerCards[player]);
      _playersSumOfCards[player] = sum;
    }
  }
}