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
    public partial class DebitForm : Form
    {
        public DebitForm()
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
        private void button2_Click(object sender, EventArgs e)
        {
            BankingApplicationEntities db = new BankingApplicationEntities();
            decimal accNo = Convert.ToDecimal(txtAccountNo.Text);
            var item = (from u in db.UserAccount
                        where u.Account_No == accNo
                        select u).FirstOrDefault();
            txtName.Text = item.Name;
            txtOldBalance.Text = item.balance.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankingApplicationEntities db = new BankingApplicationEntities();
            NewAccount account = new NewAccount();
            Debit debit = new Debit();
            debit.Date = DateTime.Now;
            debit.AccountNo = Convert.ToDecimal(txtAccountNo.Text);
            debit.Name = txtName.Text;
            debit.OldBalance = Convert.ToDecimal(txtOldBalance.Text);
            debit.Mode = comboBox1.SelectedItem.ToString();
            debit.DebAmount = Convert.ToDecimal(txtAmount.Text);
            db.Debit.Add(debit);
            db.SaveChanges();
            decimal accNo = Convert.ToDecimal(txtAccountNo.Text);
            var item = (from u in db.UserAccount
                        where u.Account_No == accNo
                        select u).FirstOrDefault();
            item.balance = Convert.ToDecimal(txtAmount.Text);
            db.SaveChanges();
            MessageBox.Show("Debit Money");
        }
    }
}
