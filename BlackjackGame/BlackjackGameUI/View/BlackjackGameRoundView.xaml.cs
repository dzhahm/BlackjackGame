using BlackjackGameUI.ViewModel;
using System.Windows.Controls;

namespace BlackjackGameUI.View
{
  /// <summary>
  /// Interaction logic for BlackjackGameRoundView.xaml
  /// </summary>
  public partial class BlackjackGameRoundView : UserControl
  {
    public BlackjackGameRoundView()
    {
      InitializeComponent();
      DataContext = new BlackjackGameRoundViewModel((PlayerViewModel) PlayerOneView.DataContext, (PlayerViewModel) PlayerTwoView.DataContext, (PlayerViewModel) PlayerThreeView.DataContext,
        (DealerViewModel) DealersView.DataContext);
    }
  }
}