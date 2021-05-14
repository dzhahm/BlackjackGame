using BlackjackGameUI.ViewModel;
using System.Windows.Controls;

namespace BlackjackGameUI.View
{
  /// <summary>
  /// Interaction logic for DealerView.xaml
  /// </summary>
  public partial class DealerView : UserControl
  {
    public DealerView()
    {
      InitializeComponent();
      DataContext = new DealerViewModel((PlayerCardsViewModel) CardsView.DataContext);
    }
  }
}