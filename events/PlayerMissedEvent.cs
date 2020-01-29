using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.events
{
    public delegate void PlayerMissedEventHandler(object source, PlayerMissedEventArgs e);

    public class PlayerMissedEventArgs : EventArgs { }
}
