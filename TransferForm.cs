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
    public partial class TransferForm : Form
    {
        public TransferForm()
        {
            InitializeComponent();
            loadDate();
        }
        private void loadDate()
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BankingApplicationEntities db = new BankingApplicationEntities();
            decimal accnNo = Convert.ToDecimal(txtAccountNo.Text);
            var item = (from u in db.UserAccount
                        where u.Account_No == accnNo
                        select u).FirstOrDefault();
            txtName.Text = item.Name;
            txtCurrentAmount.Text = item.balance.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankingApplicationEntities db = new BankingApplicationEntities();
            decimal accNo = Convert.ToDecimal(txtAccountNo.Text);
            var item = (from u in db.UserAccount
                        where u.Account_No == accNo
                        select u).FirstOrDefault();
            decimal b = Convert.ToDecimal(item.balance);
            decimal totalBalance = Convert.ToDecimal(txtAmount.Text);
            decimal transferAcc = Convert.ToDecimal(txtDestAcc.Text);
            if(b > totalBalance)
            {
                var item2 = (from u in db.UserAccount
                             where u.Account_No == transferAcc
                             select u).FirstOrDefault();
                item2.balance += totalBalance;
                item.balance -= totalBalance;
                Transfer transfer = new Transfer();
                transfer.AccountNo = Convert.ToDecimal(txtAccountNo.Text);
                transfer.ToTransfer = Convert.ToDecimal(txtDestAcc.Text);
                transfer.Date = DateTime.Now;
                transfer.Name = txtName.Text;
                transfer.Balance = Convert.ToDecimal(txtAmount.Text);

                db.Transfer.Add(transfer);
                db.SaveChanges();
                MessageBox.Show("Transfer Money Successfully");
            }

        }
    }
}
