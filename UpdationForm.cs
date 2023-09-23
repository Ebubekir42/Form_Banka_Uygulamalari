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
    public partial class UpdationForm : Form
    {
        BankingApplicationEntities db;
        MemoryStream ms;
        BindingList<UserAccount> accounts;
        public UpdationForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            db = new BankingApplicationEntities();
            accounts = new BindingList<UserAccount>();
            decimal accno = Convert.ToDecimal(txtAccoountNo.Text);
            var items = db.UserAccount.Where(a => a.Account_No == accno);
            foreach(var item in items)
            {
                accounts.Add(item);
            }
            dataGridView1.DataSource = accounts;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            accounts = new BindingList<UserAccount>();
            db = new BankingApplicationEntities();
            var items = db.UserAccount.Where(a => a.Name == txtName.Text);
            foreach(var item in items)
            {
                accounts.Add(item);
            }
            dataGridView1.DataSource = accounts;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            db = new BankingApplicationEntities();
            decimal accno = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            var item = db.UserAccount.Where(a => a.Account_No == accno).FirstOrDefault();
            dateTimePicker1.Text = item.BirthDate.ToString();
            txtAccoountNo.Text = item.Account_No.ToString();
            txtName.Text = item.Name;
            txtMotherName.Text = item.MotherName;
            txtFatherName.Text = item.FatherName;
            maskedTextBox1.Text = item.PhoneNumber;
            txtAddress.Text = item.Address;
            byte[] img = item.Picture;
            ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
            txtDistrict.Text = item.District;
            txtState.Text = item.State;
            if(item.Gender.Equals("Male"))
                radioMale.Checked = true;
            else if(item.Gender.Equals("Female"))
                radioFemale.Checked = true;
            if(item.MaritialStatus.Equals("Married"))
                radioMarried.Checked = true;
            else if (item.MaritialStatus.Equals("UnMarried"))
                radioUnMarried.Checked = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = img;
                ms = new MemoryStream();
                img.Save(ms, img.RawFormat);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            accounts.RemoveAt(dataGridView1.SelectedRows[0].Index);
            db = new BankingApplicationEntities();
            decimal acc = Convert.ToDecimal(txtAccoountNo.Text);
            UserAccount userAccount = db.UserAccount.First(s => s.Account_No == acc);
            db.UserAccount.Remove(userAccount);
            db.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankingApplicationEntities db = new BankingApplicationEntities();
            decimal accNo = Convert.ToDecimal(txtAccoountNo.Text);
            var user = db.UserAccount.First(s => s.Account_No == accNo);
            user.Account_No = accNo;
            user.Name = txtName.Text;
            user.Date = dateTimePicker1.Value;
            user.MotherName = txtMotherName.Text;
            user.FatherName = txtFatherName.Text;
            user.PhoneNumber = maskedTextBox1.Text;
            if (radioMale.Checked)
                user.Gender = "Male";
            else if(radioFemale.Checked)
                user.Gender = "Female";
            if (radioMarried.Checked)
                user.MaritialStatus = "Married";
            else if (radioUnMarried.Checked)
                user.MaritialStatus = "UnMarried";
            Image img = pictureBox1.Image;
            if(img.RawFormat != null)
            {
                if(ms != null)
                {
                    img.Save(ms, img.RawFormat);
                    user.Picture = ms.ToArray();
                }
            }
            user.Address = txtAddress.Text;
            user.District = txtDistrict.Text;
            user.State = txtState.Text;
            db.SaveChanges();
            MessageBox.Show("Record Updated");
        }
    }
}
