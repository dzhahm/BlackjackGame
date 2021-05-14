using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.PlayingCards;
using BlackjackGameUI.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace BlackjackGameUI.ViewModel
{
  public class DealerViewModel : INotifyPropertyChanged
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


    public DealerViewModel(PlayerCardsViewModel playerCardsViewModel)
    {
      _playerCardsViewModel = playerCardsViewModel;
      _playerCards = new List<Card>();
    }

    public void AddDealersFistCard(Card card)
    {
      _playerCards.Add(card);
      _playerCardsViewModel.UpdateCards(_playerCards);
    }

    public void AddDealersSecondCard(Card card)
    {
      _playerCards.Add(card);
      _playerCardsViewModel.UpdateCards(_playerCards);
    }

    public void UpdateDealersCards(List<Card> cards)
    {
      _playerCards.Clear();
      foreach (Card card in cards)
      {
        _playerCards.Add(card);
      }

      _playerCardsViewModel.UpdateCards(cards);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}