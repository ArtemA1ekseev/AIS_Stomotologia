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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Patients". При необходимости она может быть перемещена или удалена.
            this.patientsTableAdapter.Fill(this.stomotologiaDataSet.Patients);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Reviews". При необходимости она может быть перемещена или удалена.
            this.reviewsTableAdapter.Fill(this.stomotologiaDataSet.Reviews);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.reviewsBindingSource.EndEdit();
            this.reviewsTableAdapter.Update(this.stomotologiaDataSet.Reviews);
            dataGridView1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == reviewsBindingSource)
            {
                reviewsBindingSource.Filter = "[TextReview] LIKE'" + textBox1.Text + "%'";
                this.dataGridView1.DataSource = reviewsBindingSource;
            }
        }
    }
}
