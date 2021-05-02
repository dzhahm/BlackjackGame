using BlackjackGameLibrary.PlayingCards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGameLibrary.Game.GameRound
{
  public class BlackjackGameRound : IBlackjackGameRound
  {
    private readonly int _numberOfPlayers;
    private readonly List<Card> _cards;
    private CardDuringGame _dealersFirstCard;
    private CardDuringGame _dealersSecondCard;
    public CardDuringGame DealersFirstCard => _dealersFirstCard;
    public CardDuringGame DealersSecondCard => _dealersSecondCard;
    public ERoundResult Result { get; }

    private Dictionary<EPlayers, List<Card>> _playerCards;
    public Dictionary<EPlayers, List<Card>> PlayerCards => _playerCards;

    private Dictionary<EPlayers, ERoundCalls> _playerCalls;
    public Dictionary<EPlayers, ERoundCalls> PlayerCalls => _playerCalls;

    private Dictionary<EPlayers, int> _playersSumOfCards;
    public Dictionary<EPlayers, int> PlayersSumOfCards => _playersSumOfCards;

    public BlackjackGameRound(ref List<Card> cards, int numberOfPlayers)
    {
      _cards = cards;
      _numberOfPlayers = numberOfPlayers;
      InitRound();
    }

    public void DealCards()
    {
      //First deal round
      _dealersFirstCard = new CardDuringGame(_cards.First(), true);
      _cards.RemoveAt(0);
      DealForAllPlayers();

      //Second deal round
      _dealersSecondCard = new CardDuringGame(_cards.First(), true);
      _cards.RemoveAt(0);
      DealForAllPlayers();
      SumCardValuesOfAllPlayers();
    }

    public void GivePlayerAdditionalCard(EPlayers player)
    {
      throw new NotImplementedException();
    }

    public void UpdatePlayersCall(EPlayers player, ERoundCalls call)
    {
      throw new NotImplementedException();
    }


    private void InitRound()
    {
      _playerCalls = new Dictionary<EPlayers, ERoundCalls>();
      _playerCards = new Dictionary<EPlayers, List<Card>>();
      _playersSumOfCards = new Dictionary<EPlayers, int>();
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
        _playerCalls.Add(EPlayers.Player1, ERoundCalls.None);
        _playerCards.Add(EPlayers.Player1, new List<Card>());
        _playersSumOfCards.Add(EPlayers.Player1, 0);
      }

      if (_numberOfPlayers > 1)
      {
        _playerCalls.Add(EPlayers.Player2, ERoundCalls.None);
        _playerCards.Add(EPlayers.Player2, new List<Card>());
        _playersSumOfCards.Add(EPlayers.Player2, 0);
      }

      if (_numberOfPlayers > 2)
      {
        _playerCalls.Add(EPlayers.Player3, ERoundCalls.None);
        _playerCards.Add(EPlayers.Player3, new List<Card>());
        _playersSumOfCards.Add(EPlayers.Player3, 0);
      }
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
        _playerCards[EPlayers.Player1].Add(new CardDuringGame(_cards.First(), true));
        _cards.RemoveAt(0);
      }

      if (_numberOfPlayers > 1)
      {
        _playerCards[EPlayers.Player2].Add(new CardDuringGame(_cards.First(), true));
        _cards.RemoveAt(0);
      }

      if (_numberOfPlayers > 2)
      {
        _playerCards[EPlayers.Player3].Add(new CardDuringGame(_cards.First(), true));
        _cards.RemoveAt(0);
      }
    }

    public void FindTheWinner()
    {
      throw new NotImplementedException();
    }

    private void SumCardValuesOfAllPlayers()
    {
      foreach (KeyValuePair<EPlayers, List<Card>> cardsOfPlayer in _playerCards)
      {
        _playersSumOfCards[cardsOfPlayer.Key] = SumCardValues(cardsOfPlayer.Value);
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