using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ITask2 {
    class DayCalendar : Panel {
        private DayTask dt;
        private Label label;
        private ITask itask;
        private bool disabled;
        private ToolTip toolTip;
        private System.ComponentModel.IContainer components = null;

        public DayCalendar(DayTask dt, ITask itask) {
            this.dt = dt;
            this.itask = itask;
            this.label = new Label();
            this.components = new System.ComponentModel.Container();
            this.toolTip = new ToolTip(this.components);
            if (isOldDate(dt)) {
                this.disabled = true; 
                this.toolTip.ToolTipTitle = "You can't select this day...";
                this.toolTip.SetToolTip(this, "Day too old");
            }
            this.init(dt);
        }
        public static bool isOldDate(DayTask dt) {
            int curDay = DateTime.Now.Day;
            int curMonth = DateTime.Now.Month;
            if(dt.Month < curMonth)
            {
                return true;
            }
            if (dt.Day < curDay && dt.Month == curMonth)
            {
                return true;
            }
            return false;
        }
        private void init(DayTask dt) {
            this.Name = "DayPanel";
            RoundedPanel rp = new RoundedPanel(dt);
            if (this.disabled)
            {
                this.BackColor = System.Drawing.Color.Gray;
            }
            else
            {
                this.BackColor = System.Drawing.SystemColors.ControlLight;
            }
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(115, 105);
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Arial", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label.Location = new System.Drawing.Point(40, 45);
            this.label.Name = "DayLbl";
            this.label.Size = new System.Drawing.Size(20, 20);
            this.label.TabIndex = 33;
            this.label.Text = dt.Day + "";
            this.MouseClick += new MouseEventHandler(MouseClickMethod);
            this.MouseEnter += new EventHandler(MouseEnterMethod);
            this.MouseHover += new EventHandler(MouseEnterMethod);
            this.MouseLeave += new EventHandler(MouseLeaveMethod);
            this.label.MouseEnter += new EventHandler(MouseEnterMethod);
            this.label.MouseHover += new EventHandler(MouseEnterMethod);
            this.label.MouseLeave += new EventHandler(MouseLeaveMethod);
            rp.MouseEnter += new EventHandler(MouseEnterMethod);
            rp.Size = this.Size = new System.Drawing.Size(30, 30);
            rp.Location = new System.Drawing.Point(10, 10);
            this.Controls.Add(rp);
            this.Controls.Add(this.label);
            return;
        }
        private void MouseClickMethod(object sender, EventArgs e) {
            if (this.disabled) return;
            this.itask.isTaskView = true;
            this.itask.generalTaskPanel.Visible = true;
            this.itask.MonthLabel.Text = dt.Day + " " + this.itask.app.GetMonthName(this.itask.app.curMonth) + " 2023";
            this.itask.generalTaskPanel.setDayTask(dt);
            this.itask.generalTaskPanel.reloadButons();
            this.itask.Refresh();
        }
        private void MouseEnterMethod(object sender, EventArgs e) {
            if (disabled) {
                this.BackColor = System.Drawing.Color.DarkGray;
                return;
            }
            this.Cursor = Cursors.Hand;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(95)))), ((int)(((byte)(199)))));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
        }
        private void MouseLeaveMethod(object sender, EventArgs e)
        {
            if (disabled)
            {
                this.BackColor = System.Drawing.Color.Gray;
                return;
            }
            this.Cursor = Cursors.Default;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ForeColor = System.Drawing.Color.Black;
        }
    }
    class RoundedPanel : Panel {
        private DayTask dt; 
        private Label text;
        public int Radius { get; set; }
       
        public RoundedPanel(DayTask dt) {
            this.dt = dt;
            this.Radius = 15;
            this.Visible = false;
            this.text = new Label();
            this.Size = new System.Drawing.Size(30, 30);
            this.text.Text = this.dt.Tasks.Count.ToString();
            this.text.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.text.Location = new System.Drawing.Point(5, 7);
            this.Font = new System.Drawing.Font("Arial", 12);
            this.Controls.Add(text);
            if (this.dt.Tasks.Count > 0) {
                this.Visible = true;
            }
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            int radius = this.Radius;
            System.Drawing.Graphics graphics = e.Graphics;
            this.BackColor = Task.getColor(dt.Tasks[dt.Tasks.Count - 1].Importance);
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectangle.X, rectangle.Y, radius * 2, radius * 2, 180, 90);
            path.AddLine(rectangle.X + radius, rectangle.Y, rectangle.X + rectangle.Width - radius * 2, rectangle.Y);
            path.AddArc(rectangle.X + rectangle.Width - radius * 2, rectangle.Y, radius * 2, radius * 2, 270, 90);
            path.AddLine(rectangle.X + rectangle.Width, rectangle.Y + radius * 2, rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height - radius * 2);
            path.AddArc(rectangle.X + rectangle.Width - radius * 2, rectangle.Y + rectangle.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddLine(rectangle.X + rectangle.Width - radius * 2, rectangle.Y + rectangle.Height, rectangle.X + radius * 2, rectangle.Y + rectangle.Height);
            path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.AddLine(rectangle.X, rectangle.Y + rectangle.Height - radius * 2, rectangle.X, rectangle.Y + radius * 2);
            this.Region = new System.Drawing.Region(path);
        }
    }
}
