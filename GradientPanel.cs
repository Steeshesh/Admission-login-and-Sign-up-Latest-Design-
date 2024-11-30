using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    internal class GradientPanel : Panel
    {
        public Color ColorTop { get; set; }
        public Color ColorBottom { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            Color topColorWithOpacity = Color.FromArgb(180, ColorTop);
            Color bottomColorWithOpacity = Color.FromArgb(180, ColorBottom);

            using (LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, topColorWithOpacity, bottomColorWithOpacity, 90F))
            {
                Graphics g = e.Graphics;
                g.FillRectangle(lgb, this.ClientRectangle);
            }

            base.OnPaint(e);
        }
    }
}
