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
    public partial class BalanceSheet : Form
    {
        public BalanceSheet()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankingApplicationEntities db = new BankingApplicationEntities();
            decimal accNo = Convert.ToDecimal(textBox1.Text);
            var item = (from u in db.Debit
                        where u.AccountNo == accNo
                        select u);
            dataGridView1.DataSource = item.ToList();
            var item2 = (from u in db.Deposit
                         where u.AccountNo == accNo
                         select u);
            dataGridView2.DataSource = item2.ToList();
            var item3 = (from u in db.Transfer
                         where u.AccountNo == accNo
                         select u);
            dataGridView3.DataSource = item3.ToList();
        }
    }
}
