using System;

namespace Blackbox
{
    public partial class StartJobForm : Utils.RightBottomAlignedForm
    {
        public StartJobForm()
        {
            InitializeComponent();
            AlignForm();
        }

        public new void Show()
        {
            if (!InvokeRequired)
            {
                base.Show();
            }
            else
            {
                Invoke(new Action(Show));
            }
        }

        public new void Hide()
        {
            if (!InvokeRequired)
            {
                base.Hide();
            }
            else
            {
                Invoke(new Action(Hide));
            }
        }
    }
}
