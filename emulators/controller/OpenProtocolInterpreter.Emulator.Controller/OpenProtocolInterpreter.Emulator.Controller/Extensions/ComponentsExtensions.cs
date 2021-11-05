using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OpenProtocolInterpreter.Emulator.Controller
{
    public static class ComponentsExtensions
    {
        public static int GetTextAsInt(this TextBox textBox)
        {
            if(int.TryParse(textBox.Text, out int result))
            {
                return result;
            }

            return 0;
        }
    }
}
