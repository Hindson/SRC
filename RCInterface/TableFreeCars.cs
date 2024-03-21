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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RCInterface
{
    public partial class TableFreeCars : UserControl
    {
        private FreeCars freeCars = new FreeCars();
        public TableFreeCars()
        {
            InitializeComponent();
            startDateTimePicker.MinDate = DateTime.Today;
            endDateTimePicker.MinDate = DateTime.Today;
        }

        private void searchFreeCar()
        {
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = freeCars.AvailableCars(startDateTimePicker.Value.Date, endDateTimePicker.Value.Date); ;
        }

        private void startDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            searchFreeCar();
            endDateTimePicker.MinDate = startDateTimePicker.Value;
        }

        private void endDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            searchFreeCar();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_search.Text))
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                    dataGridView1.Rows[i].Visible = true;
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.CurrentCell = null;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Visible = false;
                    dataGridView1.Rows[i].Selected = false;

                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox_search.Text))
                            {
                                dataGridView1.Rows[i].Visible = true;
                                dataGridView1.Rows[i].Selected = true;
                            }
                }
            }
        }

        private void textBox_search_KeyUp(object sender, KeyEventArgs e)
        {

        }

        // Определение свойства
        public Auto? SelectedAuto
        {
            get
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Получение выделенной строки
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Получение объекта Manager из свойства DataBoundItem строки
                    return (Auto)selectedRow.DataBoundItem;
                }

                return null;
            }
        }

        public DateTime startDate
        {
            get { return startDateTimePicker.Value.Date; }
        }

        public DateTime endDate
        {
            get { return endDateTimePicker.Value.Date; }
        }
    }
}
