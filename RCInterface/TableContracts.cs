using RCLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCInterface
{
    public partial class TableContracts : UserControl
    {
        private Contract contract = new Contract();
        private Auto auto = new Auto();
        private Client client = new Client();
        private Manager manager = new Manager();
        public TableContracts()
        {
            InitializeComponent();
            auto.Deserialize();
            manager.Deserialize();
            client.Deserialize();
            contract.Deserialize();

            contractBindingSource.DataSource = Contract.Contracts;
            dataGridView1.ClearSelection();
        }

        // Обновление данных в таблице
        private void upDate()
        {
            contractBindingSource.DataSource = "";
            contract.Serialize();
            contract.Deserialize();
            contractBindingSource.DataSource = Contract.Contracts;
            dataGridView1.ClearSelection();
        }

        private void tSButton_Add_Click(object sender, EventArgs e)
        {
            //new Add_Contract().ShowDialog();
            new Add_Contract().Show();
        }

        private void tSButton_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                MessageBox.Show("Договоры отсутствуют в таблице!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                manager.RemoveContract(dataGridView1.CurrentRow.Index);
            upDate();
        }

        private void tSButton_Update_Click(object sender, EventArgs e)
        {
            upDate();
        }
    }
}
