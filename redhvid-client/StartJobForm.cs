using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redhvid
{
    public partial class StartJobForm : Form
    {
        public StartJobForm()
        {
            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(
                workingArea.Width - this.Width,
                workingArea.Height - this.Height
            );
        }
    }
}
