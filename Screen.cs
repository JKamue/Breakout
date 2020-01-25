using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Breakout.classes;

namespace Breakout
{
    public partial class Screen : Form
    {
        public Screen()
        {
            InitializeComponent();
        }

        private void Screen_Load(object sender, EventArgs e)
        {
            var gridControler = new GridController(this, 500, 500, 10, 20, 15, 15);
            gridControler.AddBlock(new GridCoordinate(0,0), Color.Red, false, 1 );
            gridControler.AddBlock(new GridCoordinate(0,1), Color.Green, false, 1 );
            gridControler.AddBlock(new GridCoordinate(3,4), Color.Red, false, 1 );
        }
    }
}
