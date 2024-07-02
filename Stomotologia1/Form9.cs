using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stomotologia1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.employeesTableAdapter.Update(this.stomotologiaDataSet.Employees);
            dataGridView1.Refresh();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Appointments". При необходимости она может быть перемещена или удалена.
            this.appointmentsTableAdapter.Fill(this.stomotologiaDataSet.Appointments);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.stomotologiaDataSet.Employees);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == employeesBindingSource)
            {
                employeesBindingSource.Filter = "[Position] LIKE'" + textBox1.Text + "%'";
                this.dataGridView1.DataSource = employeesBindingSource;
            }
        }
    }
}
