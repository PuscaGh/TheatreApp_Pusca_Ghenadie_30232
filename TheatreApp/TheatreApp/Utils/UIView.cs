using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheatreApp.Utils
{
    // Generic view to be represented in host form
    public abstract class UIView
    {
        // Delete view from host form
        public abstract void dismissFromContainer();
        // Draw the view in a specified form,this form will become host form
        public abstract void drawInForm(Form form);
        // Refresh the view with data
        public abstract void refreshWithData(Array data);
    }
}
