using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApplication
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewAccount().ShowDialog();
        }

        private void allCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CustomerList().ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChangePassword().ShowDialog();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ViewFD().ShowDialog();
        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BalanceSheet().ShowDialog();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreditForm().ShowDialog();
        }

        private void updateSearchAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UpdationForm().ShowDialog();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TransferForm().ShowDialog();
        }

        private void fDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FDForm().ShowDialog();
        }

        private void widthDrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DebitForm().ShowDialog();
        }
    }
}
