using BlackjackGameUI.ViewModel;
using System.Windows.Controls;

namespace BlackjackGameUI.View
{
  /// <summary>
  /// Interaction logic for PlayerCardsView.xaml
  /// </summary>
  public partial class PlayerCardsView : UserControl
  {
    public PlayerCardsView()
    {
      InitializeComponent();
      DataContext = new PlayerCardsViewModel();
    }
  }
}