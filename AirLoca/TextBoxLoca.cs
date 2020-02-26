using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AirLoca
{
    public class TextBoxLoca : TextBox
    {
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                    base.Text = value.Trim();
            }
        }
    }
}