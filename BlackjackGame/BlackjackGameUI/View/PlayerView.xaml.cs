using BlackjackGameUI.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace BlackjackGameUI.View
{
  /// <summary>
  /// Interaction logic for PlayerView.xaml
  /// </summary>
  public partial class PlayerView : UserControl
  {
    public PlayerView()
    {
      InitializeComponent();
      DataContext = new PlayerViewModel((PlayerCardsViewModel) CardsView.DataContext);
    }

    private void HitButton_OnClick(object sender, RoutedEventArgs e)
    {
      ((PlayerViewModel) DataContext).OnHitCall();
    }

    private void StandButton_OnClick(object sender, RoutedEventArgs e)
    {
      ((PlayerViewModel) DataContext).OnStandCall();
    }
  }
}