using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cook_Book.Services
{
    public class ThemedTabControl : TabControl
    {
        // static propertied for universal sharing
        public static Color GlobalActiveBackColor { get; set; } = ColorTranslator.FromHtml("#007BFF");
        public static Color GlobalInactiveBackColor { get; set; } = ColorTranslator.FromHtml("#F0F0F0");
        public static Color GlobalActiveForeColor { get; set; } = Color.White;
        public static Color GlobalInactiveForeColor { get; set; } = Color.Black;
        public static Color GlobalPageBackColor { get; set; } = ColorTranslator.FromHtml("#F0F0F0");
        public static Color GlobalBorderColor { get; set; } = ColorTranslator.FromHtml("#F0F0F0");

        public ThemedTabControl()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            Color backColor = isSelected ? GlobalActiveBackColor : GlobalInactiveBackColor;
            Color textColor = isSelected ? GlobalActiveForeColor : GlobalInactiveForeColor;

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            TextRenderer.DrawText(
                e.Graphics,
                this.TabPages[e.Index].Text,
                this.Font,
                e.Bounds,
                textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );

            //Draw border around tab
            using (Pen borderPen = new Pen(GlobalBorderColor))
            {
                e.Graphics.DrawRectangle(borderPen, e.Bounds);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Fill the entire control background
            using (SolidBrush backBrush = new SolidBrush(GlobalPageBackColor))
            {
                e.Graphics.FillRectangle(backBrush, this.ClientRectangle);
            }

            // Draw border around the entire tab control
            using (Pen borderPen = new Pen(GlobalBorderColor))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
            }

            // Let base class handle the rest (tabs, etc.)
            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Paint *everything* including the tab strip background
            using (SolidBrush brush = new SolidBrush(GlobalInactiveBackColor))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            // Ensure each TabPage respects the theme background
            if (e.Control is TabPage page)
            {
                page.BackColor = GlobalPageBackColor;
                page.ForeColor = GlobalInactiveForeColor;
            }
        }

    }
}
