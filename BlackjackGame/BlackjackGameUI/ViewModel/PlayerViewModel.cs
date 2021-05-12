using BlackjackGameLibrary.Game;
using BlackjackGameLibrary.PlayingCards;
using BlackjackGameUI.Annotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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


    public PlayerViewModel(PlayerCardsViewModel playerCardsViewModel)
    {
      _playerCardsViewModel = playerCardsViewModel;
      _playerCards = new List<Card>();

      _playerCards.Add(new AceCard(ECardSuitTypes.Hearts));
      _playerCards.Add(new FaceCard(ECardSuitTypes.Spades, ECardType.King));

      _playerCardsViewModel.UpdateCards(_playerCards);
    }

    public void ClearPlayerCards()
    {
      _playerCards.Clear();
      _playerCardsViewModel.ClearCardImages();
    }

    public void OnHitCall()
    {
      _playerCards.Add(new FaceCard(ECardSuitTypes.Clubs, ECardType.Queen));
      _playerCardsViewModel.UpdateCards(_playerCards);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}