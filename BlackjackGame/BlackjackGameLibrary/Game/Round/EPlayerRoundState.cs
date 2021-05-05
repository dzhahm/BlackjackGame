using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackGameLibrary.Game.Round
{
  public enum EPlayerRoundState
  {
    None,
    CanMakeHitCall,
    ExceededTwentyOne,
    Stand
  }
}