using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;

namespace BlackjackGameLibrary.Game.Round.Commands
{
  public class InitRoundCommand
  {
    private readonly Dictionary<EPlayers, EPlayerRoundState> _playerRoundStates;
    private readonly Dictionary<EPlayers, ERoundResult> _playerRoundResults;
    private readonly Dictionary<EPlayers, List<Card>> _playerCards;
    private readonly Dictionary<EPlayers, int> _playersSumOfCards;

    public InitRoundCommand(Dictionary<EPlayers, EPlayerRoundState> playerRoundStates, Dictionary<EPlayers, ERoundResult> playerRoundResults, Dictionary<EPlayers, List<Card>> playerCards,
      Dictionary<EPlayers, int> playersSumOfCards)
    {
      _playerRoundStates = playerRoundStates;
      _playerRoundResults = playerRoundResults;
      _playerCards = playerCards;
      _playersSumOfCards = playersSumOfCards;
    }

    public void Execute(int numberOfPlayers)
    {
      if (numberOfPlayers <= 0)
      {
        return;
      }

      if (numberOfPlayers >= 4)
      {
        return;
      }

      _playerRoundStates.Add(EPlayers.Player1, EPlayerRoundState.None);
      _playerRoundResults.Add(EPlayers.Player1, ERoundResult.None);
      _playerCards.Add(EPlayers.Player1, new List<Card>());
      _playersSumOfCards.Add(EPlayers.Player1, 0);

      if (numberOfPlayers > 1)
      {
        _playerRoundStates.Add(EPlayers.Player2, EPlayerRoundState.None);
        _playerRoundResults.Add(EPlayers.Player2, ERoundResult.None);
        _playerCards.Add(EPlayers.Player2, new List<Card>());
        _playersSumOfCards.Add(EPlayers.Player2, 0);
      }

      if (numberOfPlayers > 2)
      {
        _playerRoundStates.Add(EPlayers.Player3, EPlayerRoundState.None);
        _playerCards.Add(EPlayers.Player3, new List<Card>());
        _playerRoundResults.Add(EPlayers.Player3, ERoundResult.None);
        _playersSumOfCards.Add(EPlayers.Player3, 0);
      }

      _playerCards.Add(EPlayers.Dealer, new List<Card>());
      _playersSumOfCards.Add(EPlayers.Dealer, 0);
    }
  }
}