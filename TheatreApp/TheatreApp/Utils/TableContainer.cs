using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheatreApp.Utils
{
    // Class that represent a general table to be drawn in form
    public class TableContainer : UIView
    {
        // Fields declaration
        public event EventHandler<OrderedDictionary> StartEditRow;
        private DataGridView table;
        private DataGridView _table {
            get
        {
            if (table == null) 
            {
                table = new DataGridView();
                table.AutoGenerateColumns = true;

                table.AutoSize = true;
                table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

                table.Location = new System.Drawing.Point(50, 100);
                table.BorderStyle = BorderStyle.None;
                table.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
                table.Name = "DataTable";
                table.TabIndex = 2;
                table.RowHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(rowClicked);
            }
         return table;
        }
            set 
            {
                table = value;
              }
        }

        private Form hostForm;

        // Initializer

        public TableContainer()
        {

        }

        // Methods

        private void rowClicked(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            OrderedDictionary output = new OrderedDictionary();

            foreach (DataGridViewColumn column in this.table.Columns)
            {
                string header = column.HeaderText.ToString();
                string content = this.table[column.Index, e.RowIndex].Value.ToString();
                output.Add(header, content);
            }

            if (StartEditRow != null)
            {
                StartEditRow(this, output);
            }
        }

        public override void dismissFromContainer()
        {
            this.hostForm.Controls.Remove(this._table);
        }

 
        public override void drawInForm(Form form)
        {
            this.hostForm = form;
            form.Controls.Add(this._table);
        }


        public override void refreshWithData(Array data)
        {
            this._table.DataSource = data;
            this._table.Refresh();
        }
    }
}
