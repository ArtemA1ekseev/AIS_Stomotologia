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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.consumablesBindingSource.EndEdit();
            this.consumablesTableAdapter.Update(this.stomotologiaDataSet.Consumables);
            dataGridView1.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == consumablesBindingSource)
            {
                consumablesBindingSource.Filter = "[Name] LIKE'" + textBox1.Text + "%'";
                this.dataGridView1.DataSource = consumablesBindingSource;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Consumables". При необходимости она может быть перемещена или удалена.
            this.consumablesTableAdapter.Fill(this.stomotologiaDataSet.Consumables);

        }
    }
}
