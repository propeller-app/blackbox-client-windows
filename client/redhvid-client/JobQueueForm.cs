using System.Drawing;
using System.Windows.Forms;

namespace Redhvid
{
    public partial class JobQueueForm : Form
    {
        public JobQueueForm()
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
