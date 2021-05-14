using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.PlayingCards;
using BlackjackGameUI.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace BlackjackGameUI.ViewModel
{
  public class PlayerViewModel : INotifyPropertyChanged
  {
    private readonly PlayerCardsViewModel _playerCardsViewModel;

    private readonly List<Card> _playerCards;

    public event EventHandler<EventArgs> PlayerPressedHitButton;

    public EPlayers Player
    {
      get => _player;
      set
      {
        _player = value;
        _playerName = _player.ToString();
      }
    }

    private EPlayers _player;

    public string PlayerName
    {
      get => _playerName;
      set
      {
        _playerName = value;
        OnPropertyChanged(nameof(PlayerName));
      }
    }

    private string _playerName;

    public bool IsHitButtonEnabled
    {
      get => _isHitButtonEnabled;
      set
      {
        _isHitButtonEnabled = value;
        OnPropertyChanged(nameof(IsHitButtonEnabled));
      }
    }

    private bool _isHitButtonEnabled;

    public PlayerViewModel(PlayerCardsViewModel playerCardsViewModel)
    {
      _isHitButtonEnabled = false;
      _playerCardsViewModel = playerCardsViewModel;
      _playerCards = new List<Card>();
      _playerCardsViewModel.UpdateCards(_playerCards);
    }

    public void SetPlayerCards(List<Card> cards)
    {
      _playerCards.Clear();
      foreach (Card card in cards)
      {
        _playerCards.Add(card);
      }

      _playerCardsViewModel.UpdateCards(cards);
    }

    public void ClearPlayerCards()
    {
      _playerCards.Clear();
      _playerCardsViewModel.ClearCardImages();
    }

    public void OnHitCall()
    {
      PlayerPressedHitButton?.Invoke(this, EventArgs.Empty);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}