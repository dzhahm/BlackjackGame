using BlackjackGameLibrary.PlayingCards;
using BlackjackGameUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackjackGameUI
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      CardDeck cardDeck = new CardDeck();
      cardDeck.Shuffle();
      List<Card> cards = new(cardDeck.Cards);
      int numberOfPlayers = 3;

      BlackjackGameRoundViewModel round = (BlackjackGameRoundViewModel) RoundView.DataContext;
      round.StartNewRound(cards, numberOfPlayers);
    }
  }
}