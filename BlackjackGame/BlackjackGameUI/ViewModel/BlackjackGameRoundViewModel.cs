using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.Game.Round;
using BlackjackGameLibrary.Game.Round.Enums;
using BlackjackGameLibrary.PlayingCards;
using System.Collections.Generic;

namespace BlackjackGameUI.ViewModel
{
  public class BlackjackGameRoundViewModel
  {
    private readonly Dictionary<EPlayers, PlayerViewModel> _playerViewModels;

    private BlackjackGameRound _round;

    public BlackjackGameRoundViewModel(PlayerViewModel playerOneViewModel, PlayerViewModel playerTwoViewModel, PlayerViewModel playerThreeViewModel)
    {
      _playerViewModels = new Dictionary<EPlayers, PlayerViewModel>()
      {
        {EPlayers.Player1, playerOneViewModel},
        {EPlayers.Player2, playerTwoViewModel},
        {EPlayers.Player3, playerThreeViewModel}
      };
      playerOneViewModel.PlayerPressedHitButton += OnPlayerOnePressedHitButton;
      playerTwoViewModel.PlayerPressedHitButton += OnPlayerTwoPressedHitButton;
      playerThreeViewModel.PlayerPressedHitButton += OnPlayerThreePressedHitButton;
    }

    private void OnPlayerOnePressedHitButton(object sender, System.EventArgs e)
    {
      _round.PlayerCall(EPlayers.Player1, ERoundCalls.Hit);
      _playerViewModels[EPlayers.Player1].SetPlayerCards(_round.PlayerCards[EPlayers.Player1]);
    }

    private void OnPlayerTwoPressedHitButton(object sender, System.EventArgs e)
    {
      _round.PlayerCall(EPlayers.Player2, ERoundCalls.Hit);
      _playerViewModels[EPlayers.Player2].SetPlayerCards(_round.PlayerCards[EPlayers.Player2]);
    }

    private void OnPlayerThreePressedHitButton(object sender, System.EventArgs e)
    {
      _round.PlayerCall(EPlayers.Player3, ERoundCalls.Hit);
      _playerViewModels[EPlayers.Player3].SetPlayerCards(_round.PlayerCards[EPlayers.Player3]);
    }

    public void StartNewRound(List<Card> cards, int numberOfPlayers)
    {
      _round = new BlackjackGameRound(cards, numberOfPlayers);
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
        }
      }
    }
  }
}