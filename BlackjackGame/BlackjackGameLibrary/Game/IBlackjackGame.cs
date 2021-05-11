using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace BlackjackGameLibrary.Game
{
  public interface IBlackjackGame
  {
    int NumberOfCardDecks { get; }

    int NumberOfRemainingCards { get; }

    List<Card> PlayingCards { get; }

    int NumberOfPlayers { get; }

    ImmutableList<Player> Players { get; }

    IBlackjackGameRound ActualGameRound { get; }

    ImmutableList<IBlackjackGameRound> Rounds { get; }

    void ShuffleCards();

    public void AddNewPlayer(Player player);

    public void RemovePlayer(Player player);

    void StartNewRound();

    void FinishTheRound();
  }
}