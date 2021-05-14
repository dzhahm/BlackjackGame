using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using System;
using System.Collections.Generic;

namespace BlackjackGameUI.ViewModel
{
  public class BlackjackGameRoundViewModel
  {
    private readonly Dictionary<EPlayers, PlayerViewModel> _playerViewModels;

    private readonly DealerViewModel _dealerViewModel;

    private BlackjackGameRound _round;

    public BlackjackGameRoundViewModel(PlayerViewModel playerOneViewModel, PlayerViewModel playerTwoViewModel, PlayerViewModel playerThreeViewModel, DealerViewModel dealerViewModel)
    {
      _playerViewModels = new Dictionary<EPlayers, PlayerViewModel>()
      {
        {EPlayers.Player1, playerOneViewModel},
        {EPlayers.Player2, playerTwoViewModel},
        {EPlayers.Player3, playerThreeViewModel}
      };
      _dealerViewModel = dealerViewModel;

      playerOneViewModel.Player = EPlayers.Player1;
      playerTwoViewModel.Player = EPlayers.Player2;
      playerThreeViewModel.Player = EPlayers.Player3;
      _dealerViewModel.Player = EPlayers.Dealer;

      playerOneViewModel.PlayerPressedHitButton += OnPlayerOnePressedHitButton;
      playerTwoViewModel.PlayerPressedHitButton += OnPlayerTwoPressedHitButton;
      playerThreeViewModel.PlayerPressedHitButton += OnPlayerThreePressedHitButton;

      playerOneViewModel.PlayerPressedStandButton += OnPlayerOnePressedStandButton;
      playerTwoViewModel.PlayerPressedStandButton += OnPlayerTwoPressedStandButton;
      playerThreeViewModel.PlayerPressedStandButton += OnPlayerThreePressedStandButton;
    }

    private void OnPlayerOnePressedStandButton(object sender, EventArgs e)
    {
      HandlePlayerStandCall(EPlayers.Player1);
    }

    private void OnPlayerTwoPressedStandButton(object sender, EventArgs e)
    {
      HandlePlayerStandCall(EPlayers.Player2);
    }

    private void OnPlayerThreePressedStandButton(object sender, EventArgs e)
    {
      HandlePlayerStandCall(EPlayers.Player3);
    }

    private void OnRoundStateChanged(object sender, EventArgs e)
    {
      switch (_round.RoundState)
      {
        case ERoundState.AllPlayersStand:
          FinishRound();
          break;
        case ERoundState.AtLeastOnePlayerStandAndOtherPlayersExceedTwentyOne:
          FinishRound();
          break;
      }
    }

    private void FinishRound()
    {
      _dealerViewModel.AddDealersSecondCard(_round.DealersSecondPlayedCard);
      _round.FinalizeRoundResults();
      if (_round.PlayerCards[EPlayers.Dealer].Count > 2)
      {
        _dealerViewModel.UpdateDealersCards(_round.PlayerCards[EPlayers.Dealer]);
      }

      foreach (EPlayers player in _round.PlayerResults.Keys)
      {
        if (_round.PlayerResults[player] == ERoundResult.PlayerWins)
        {
          _playerViewModels[player].CardSum = $"{_playerViewModels[player].CardSum} - Player wins the round!!!";
        }

        if (_round.PlayerResults[player] == ERoundResult.DealerWins)
        {
          _playerViewModels[player].CardSum = $"{_playerViewModels[player].CardSum} - Player loses the round";
        }

        if (_round.PlayerResults[player] == ERoundResult.Push)
        {
          _playerViewModels[player].CardSum = $"{_playerViewModels[player].CardSum} - Player draws the round!";
        }
      }
    }

    private void HandlePlayerStandCall(EPlayers player)
    {
      _round.PlayerCall(player, ERoundCalls.Stand);
      _playerViewModels[player].IsStandButtonEnabled = false;
      _playerViewModels[player].IsHitButtonEnabled = false;
    }

    private void OnPlayerOnePressedHitButton(object sender, System.EventArgs e)
    {
      HandlePlayerHitCall(EPlayers.Player1);
    }

    private void OnPlayerTwoPressedHitButton(object sender, System.EventArgs e)
    {
      HandlePlayerHitCall(EPlayers.Player2);
    }

    private void OnPlayerThreePressedHitButton(object sender, System.EventArgs e)
    {
      HandlePlayerHitCall(EPlayers.Player3);
    }

    private void HandlePlayerHitCall(EPlayers player)
    {
      _round.PlayerCall(player, ERoundCalls.Hit);
      _playerViewModels[player].SetPlayerCards(_round.PlayerCards[player]);
      _playerViewModels[player].CardSum = $"Card sum: {_round.PlayersSumOfCards[player]}";
      if (_round.PlayerRoundStates[player] == EPlayerRoundState.ExceededTwentyOne)
      {
        _playerViewModels[player].PlayerExceededTwentyOne();
      }
    }


    public void StartNewRound(List<Card> cards, int numberOfPlayers)
    {
      _round = new BlackjackGameRound(cards, numberOfPlayers);
      _round.RoundStateChanged += OnRoundStateChanged;
      _round.DealCards();
      LinkPlayerCardsToView();
    }

    private void LinkPlayerCardsToView()
    {
      foreach (EPlayers player in _round.PlayerCards.Keys)
      {
        if (player != EPlayers.Dealer)
        {
          _playerViewModels[player].SetPlayerCards(_round.PlayerCards[player]);
          _playerViewModels[player].IsHitButtonEnabled = true;
          _playerViewModels[player].IsStandButtonEnabled = true;
          _playerViewModels[player].CardSum = $"Card sum: {_round.PlayersSumOfCards[player]}";
        }
        else
        {
          _dealerViewModel.AddDealersFistCard(_round.DealersFirstPlayedCard);
        }
      }
    }
  }
}