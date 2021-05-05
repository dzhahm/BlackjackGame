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
    private PlayedCard _dealersFirstPlayedCard;
    private PlayedCard _dealersSecondPlayedCard;

    private ERoundState _roundState;
    public ERoundState RoundState => _roundState;

    public PlayedCard DealersFirstPlayedCard => _dealersFirstPlayedCard;
    public PlayedCard DealersSecondPlayedCard => _dealersSecondPlayedCard;

    private Dictionary<EPlayers, ERoundResult> _playerResults;
    public ImmutableDictionary<EPlayers, ERoundResult> PlayerResults => _playerResults.ToImmutableDictionary();

    private Dictionary<EPlayers, List<Card>> _playerCards;
    public ImmutableDictionary<EPlayers, List<Card>> PlayerCards => _playerCards.ToImmutableDictionary();

    private Dictionary<EPlayers, int> _playersSumOfCards;
    public Dictionary<EPlayers, int> PlayersSumOfCards => _playersSumOfCards;

    private Dictionary<EPlayers, EPlayerRoundState> _playerRoundStates;
    public ImmutableDictionary<EPlayers, EPlayerRoundState> PlayerRoundStates => _playerRoundStates.ToImmutableDictionary();

    public BlackjackGameRound(ref List<Card> cards, int numberOfPlayers)
    {
      _cards = cards;
      _numberOfPlayers = numberOfPlayers;
      InitRound();
    }

    public void DealCards()
    {
      //First deal round
      _roundState = ERoundState.FirstCardDeal;
      _dealersFirstPlayedCard = new PlayedCard(_cards.First(), true);
      _cards.RemoveAt(0);
      DealForAllPlayers();

      //Second deal round
      _roundState = ERoundState.FirstCardDeal;
      _dealersSecondPlayedCard = new PlayedCard(_cards.First(), true);
      _cards.RemoveAt(0);
      DealForAllPlayers();
      SumCardValuesOfAllPlayers();
      _roundState = ERoundState.WaitForCalls;
    }

    private void GivePlayerAdditionalCard(EPlayers player)
    {
      _playerCards[player].Add(_cards.First());
      _cards.RemoveAt(0);
      SumCardValuesForPlayer(player);
      if (_playersSumOfCards[player] > 21)
      {
        _playerResults[player] = ERoundResult.DealerWins;
        _playerRoundStates[player] = EPlayerRoundState.ExceededTwentyOne;
      }
    }

    public void ProcessPlayerCall(EPlayers player, ERoundCalls call)
    {
      if (_playerRoundStates[player] == EPlayerRoundState.CanMakeHitCall)
      {
        switch (call)
        {
          case ERoundCalls.Hit:
            GivePlayerAdditionalCard(player);
            break;
          case ERoundCalls.Stand:
            _playerRoundStates[player] = EPlayerRoundState.Stand;
            _playersSumOfCards[player] = SumCardValues(PlayerCards[player]);
            break;
          default:
            return;
        }

        CheckIfDealersSecondCardCanBeOpened();
      }
    }

    private void CheckIfDealersSecondCardCanBeOpened()
    {
      if (_playerRoundStates.All(c => c.Value == EPlayerRoundState.Stand || c.Value == EPlayerRoundState.ExceededTwentyOne))
      {
        _roundState = ERoundState.AllPlayersStand;
        OpenDealersSecondCard();
      }
    }

    private void InitRound()
    {
      _playerRoundStates = new Dictionary<EPlayers, EPlayerRoundState>();
      _playerCards = new Dictionary<EPlayers, List<Card>>();
      _playersSumOfCards = new Dictionary<EPlayers, int>();
      _playerResults = new Dictionary<EPlayers, ERoundResult>();
      if (_numberOfPlayers <= 0)
      {
        return;
      }

      if (_numberOfPlayers >= 4)
      {
        return;
      }

      if (_numberOfPlayers > 0)
      {
        _playerRoundStates.Add(EPlayers.Player1, EPlayerRoundState.None);
        _playerCards.Add(EPlayers.Player1, new List<Card>());
        _playersSumOfCards.Add(EPlayers.Player1, 0);
      }

      if (_numberOfPlayers > 1)
      {
        _playerRoundStates.Add(EPlayers.Player2, EPlayerRoundState.None);
        _playerCards.Add(EPlayers.Player2, new List<Card>());
        _playersSumOfCards.Add(EPlayers.Player2, 0);
      }

      if (_numberOfPlayers > 2)
      {
        _playerRoundStates.Add(EPlayers.Player3, EPlayerRoundState.None);
        _playerCards.Add(EPlayers.Player3, new List<Card>());
        _playersSumOfCards.Add(EPlayers.Player3, 0);
      }

      _playerCards.Add(EPlayers.Dealer, new List<Card>());
      _playersSumOfCards.Add(EPlayers.Dealer, 0);
      _roundState = ERoundState.Initialized;
    }

    private void DealForAllPlayers()
    {
      if (_numberOfPlayers <= 0)
      {
        return;
      }

      if (_numberOfPlayers >= 4)
      {
        return;
      }

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

      foreach (KeyValuePair<EPlayers, EPlayerRoundState> playerRoundState in _playerRoundStates)
      {
        _playerRoundStates[playerRoundState.Key] = EPlayerRoundState.CanMakeHitCall;
      }
    }

    public void OpenDealersSecondCard()
    {
      if (_roundState == ERoundState.AllPlayersStand)
      {
        _playerCards[EPlayers.Dealer].Add(_dealersFirstPlayedCard);
        _playerCards[EPlayers.Dealer].Add(_dealersSecondPlayedCard);
        _playersSumOfCards[EPlayers.Dealer] = SumCardValues(_playerCards[EPlayers.Dealer]);
      }
      else
      {
        //TODO error case, dealers cards cannot be opened before all players call stand or they exceed 21
      }
    }

    public void FinalizeRoundResults()
    {
      if (_roundState == ERoundState.AllPlayersStand)
      {
        int dealerCardsSum = _playersSumOfCards[EPlayers.Dealer];
        foreach (KeyValuePair<EPlayers, int> playerCardsSum in _playersSumOfCards.Where(p => p.Key != EPlayers.Dealer))
        {
          if (playerCardsSum.Value > 21)
          {
            _playerResults[playerCardsSum.Key] = ERoundResult.DealerWins;
          }

          if (playerCardsSum.Value == 21)
          {
            if (dealerCardsSum == 21)
            {
              _playerResults[playerCardsSum.Key] = ERoundResult.Push;
              return;
            }

            _playerResults[playerCardsSum.Key] = ERoundResult.PlayerWins;
          }

          if (playerCardsSum.Value < 21)
          {
            if (dealerCardsSum > playerCardsSum.Value)
            {
              _playerResults[playerCardsSum.Key] = ERoundResult.DealerWins;
              return;
            }

            if (dealerCardsSum == playerCardsSum.Value)
            {
              _playerResults[playerCardsSum.Key] = ERoundResult.Push;
              return;
            }

            if (dealerCardsSum < playerCardsSum.Value)
            {
              _playerResults[playerCardsSum.Key] = ERoundResult.PlayerWins;
              return;
            }
          }
        }
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