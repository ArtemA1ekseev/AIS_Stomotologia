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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.actionsBindingSource.EndEdit();
            this.actionsTableAdapter.Update(this.stomotologiaDataSet.Actions);
            dataGridView1.Refresh();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Appointments". При необходимости она может быть перемещена или удалена.
            this.appointmentsTableAdapter.Fill(this.stomotologiaDataSet.Appointments);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Actions". При необходимости она может быть перемещена или удалена.
            this.actionsTableAdapter.Fill(this.stomotologiaDataSet.Actions);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == actionsBindingSource)
            {
                actionsBindingSource.Filter = "[Name] LIKE'" + textBox1.Text + "%'";
                this.dataGridView1.DataSource = actionsBindingSource;
            }
        }
    }
}
