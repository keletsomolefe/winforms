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
    public partial class AddQuote : Form
    {
        private MainForm mainForm = null;
        public AddQuote()
        {
            InitializeComponent();
        }

        public AddQuote(Form callingForm)
        {
            mainForm = callingForm as MainForm;
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] serviceLine = listBox1.Items.OfType<string>().ToArray();
            string[] inventoryLine = listBox2.Items.OfType<string>().ToArray();

            
        }

        private void AddQuote_Load(object sender, EventArgs e)
        {
            

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                (dataGridView1.DataSource as DataView).RowFilter = "";
            else
                (dataGridView1.DataSource as DataView).RowFilter = string.Format("Convert(ClientId, 'System.String') LIKE '{0}%' OR Name LIKE '%{0}%'", textBox2.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                (dataGridView2.DataSource as DataView).RowFilter = "";
            else
                (dataGridView2.DataSource as DataView).RowFilter = string.Format("Convert(ServiceId, 'System.String') LIKE '{0}%' OR ServiceName LIKE '%{0}%'", textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newValue = comboBox2.SelectedValue + ", " + comboBox2.Text + ", " + "R" + dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value + ", " + textBox5.Text;
            string[] newTmp = newValue.Split(',');

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string[] tmp = listBox1.Items[i].ToString().Split(',');
                if (newTmp[0] == tmp[0])
                    return;
            }

            if (comboBox2.Text != "")
                listBox1.Items.Add(newValue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newValue = comboBox3.SelectedValue + ", " + comboBox3.Text + ", " + "R" + dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[3].Value + ", " + textBox6.Text;
            string[] newTmp = newValue.Split(',');

            if (int.Parse(textBox6.Text)> int.Parse(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[2].Value.ToString()))
            {
                MessageBox.Show(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[2].Value.ToString() + " units left","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                string[] tmp = listBox2.Items[i].ToString().Split(',');
                if (newTmp[0] == tmp[0])
                    return;
            }

            if (comboBox3.Text!="")
                listBox2.Items.Add(newValue);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                (dataGridView3.DataSource as DataView).RowFilter = "";
            else
                (dataGridView3.DataSource as DataView).RowFilter = string.Format("Convert(InventoryId, 'System.String') LIKE '{0}%' OR InventoryName LIKE '%{0}%'", textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox1);
            selectedItems = listBox1.SelectedItems;

            if (listBox1.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox1.Items.Remove(selectedItems[i]);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox2);
            selectedItems = listBox2.SelectedItems;

            if (listBox2.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox2.Items.Remove(selectedItems[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float total = 0;

            for (int i=0; i<listBox1.Items.Count; i++)
            {
                string[] tmp = listBox1.Items[i].ToString().Split(',');
                total += float.Parse(tmp[3].Substring(1)) * float.Parse(tmp[2].Substring(2));
            }

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                string[] tmp = listBox2.Items[i].ToString().Split(',');
                total += float.Parse(tmp[3].Substring(1)) * float.Parse(tmp[2].Substring(2));
            }

            textBox4.Text = total.ToString();
        }
    }
}
