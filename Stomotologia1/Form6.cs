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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.equipmentBindingSource.EndEdit();
            this.equipmentTableAdapter.Update(this.stomotologiaDataSet.Equipment);
            dataGridView1.Refresh();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Appointments". При необходимости она может быть перемещена или удалена.
            this.appointmentsTableAdapter.Fill(this.stomotologiaDataSet.Appointments);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Equipment". При необходимости она может быть перемещена или удалена.
            this.equipmentTableAdapter.Fill(this.stomotologiaDataSet.Equipment);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == equipmentBindingSource)
            {
                equipmentBindingSource.Filter = "[Name] LIKE'" + textBox1.Text + "%'";
                this.dataGridView1.DataSource = equipmentBindingSource;
            }
        }
    }
}
