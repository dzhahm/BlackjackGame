using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.PlayingCards;
using BlackjackGameUI.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace BlackjackGameUI.ViewModel
{
  public class PlayerViewModel : INotifyPropertyChanged
  {
    private readonly PlayerCardsViewModel _playerCardsViewModel;

    private readonly List<Card> _playerCards;

    public EPlayers Player
    {
      get => _player;
      set
      {
        _player = value;
        PlayerName = _player.ToString();
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

    public string CardSum
    {
      get => _cardSum;
      set
      {
        _cardSum = value;
        OnPropertyChanged(nameof(CardSum));
      }
    }

    public SolidColorBrush CardSumBackgroundColor
    {
      get => _cardSumBackgroundColor;
      set
      {
        _cardSumBackgroundColor = value;
        OnPropertyChanged(nameof(CardSumBackgroundColor));
      }
    }

    private SolidColorBrush _cardSumBackgroundColor;

    private string _cardSum;

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


    public void PlayerExceededTwentyOne()
    {
      IsHitButtonEnabled = false;
      CardSumBackgroundColor = Brushes.LightCoral;
    }

    public event EventHandler<EventArgs> PlayerPressedHitButton;

    public PlayerViewModel(PlayerCardsViewModel playerCardsViewModel)
    {
      _isHitButtonEnabled = false;
      _playerCardsViewModel = playerCardsViewModel;
      _playerCards = new List<Card>();
      _playerCardsViewModel.UpdateCards(_playerCards);
      _cardSumBackgroundColor = Brushes.LightGreen;
      _cardSum = "Sum: ";
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