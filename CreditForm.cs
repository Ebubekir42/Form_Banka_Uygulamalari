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
    public partial class CreditForm : Form
    {
        public CreditForm()
        {
            InitializeComponent();
            loadDate();
            loadMode();
        }

        private void loadDate()
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void loadMode()
        {
            comboBox1.Items.Add("Cash");
            comboBox1.Items.Add("Chque");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            BankingApplicationEntities db = new BankingApplicationEntities();
            decimal accNo = Convert.ToDecimal(txtAccountNo.Text);
            var item = (from u in db.UserAccount
                        where u.Account_No == accNo
                        select u).FirstOrDefault();
            txtName.Text = item.Name;
            txtBalance.Text = item.balance.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankingApplicationEntities db = new BankingApplicationEntities();
            Deposit deposit = new Deposit();
            deposit.AccountNo = Convert.ToDecimal(txtAccountNo.Text);
            string[] date = lblDate.Text.Split('.');
            deposit.Date = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
            deposit.DipAmount = Convert.ToDecimal(txtDeposit.Text);
            deposit.OldBalance = Convert.ToDecimal(txtBalance.Text);
            deposit.Name = txtName.Text;
            deposit.Mode = comboBox1.SelectedItem.ToString();
            db.Deposit.Add(deposit);
            db.SaveChanges();

            decimal accNo = Convert.ToDecimal(txtAccountNo.Text);
            var item = (from u in db.UserAccount
                        where u.Account_No == accNo
                        select u).FirstOrDefault();
            item.balance += Convert.ToDecimal(txtDeposit.Text);
            db.SaveChanges();
            MessageBox.Show("Deposit Money Successfully");
        }
    }
}
