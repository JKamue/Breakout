using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.events
{
    public delegate void AllBlocksDestroyedEventHandler(object source, AllBlocksDestroyedEventArgs e);

    public class AllBlocksDestroyedEventArgs : EventArgs { }
}
