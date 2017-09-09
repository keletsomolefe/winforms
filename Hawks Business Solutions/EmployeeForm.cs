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
    public partial class EmployeeForm : Form
    {
        HBSDataContext database;
        Employee employee;
        int index = -1;
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private MainForm mainForm = null;
        public EmployeeForm(Form callingForm)
        {
            mainForm = callingForm as MainForm;
            InitializeComponent();
        }

        public void View(int index)
        {
            this.index = index;
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hBSDataSet1.Gender' table. You can move, or remove it, as needed.
            this.genderTableAdapter.Fill(this.hBSDataSet1.Gender);
            // TODO: This line of code loads data into the 'hBSDataSet.EmployeeType' table. You can move, or remove it, as needed.
            this.employeeTypeTableAdapter.Fill(this.hBSDataSet.EmployeeType);

            if (index != -1)
            {
                using (database = new HBSDataContext())
                {
                    employee = database.Employees.Single(x => x.EmployeeId == index);
                    txtName.Text = employee.Name;
                    txtSurname.Text = employee.Surname;
                    txtEmail.Text = employee.Email;
                    txtPhone.Text = employee.PhoneNumber;
                    cmbGender.SelectedValue = employee.Gender.GenderId;
                    cmbType.SelectedValue = employee.EmployeeType.EmployeeTypeId;
                    txtNOK.Text = employee.NextOfKin.NkName;
                    txtNOKPhone.Text = employee.NextOfKin.NkPhoneNumber;
                    txtStreetName.Text = employee.Address.StreetName;
                    txtSuburb.Text = employee.Address.Suburb;
                    txtCity.Text = employee.Address.City;
                    txtProvince.Text = employee.Address.Province;
                    txtCode.Text = employee.Address.PostalCode;
                    button7.Enabled = false;
                    addEmployee.Enabled = true;
                }
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtName, "Please enter employee name");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtName, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSurname.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtSurname, "Please enter employee surname");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtSurname, null);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, "Please enter employee email");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtEmail, null);
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

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtStreetName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtStreetName, "Please enter street name");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtStreetName, null);
            }
        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            if (!IsNumber(txtCode.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtCode, "Please enter code");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtCode, null);
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtProvince.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtProvince, "Please enter province");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtProvince, null);
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCity.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtCity, "Please enter city");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtCity, null);
            }
        }

        private void textBox10_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNOK.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNOK, "Please enter next of kin name");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtNOK, null);
            }
        }

        private void textBox11_Validating(object sender, CancelEventArgs e)
        {
            if (!IsNumber(txtNOKPhone.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNOKPhone, "Please enter next of kin contact number");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtNOKPhone, null);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (database = new HBSDataContext())
            {
                try
                {
                    Address address = new Address();
                    address.StreetName = txtStreetName.Text;
                    address.Suburb = txtSuburb.Text;
                    address.City = txtCity.Text;
                    address.Province = txtProvince.Text;
                    address.PostalCode = txtCode.Text;

                    NextOfKin nextOfKin = new NextOfKin();
                    nextOfKin.NkName = txtNOK.Text;
                    nextOfKin.NkPhoneNumber = txtNOKPhone.Text;

                    Gender gender = database.Genders.Single(x => x.GenderId == int.Parse(cmbGender.SelectedValue.ToString()));
                    EmployeeType employeeType = database.EmployeeTypes.Single(x => x.EmployeeTypeId == int.Parse(cmbType.SelectedValue.ToString()));

                    Employee employee = new Employee();
                    employee.Name = txtName.Text;
                    employee.Surname = txtSurname.Text;
                    employee.Email = txtEmail.Text;
                    employee.PhoneNumber = txtPhone.Text;

                    database.Addresses.InsertOnSubmit(address);
                    database.NextOfKins.InsertOnSubmit(nextOfKin);

                    employee.Address = address;
                    employee.NextOfKin = nextOfKin;
                    employee.Gender = gender;
                    employee.EmployeeType = employeeType;

                    database.Employees.InsertOnSubmit(employee);

                    database.SubmitChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally {
                    
                }

                this.Close();
                mainForm.loadEmployees();
                MessageBox.Show("New Employee Added");
            }
        }

        private void addEmployee_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                mainForm.deleteEmployee(index);
                MessageBox.Show("Employee Deleted");
                this.Close();
            }
        }
    }
}
