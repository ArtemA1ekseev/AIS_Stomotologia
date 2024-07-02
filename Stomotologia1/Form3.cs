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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.doctorsBindingSource.EndEdit();
            this.doctorsTableAdapter.Update(this.stomotologiaDataSet.Doctors);
            dataGridView1.Refresh();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Doctors". При необходимости она может быть перемещена или удалена.
            this.doctorsTableAdapter.Fill(this.stomotologiaDataSet.Doctors);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == doctorsBindingSource)
            {
                doctorsBindingSource.Filter = "[Specialty] LIKE'" + textBox1.Text + "%'";
                this.dataGridView1.DataSource = doctorsBindingSource;
            }
        }
    }
}
