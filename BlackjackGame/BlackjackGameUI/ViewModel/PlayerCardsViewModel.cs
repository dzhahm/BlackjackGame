using BlackjackGameLibrary.Game.Round.Commands;
using BlackjackGameLibrary.PlayingCards;
using BlackjackGameUI.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace BlackjackGameUI.ViewModel
{
  public class PlayerCardsViewModel : INotifyPropertyChanged
  {
    public Image FirstCardToBeDisplayed
    {
      get => _firstCardToBeDisplayed;
      set
      {
        _firstCardToBeDisplayed = value;
        OnPropertyChanged(nameof(FirstCardToBeDisplayed));
      }
    }

    private Image _firstCardToBeDisplayed;


    public Image SecondCardToBeDisplayed
    {
      get => _secondCardToBeDisplayed;
      set
      {
        _secondCardToBeDisplayed = value;
        OnPropertyChanged(nameof(SecondCardToBeDisplayed));
      }
    }

    private Image _secondCardToBeDisplayed;

    public Image ThirdCardToBeDisplayed
    {
      get => _thirdCardToBeDisplayed;
      set
      {
        _thirdCardToBeDisplayed = value;
        OnPropertyChanged(nameof(ThirdCardToBeDisplayed));
      }
    }

    private Image _thirdCardToBeDisplayed;

    public Image FourthCardToBeDisplayed
    {
      get => _fourthCardToBeDisplayed;
      set
      {
        _fourthCardToBeDisplayed = value;
        OnPropertyChanged(nameof(FourthCardToBeDisplayed));
      }
    }

    private Image _fourthCardToBeDisplayed;


    private readonly string _baseCardFolder;


    public PlayerCardsViewModel()
    {
      _baseCardFolder = Path.Combine(Environment.CurrentDirectory, "Cards");
      InitCards();
    }

    public void UpdateCards(List<Card> cards)
    {
      if (cards.Count == 0)
      {
        ClearCardImages();
      }

      if (cards.Count > 0)
      {
        FirstCardToBeDisplayed = GetCardImage(cards[0]);
      }

      if (cards.Count > 1)
      {
        SecondCardToBeDisplayed = GetCardImage(cards[1]);
      }

      if (cards.Count > 2)
      {
        ThirdCardToBeDisplayed = GetCardImage(cards[2]);
      }

      if (cards.Count > 3)
      {
        FourthCardToBeDisplayed = GetCardImage(cards[3]);
      }

      if (cards.Count > 4)
      {
        //TODO
      }
    }


    public void ClearCardImages()
    {
      FirstCardToBeDisplayed = new Image();
      SecondCardToBeDisplayed = new Image();
      ThirdCardToBeDisplayed = new Image();
      FourthCardToBeDisplayed = new Image();
    }

    private Image GetCardImage(Card card)
    {
      string cardFirstIdentifier = null;
      string cardSecondIdentifier = null;

      switch (card.CardType)
      {
        case ECardType.Ace:
          cardFirstIdentifier = "A";
          break;
        case ECardType.King:
          cardFirstIdentifier = "K";
          break;
        case ECardType.Queen:
          cardFirstIdentifier = "Q";
          break;
        case ECardType.Jack:
          cardFirstIdentifier = "J";
          break;
        case ECardType.Numerical:
          cardFirstIdentifier = card.Value.ToString();
          break;
      }

      switch (card.CardSuit)
      {
        case ECardSuitTypes.Clubs:
          cardSecondIdentifier = "C";
          break;
        case ECardSuitTypes.Diamonds:
          cardSecondIdentifier = "D";
          break;
        case ECardSuitTypes.Hearts:
          cardSecondIdentifier = "H";
          break;
        case ECardSuitTypes.Spades:
          cardSecondIdentifier = "S";
          break;
      }

      string cardFileName = cardFirstIdentifier + cardSecondIdentifier + ".png";
      return new Image {Source = new BitmapImage(new Uri(Path.Combine(_baseCardFolder, cardFileName)))};
    }

    private void InitCards()
    {
      FirstCardToBeDisplayed = new Image {Source = new BitmapImage(new Uri(Path.Combine(_baseCardFolder, "gray_back.png")))};

      SecondCardToBeDisplayed = new Image {Source = new BitmapImage(new Uri(Path.Combine(_baseCardFolder, "gray_back.png")))};

      ThirdCardToBeDisplayed = new Image {Source = new BitmapImage(new Uri(Path.Combine(_baseCardFolder, "gray_back.png")))};

      FourthCardToBeDisplayed = new Image {Source = new BitmapImage(new Uri(Path.Combine(_baseCardFolder, "gray_back.png")))};
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}