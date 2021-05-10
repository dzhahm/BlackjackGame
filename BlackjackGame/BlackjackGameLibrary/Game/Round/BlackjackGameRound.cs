﻿using BlackjackGameLibrary.Game.Round.Commands;
using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BlackjackGameLibrary.Game.Round
{
  public class BlackjackGameRound : IBlackjackGameRound
  {
    private readonly int _numberOfPlayers;
    private readonly List<Card> _cards;


    private ERoundState _roundState;
    public ERoundState RoundState => _roundState;

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
      _roundState = ERoundState.CardDeal;
      DealForAllPlayers(2);
      DealersFirstPlayedCard = new PlayedCard(_playerCards[EPlayers.Dealer].First(), true);
      DealersSecondPlayedCard = new PlayedCard(_playerCards[EPlayers.Dealer].Last(), false);
      _roundState = ERoundState.WaitForCalls;
    }

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