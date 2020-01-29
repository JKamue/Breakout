using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Breakout.classes;

namespace Breakout.events
{
    public delegate void BlockHitEventHandler(object source, BlockHitEventArgs e);

    public class BlockHitEventArgs : EventArgs
    {
        public readonly Block hitBlock;
        public BlockHitEventArgs(Block block)
        {
            hitBlock = block;
        }
    }
}
