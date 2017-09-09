using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hawks_Business_Solutions
{
    public partial class AddClient : Form
    {
        private MainForm mainForm = null;
        public AddClient()
        {
            InitializeComponent();
        }

        public AddClient(Form callingForm)
        {
            mainForm = callingForm as MainForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox1, "Please enter customer name");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox1, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!IsValidEmail(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox2, "Please enter email");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox2, null);
            }
        }

        bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        bool IsNumber(string number)
        {
            return Regex.IsMatch(number, @"^[0-9]+$");
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!IsNumber(textBox3.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox3, "Please enter phone number");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox3, null);
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox5, "Please enter street name");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox5, null);
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox7, "Please enter city");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox7, null);
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox8, "Please enter province");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox8, null);
            }
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            if (!IsNumber(textBox9.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(textBox9, "Please enter postal code");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(textBox9, null);
            }
        }
    }
}
