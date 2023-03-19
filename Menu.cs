using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joc_de_Carti_Final
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            if (labelRules.Visible)
            {
                labelRules.Visible = false;
                pictureBoxAce.Visible = false;
                pictureBoxJoker.Visible = false;
            }
            else
            {
                pictureBoxJoker.Visible = true;
                pictureBoxAce.Visible = true;
                labelRules.Visible = true;
            }
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ServerForm()).Show();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ClientForm()).Show();
        }
    }
}
