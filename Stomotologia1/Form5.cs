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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Appointments". При необходимости она может быть перемещена или удалена.
            this.appointmentsTableAdapter.Fill(this.stomotologiaDataSet.Appointments);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Services". При необходимости она может быть перемещена или удалена.
            this.servicesTableAdapter.Fill(this.stomotologiaDataSet.Services);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.servicesBindingSource.EndEdit();
            this.servicesTableAdapter.Update(this.stomotologiaDataSet.Services);
            dataGridView1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == servicesBindingSource)
            {
                servicesBindingSource.Filter = "[Name] LIKE'" + textBox1.Text + "%'";
                this.dataGridView1.DataSource = servicesBindingSource;
            }
        }
    }
}
