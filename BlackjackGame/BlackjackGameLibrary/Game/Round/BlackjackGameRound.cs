using BlackjackGameLibrary.Game.Round.Commands;
using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BlackjackGameLibrary.Game.Round
{
  /// <summary>
  /// The round of the blackjack game. In the round, players try to win the game by trying to reach the number 21 by their cards. If a player exceeds 21, the player loses the round automatically.
  /// If the number reached by the player is less then dealer's number, player loses the round. 
  /// </summary>
  public class BlackjackGameRound : IBlackjackGameRound
  {
    private readonly int _numberOfPlayers;
    private readonly List<Card> _cards;

    /// <summary>
    /// State of the round. It changes according to the players' calls. 
    /// </summary>
    public ERoundState RoundState => _roundState;

    private ERoundState _roundState;

    /// <summary>
    /// The first card of the dealer. It is always open and visible to the players.
    /// </summary>
    public PlayedCard DealersFirstPlayedCard { get; private set; }

    /// <summary>
    /// The second card of the dealer. It is face-down until all players finish their call round. 
    /// </summary>
    public PlayedCard DealersSecondPlayedCard { get; private set; }

    /// <summary>
    /// Collection of the all players' results in the round. 
    /// </summary>
    public ImmutableDictionary<EPlayers, ERoundResult> PlayerResults => _playerResults.ToImmutableDictionary();

    private Dictionary<EPlayers, ERoundResult> _playerResults;

    /// <summary>
    /// Collection of players' cards. 
    /// </summary>
    public ImmutableDictionary<EPlayers, List<Card>> PlayerCards => _playerCards.ToImmutableDictionary();

    private Dictionary<EPlayers, List<Card>> _playerCards;

    /// <summary>
    /// The collection of player card sums. It is updated after each hit call made by the player.  
    /// </summary>
    public ImmutableDictionary<EPlayers, int> PlayersSumOfCards => _playersSumOfCards.ToImmutableDictionary();

    private Dictionary<EPlayers, int> _playersSumOfCards;

    /// <summary>
    /// The collection of players round states.
    /// </summary>
    public ImmutableDictionary<EPlayers, EPlayerRoundState> PlayerRoundStates => _playerRoundStates.ToImmutableDictionary();

    private Dictionary<EPlayers, EPlayerRoundState> _playerRoundStates;

    /// <summary>
    /// Constructor for the blackjack game round
    /// </summary>
    /// <param name="cards">Collection of cards which are already shuffled</param>
    /// <param name="numberOfPlayers">Number of players active in the round</param>
    public BlackjackGameRound(List<Card> cards, int numberOfPlayers)
    {
      _cards = cards;
      _numberOfPlayers = numberOfPlayers;
      InitRound();
    }

    /// <summary>
    /// Start the round by dealing cards to all players. Each player and the dealer get two cards in total and a single card in each deal round. The deal order is Player1 => Player2 => Player3 => Dealer. 
    /// </summary>
    public void DealCards()
    {
      //First deal round
      _roundState = ERoundState.CardDeal;
      DealForAllPlayers(2);
      DealersFirstPlayedCard = new PlayedCard(_playerCards[EPlayers.Dealer].First(), true);
      DealersSecondPlayedCard = new PlayedCard(_playerCards[EPlayers.Dealer].Last(), false);
      _roundState = ERoundState.WaitForCalls;
    }

    /// <summary>
    /// Process the call made by the player. Player can make HIT and STAND calls. HIT call is used to get an additional card and STAND call is used to wait until dealer's second card is turned up. 
    /// </summary>
    /// <param name="player">Player who makes the call</param>
    /// <param name="call">Type of the call</param>
    public void PlayerCall(EPlayers player, ERoundCalls call)
    {
      new ProcessPlayerCallCommand(_cards, _playerCards, _playerRoundStates).Execute(player, call);
      new SumCardValuesForPlayerCommand(_playerCards, _playersSumOfCards).Execute(player);
      new UpdatePlayerRoundResultCommand(_playersSumOfCards, _playerRoundStates, _playerResults).Execute(player);
      new UpdateRoundStateAfterPlayerCallCommand(_playerRoundStates).Execute(out _roundState);
      new UpdateDealersSecondCardStateAfterPlayerCallCommand(_roundState, DealersSecondPlayedCard).Execute();
    }

    private void InitRound()
    {
      _playerRoundStates = new Dictionary<EPlayers, EPlayerRoundState>();
      _playerCards = new Dictionary<EPlayers, List<Card>>();
      _playersSumOfCards = new Dictionary<EPlayers, int>();
      _playerResults = new Dictionary<EPlayers, ERoundResult>();
      new InitRoundCommand(_playerRoundStates, _playerResults, _playerCards, _playersSumOfCards).Execute(_numberOfPlayers);
      _roundState = ERoundState.Initialized;
    }

    private void DealForAllPlayers(int numberOfCardSets)
    {
      new DealCardsForAllPlayersCommand(_cards, _playerCards, _numberOfPlayers).Execute(numberOfCardSets);

      foreach (KeyValuePair<EPlayers, EPlayerRoundState> playerRoundState in _playerRoundStates)
      {
        _playerRoundStates[playerRoundState.Key] = EPlayerRoundState.CanMakeHitCall;
      }
    }

    /// <summary>
    /// After either all players stand OR some players stand and some player already loses the round, finish the round for all players by turning up dealer's second card.
    /// If sum of dealer's cards is less than 17, the dealer takes a card until the total is 17 or more.
    /// </summary>
    public void FinalizeRoundResults()
    {
      if (_roundState == ERoundState.AllPlayersStand || _roundState == ERoundState.AtLeastOnePlayerStandAndOtherPlayersExceedTwentyOne)
      {
        new SumCardValuesForPlayerCommand(_playerCards, _playersSumOfCards).Execute(EPlayers.Dealer);
        new FinalizeRoundResultsCommand(_playerRoundStates, _playersSumOfCards, _playerResults).Execute();
      }
      else
      {
        throw new InvalidOperationException(
          "The round is ONLY finalized if all players either make the stand call or some of the players make the stand call and some of them lose the round because they exceed 21.");
      }
    }
  }
}