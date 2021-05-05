using BlackjackGameLibrary.Game.Round.Commands;
using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BlackjackGameLibrary.Game.Round
{
  public class BlackjackGameRound : IBlackjackGameRound
  {
    private readonly int _numberOfPlayers;
    private readonly List<Card> _cards;

    public ERoundState RoundState { get; private set; }

    public PlayedCard DealersFirstPlayedCard { get; private set; }

    public PlayedCard DealersSecondPlayedCard { get; private set; }


    private Dictionary<EPlayers, ERoundResult> _playerResults;
    public ImmutableDictionary<EPlayers, ERoundResult> PlayerResults => _playerResults.ToImmutableDictionary();


    private Dictionary<EPlayers, List<Card>> _playerCards;
    public ImmutableDictionary<EPlayers, List<Card>> PlayerCards => _playerCards.ToImmutableDictionary();


    private Dictionary<EPlayers, int> _playersSumOfCards;
    public ImmutableDictionary<EPlayers, int> PlayersSumOfCards => _playersSumOfCards.ToImmutableDictionary();


    private Dictionary<EPlayers, EPlayerRoundState> _playerRoundStates;
    public ImmutableDictionary<EPlayers, EPlayerRoundState> PlayerRoundStates => _playerRoundStates.ToImmutableDictionary();


    public BlackjackGameRound(List<Card> cards, int numberOfPlayers)
    {
      _cards = cards;
      _numberOfPlayers = numberOfPlayers;
      InitRound();
    }

    public void DealCards()
    {
      //First deal round
      RoundState = ERoundState.CardDeal;
      DealForAllPlayers(2);
      DealersFirstPlayedCard = new PlayedCard(_playerCards[EPlayers.Dealer].First(), true);
      DealersSecondPlayedCard = new PlayedCard(_playerCards[EPlayers.Dealer].Last(), false);
      RoundState = ERoundState.WaitForCalls;
    }

    public void PlayerCall(EPlayers player, ERoundCalls call)
    {
      new ProcessPlayerCallCommand(_cards, _playerCards, _playerRoundStates).Execute(player, call);
      new SumCardValuesForPlayerCommand(_playerCards, _playersSumOfCards).Execute(player);
      new UpdatePlayerRoundResultCommand(_playersSumOfCards, _playerRoundStates, _playerResults).Execute(player);


      CheckIfDealersSecondCardCanBeOpened();
    }

    private void CheckIfDealersSecondCardCanBeOpened()
    {
      if (_playerRoundStates.All(c => c.Value == EPlayerRoundState.Stand || c.Value == EPlayerRoundState.ExceededTwentyOne))
      {
        RoundState = ERoundState.AllPlayersStand;
        OpenDealersSecondCard();
      }
    }

    private void InitRound()
    {
      _playerRoundStates = new Dictionary<EPlayers, EPlayerRoundState>();
      _playerCards = new Dictionary<EPlayers, List<Card>>();
      _playersSumOfCards = new Dictionary<EPlayers, int>();
      _playerResults = new Dictionary<EPlayers, ERoundResult>();
      new InitRoundCommand(_playerRoundStates, _playerCards, _playersSumOfCards).Execute(_numberOfPlayers);
      RoundState = ERoundState.Initialized;
    }

    private void DealForAllPlayers(int numberOfCardSets)
    {
      new DealCardsForAllPlayersCommand(_cards, _playerCards, _numberOfPlayers).Execute(numberOfCardSets);

      foreach (KeyValuePair<EPlayers, EPlayerRoundState> playerRoundState in _playerRoundStates)
      {
        _playerRoundStates[playerRoundState.Key] = EPlayerRoundState.CanMakeHitCall;
      }
    }

    public void OpenDealersSecondCard()
    {
      if (RoundState == ERoundState.AllPlayersStand)
      {
        _playerCards[EPlayers.Dealer].Add(DealersFirstPlayedCard);
        _playerCards[EPlayers.Dealer].Add(DealersSecondPlayedCard);
        _playersSumOfCards[EPlayers.Dealer] = SumCardValues(_playerCards[EPlayers.Dealer]);
      }
      else
      {
        //TODO error case, dealers cards cannot be opened before all players call stand or they exceed 21
      }
    }

    public void FinalizeRoundResults()
    {
      if (RoundState == ERoundState.AllPlayersStand)
      {
        new FinalizeRoundResultsCommand(_playersSumOfCards, _playerResults).Execute();
      }
    }

    private void SumCardValuesOfAllPlayers()
    {
      foreach (EPlayers player in _playerCards.Keys)
      {
        SumCardValuesForPlayer(player);
      }
    }

    private void SumCardValuesForPlayer(EPlayers player)
    {
      int sum = SumCardValues(_playerCards[player]);
      _playersSumOfCards[player] = sum;

      if (sum > 21)
      {
        _playerResults[player] = ERoundResult.DealerWins;
        _playerRoundStates[player] = EPlayerRoundState.ExceededTwentyOne;
      }
    }

    private int SumCardValues(List<Card> cards)
    {
      int sum = cards.Where(c => c.CardType != ECardType.Ace).Sum(c => c.Value);
      foreach (var aces in cards.Where(c => c.CardType == ECardType.Ace))
      {
        if (sum + 11 > 21)
        {
          sum++;
        }
        else
        {
          sum = sum + 10;
        }
      }

      return sum;
    }
  }
}