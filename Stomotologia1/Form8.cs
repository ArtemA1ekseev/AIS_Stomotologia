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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Appointments". При необходимости она может быть перемещена или удалена.
            this.appointmentsTableAdapter.Fill(this.stomotologiaDataSet.Appointments);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.Consumables". При необходимости она может быть перемещена или удалена.
            this.consumablesTableAdapter.Fill(this.stomotologiaDataSet.Consumables);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "stomotologiaDataSet.StockRecord". При необходимости она может быть перемещена или удалена.
            this.stockRecordTableAdapter.Fill(this.stomotologiaDataSet.StockRecord);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.stockRecordBindingSource.EndEdit();
            this.stockRecordTableAdapter.Update(this.stomotologiaDataSet.StockRecord);
            dataGridView1.Refresh();
        }

    }
}
