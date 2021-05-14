using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;
using System.Linq;


namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class ProcessPlayerCallCommand
  {
    private readonly List<Card> _cards;
    private readonly Dictionary<EPlayers, List<Card>> _playerCards;
    private readonly Dictionary<EPlayers, EPlayerRoundState> _playerRoundStates;

    public ProcessPlayerCallCommand(List<Card> cards, Dictionary<EPlayers, List<Card>> playerCards, Dictionary<EPlayers, EPlayerRoundState> playerRoundStates)
    {
      _cards = cards;
      _playerCards = playerCards;
      _playerRoundStates = playerRoundStates;
    }

    public void Execute(EPlayers player, ERoundCalls call)
    {
      if (_playerRoundStates[player] == EPlayerRoundState.CanMakeHitCall)
      {
        switch (call)
        {
          case ERoundCalls.Hit:
            new GivePlayerAdditionalCardCommand(_cards, _playerCards).Execute(player);
            break;
          case ERoundCalls.Stand:
            _playerRoundStates[player] = EPlayerRoundState.Stand;
            break;
          default:
            return;
        }
      }
    }

    private void GivePlayerAdditionalCard(EPlayers player)
    {
      _playerCards[player].Add(_cards.First());
      _cards.RemoveAt(0);
    }
  }
}