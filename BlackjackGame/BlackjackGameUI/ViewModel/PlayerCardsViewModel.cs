using BlackjackGameUI.Annotations;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
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