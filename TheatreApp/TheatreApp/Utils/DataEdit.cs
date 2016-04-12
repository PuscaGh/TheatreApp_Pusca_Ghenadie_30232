using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheatreApp.Utils
{
    // Class that represent a container with labels and coresponding text boxes
    public class DataEdit : UIView
    {
        public event EventHandler<OrderedDictionary> FinishEdit;
        private Form hostForm;
        private ListView container;
        private OrderedDictionary fields;
        private OrderedDictionary output;
        private Button okButton;
 
        public DataEdit()
        {
            fields = new OrderedDictionary();
            output = new OrderedDictionary();
            container = new ListView();
            container.Location = new System.Drawing.Point(178, 194);
            container.Size = new System.Drawing.Size(300, 300);
            container.BorderStyle = BorderStyle.None;
            container.BackColor = System.Drawing.SystemColors.ActiveBorder;
        }

        public override void dismissFromContainer()
        {
            this.fields.Clear();
            this.output.Clear();
            this.container.Controls.Clear();
            hostForm.Controls.Remove(this.container);
        }

        public override void refreshWithData(Array data)
        {
              int xLoc = 30;
              int yLoc = 30;
              int yOffset = 50;
              int counter = 0;
              int xOffset = 70;
            foreach(Tuple<String,String> tuple in data)
            {
                Label label = new Label();
                label.Text = tuple.Item1;
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(xLoc, yLoc + counter * yOffset);

                TextBox textBox = new TextBox();
                textBox.Location = new System.Drawing.Point(xLoc + xOffset, yLoc + counter * yOffset);
                textBox.Size = new System.Drawing.Size(100, 20);
                textBox.Text = tuple.Item2;
                fields.Add(tuple.Item1, textBox);

                this.fields.Add(label, textBox);
                this.container.Controls.Add(label);
                this.container.Controls.Add(textBox);
                counter += 1;
            }

            okButton = new Button();
            okButton.Click += new EventHandler(okButton_Click);
            okButton.Text = "OK";
            okButton.Location = new System.Drawing.Point(xLoc + xOffset, yLoc + counter * yOffset);
            container.Controls.Add(okButton);
        }

        public void okButton_Click(object sender, EventArgs e)
        {
            foreach (DictionaryEntry entr in this.fields)
            {
                string label = entr.Key.ToString();
                TextBox textBox = (TextBox)entr.Value;

                output.Add(label, textBox.Text.ToString());
            }

            if (FinishEdit != null)
            {
                FinishEdit(this, output);
            }
            output.Clear();
        }

        public override void drawInForm(Form form)
        {
            this.hostForm = form;
            form.Controls.Add(this.container);
        }
    }
}
