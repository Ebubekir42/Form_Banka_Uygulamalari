using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankingApplication
{
    public partial class NewAccount : Form
    {
        BankingApplicationEntities db = null;
        string gender = string.Empty;
        string m_status = string.Empty;
        decimal no;
        MemoryStream ms = null;

        public NewAccount()
        {
            InitializeComponent();
            loadAccount();
            loadState();
            loadDate();
            
        }
        private void loadDate()
        {
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void loadState()
        {
            comboBox1.Items.Add("Konya");
            comboBox1.Items.Add("İstanbul");
            comboBox1.Items.Add("İzmir");
            comboBox1.Items.Add("Ankara");
        }
        private void loadAccount()
        {
            db = new BankingApplicationEntities();
            var item = db.UserAccount.ToArray();
            no = item.LastOrDefault().Account_No + 1;
            txtAccoountNo.Text = no.ToString();
            txtAccoountNo.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            if(opendlg.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(opendlg.FileName);
                pictureBox1.Image = img;
                ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioMale.Checked)
                gender = "Male";
            else if (radioFemale.Checked)
                gender = "Female";
            if (radioMarried.Checked)
                m_status = "Married";
            else if (radioUnMarried.Checked)
                m_status = "UnMarried";

            db = new BankingApplicationEntities();
            UserAccount acc = new UserAccount();
            acc.Account_No = Convert.ToDecimal(txtAccoountNo.Text);
            acc.Name = txtName.Text;
            acc.District = txtDistrict.Text;
            acc.BirthDate = dateTimePicker1.Value;
            string[] date = lblDate.Text.Split('.');
            acc.Date = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
            acc.Gender = gender;
            acc.PhoneNumber = maskedTextBox1.Text;
            acc.MaritialStatus = m_status;
            acc.MotherName = txtMotherName.Text;
            acc.FatherName = txtFatherName.Text;
            acc.Address = txtAddress.Text;
            acc.balance = Convert.ToDecimal(txtBalance.Text);
            acc.State = comboBox1.SelectedItem.ToString();
            acc.Picture = ms.ToArray();
            db.UserAccount.Add(acc);
            db.SaveChanges();
            MessageBox.Show("File Saved");
        }
    }
}
