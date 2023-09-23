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
    public partial class FDForm : Form
    {
        public FDForm()
        {
            InitializeComponent();
            loadMode();
            loadDate();
        }
        public void loadDate()
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        public void loadMode()
        {
            comboBox1.Items.Add("Cash");
            comboBox1.Items.Add("Chque");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankingApplicationEntities db = new BankingApplicationEntities();
            decimal accNo = Convert.ToDecimal(txtAccountNo.Text);
            var accounts = db.UserAccount.Where(x => x.Account_No == accNo).SingleOrDefault();
            FD fdForm = new FD();
            fdForm.AccountNo = accNo;
            fdForm.Mode = comboBox1.SelectedItem.ToString();
            fdForm.Rupees = txtRupees.Text;
            fdForm.Period = Convert.ToInt32(txtPeriod.Text);
            fdForm.InterestRate = Convert.ToDecimal(txtInterest.Text);
            fdForm.StartDate = DateTime.Now;
            fdForm.MaturityDate = DateTime.Now.AddDays(Convert.ToInt32(txtPeriod.Text));
            fdForm.MaturityAmount = Convert.ToDecimal(((Convert.ToDecimal(txtRupees.Text) * Convert.ToInt32(txtPeriod.Text) *
                                      Convert.ToDecimal(txtInterest.Text)) / (100 * 12 * 30)) + (Convert.ToDecimal(txtRupees.Text)));
            db.FD.Add(fdForm);
            decimal amount = Convert.ToDecimal(txtRupees.Text);
            decimal totalAmount = Convert.ToDecimal(accounts.balance);
            accounts.balance = totalAmount - amount;
            db.SaveChanges();
            MessageBox.Show("FD Started Now");
        }
    }
}
