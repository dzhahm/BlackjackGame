using BlackjackGameLibrary.PlayingCards;
using BlackjackGameUI.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlackjackGameUI.ViewModel
{
  public class CardViewModel : INotifyPropertyChanged
  {
    public Card CardToBeDisplayed { get; set; }


    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}