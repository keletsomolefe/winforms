using FastMember;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hawks_Business_Solutions
{
    public partial class MainForm : Form
    {
        HBSDataContext database;
        public MainForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void InventoryPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hBSDataSet.Address' table. You can move, or remove it, as needed.
            loadEmployees();
        }

        public void loadEmployees()
        {
            using (database = new HBSDataContext())
            {
                var list = database.Employees.Select(o =>
                new EmployeeResult
                {
                    Id = o.EmployeeId,
                    Name = o.Name,
                    Surname = o.Surname,
                    PhoneNumber = o.PhoneNumber,
                    Email = o.Email
                }).ToList();

                DataTable dt = new DataTable();
                using (var reader = ObjectReader.Create(list))
                {
                    dt.Load(reader);
                }
                DataView view = dt.AsDataView();
                dataGridView1.DataSource = view;
                comboBox1.SelectedIndex = 0;
            }

            dataGridView1.MouseClick += new MouseEventHandler(mouse_click);
        }

        void mouse_click(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
            }else
            {
                ContextMenuStrip my_menu = new ContextMenuStrip();
                int position_xy = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                if (position_xy >= 0)
                {
                    my_menu.Items.Add("View").Name = "View";
                    my_menu.Items.Add("Delete").Name = "Delete";

                    my_menu.Show(dataGridView1, new Point(e.X, e.Y));
                    int index = int.Parse(dataGridView1.Rows[position_xy].Cells[0].Value.ToString());

                    my_menu.ItemClicked += new ToolStripItemClickedEventHandler((x, y)=> right_click(x,y,index, my_menu));
                }
            }
        }

        void right_click(Object sender, ToolStripItemClickedEventArgs e, int index, ContextMenuStrip my_menu)
        {
            if (e.ClickedItem.Name.ToString()== "Delete")
            {
                my_menu.Hide();
                if (MessageBox.Show("Do you want to delete employee?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    deleteEmployee(index);
                    MessageBox.Show("Employee Deleted");
                }
            }else if (e.ClickedItem.Name.ToString() == "View")
            {
                my_menu.Hide();
                EmployeeForm f = new EmployeeForm(this);
                f.View(index);
                f.ShowDialog();
            }
        }

        public void deleteEmployee(int index)
        {
            try
            {
                using (database = new HBSDataContext())
                {
                    var q = database.Employees.Where(x => x.EmployeeId == int.Parse(index.ToString())).Single<Employee>();

                    database.GetTable<Address>().DeleteOnSubmit(q.Address);
                    database.GetTable<NextOfKin>().DeleteOnSubmit(q.NextOfKin);
                    database.GetTable<Employee>().DeleteOnSubmit(q);

                    database.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { loadEmployees(); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EmployeeForm f1 = new EmployeeForm(this);
            f1.StartPosition = FormStartPosition.CenterParent;
            f1.ShowDialog();
        }


        private void button12_Click(object sender, EventArgs e)
        {
            AddQuote f1 = new AddQuote(this);
            f1.StartPosition = FormStartPosition.CenterParent;
            f1.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddJobOrder f = new AddJobOrder();
            f.ShowDialog();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void navigation_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Enter(object sender, EventArgs e)
        {
         
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void metroLabel1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void panel5_Click(object sender, EventArgs e)
        {

        }

        private void panel5_PaddingChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                (dataGridView1.DataSource as DataView).RowFilter = "";
            else
                (dataGridView1.DataSource as DataView).RowFilter = string.Format("Convert(Id, 'System.String') LIKE '{0}%' OR Name LIKE '%{0}%' OR Surname LIKE '%{0}%'", textBox1.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex<3)
                dataGridView1.Sort(dataGridView1.Columns[comboBox1.SelectedIndex], ListSortDirection.Ascending);
            else
                dataGridView1.Sort(dataGridView1.Columns[comboBox1.SelectedIndex-3], ListSortDirection.Descending);
        }

        private void addEmployee_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the selected employee?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int index = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    deleteEmployee(index);
                    MessageBox.Show("Employee Deleted");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EmployeeForm f = new EmployeeForm(this);
            f.ShowDialog();
        }
    }
}
