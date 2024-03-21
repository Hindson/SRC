﻿using RCLibrary;
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
    // ToDo #5.4 Таблица с автомобилями +
    public partial class TableAutos : UserControl
    {
        private Auto auto = new Auto();
        private Manager manager = new Manager();

        public TableAutos()
        {
            InitializeComponent();

            // Выпадающий список для поля "Класс авто"
            List<classAuto> cAuto = Enum.GetValues(typeof(classAuto)).Cast<classAuto>().ToList();
            aclassDataGridViewTextBoxColumn.DataSource = cAuto;

            // Выпадающий список для поля "Цвет авто"
            List<colorAuto> colAuto = Enum.GetValues(typeof(colorAuto)).Cast<colorAuto>().ToList();
            acolorDataGridViewTextBoxColumn.DataSource = colAuto;

            // Выпадающий список для поля "Тип КПП авто"
            List<gearboxType> tAuto = Enum.GetValues(typeof(gearboxType)).Cast<gearboxType>().ToList();
            atypeDataGridViewTextBoxColumn.DataSource = tAuto;

            auto.Deserialize();
            autoBindingSource.DataSource = Auto.Autos;
            dataGridView1.ClearSelection();
        }

        private void upDate()
        {
            autoBindingSource.DataSource = "";
            auto.Serialize();
            auto.Deserialize();
            autoBindingSource.DataSource = Auto.Autos;
            dataGridView1.ClearSelection();
        }

        private void tSButton_Add_Click(object sender, EventArgs e)
        {
            new Add_Auto().ShowDialog();
        }

        private void tSButton_Remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                MessageBox.Show("Автомобили отсутствуют в таблице!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                manager.RemoveCar(dataGridView1.CurrentRow.Index);
            }
            upDate();
        }

        private void tSButton_Update_Click(object sender, EventArgs e)
        {
            upDate();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                string? val = e.FormattedValue?.ToString();

                if (val != null)
                {
                    // Проверяем, что изменяется brand
                    if (e.ColumnIndex == dataGridView1.Columns[1].Index)
                    {
                        Auto.Autos[dataGridView1.CurrentRow.Index].Brand = e.FormattedValue?.ToString();
                    }
                    // Проверяем, что изменяется model
                    if (e.ColumnIndex == dataGridView1.Columns[2].Index)
                    {
                        Auto.Autos[dataGridView1.CurrentRow.Index].Model = e.FormattedValue?.ToString();
                    }
                    // Проверяем, что изменяется Класс авто
                    if (e.ColumnIndex == dataGridView1.Columns[3].Index)
                    {
                        Auto.Autos[dataGridView1.CurrentRow.Index].Aclass = (classAuto)Enum.Parse(typeof(classAuto), val);
                    }
                    // Проверяем, что изменяется Тип КПП
                    if (e.ColumnIndex == dataGridView1.Columns[4].Index)
                    {
                        Auto.Autos[dataGridView1.CurrentRow.Index].Atype = (gearboxType)Enum.Parse(typeof(gearboxType), val);
                    }
                    // Проверяем, что изменяется цвет
                    if (e.ColumnIndex == dataGridView1.Columns[5].Index)
                    {
                        Auto.Autos[dataGridView1.CurrentRow.Index].Acolor = (colorAuto)Enum.Parse(typeof(colorAuto), val);
                    }
                    // Проверяем, что изменяется цена аренды
                    if (e.ColumnIndex == dataGridView1.Columns[6].Index)
                    {
                        Auto.Autos[dataGridView1.CurrentRow.Index].DailyPrice = Convert.ToInt16(e.FormattedValue);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                e.Cancel = true;
                dataGridView1.CancelEdit();
                MessageBox.Show(ex.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning); // выводим сообщение об ошибке
            }
        }

        private void textBox_search_KeyUp(object sender, KeyEventArgs e)
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
    }
}
