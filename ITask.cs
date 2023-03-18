using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ITask2
{
    public partial class ITask : Form {
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);
        private const int WM_NCPAINT = 0x85;
        private bool isDragging = false;
        public bool isTaskView = false;
        private Point dragStart;
        private Button minimizeButton;
        private Button closeButton;
        public App app;
        public Database database;
        public GeneralTaskPanel generalTaskPanel;
        public ITask() { 
            InitializeComponent();
            this.closeButton = new Button();
            this.minimizeButton = new Button();
            this.generalTaskPanel = new GeneralTaskPanel(this);
            this.bordlessWindow();
            this.FormBorderStyle = FormBorderStyle.None;
            this.database = new Database(this);
            this.database.load();
            this.app = new App(this, database);
            this.app.run();
        }
        private void NextBtn_Click(object sender, EventArgs e) {
            this.app.nextMonth();
        }

        private void PrevBtn_Click(object sender, EventArgs e) {
            this.app.prevMonth();
        }

        private void NextBtn_MouseEnter(object sender, EventArgs e)
        {
            this.NextBtn.BackColor = Color.DarkSlateGray;
            this.NextBtn.ForeColor = Color.WhiteSmoke;
        }
        private void NextBtn_MouseLeave(object sender, EventArgs e)
        {
            this.NextBtn.BackColor = Color.LightCyan;
            this.NextBtn.ForeColor = Color.Black;
        }
        private void bordlessWindow() {
            // Set the form style to none so that we can handle mouse events
            this.FormBorderStyle = FormBorderStyle.None;
            this.MouseDown += Form_MouseDown;
            this.MouseMove += Form_MouseMove;
            this.MouseUp += Form_MouseUp;
            Label title = new Label();
            title.Font = new Font("Arial", 14);
            title.ForeColor = Color.White;
            title.Location = new Point(15, 10);
            title.Size = new Size(320, 30);
            title.Text = "📅 ITask - Manage your tasks smart";
            this.Controls.Add(title);
            // Create buttons for minimizing, maximizing, and closing the window
            minimizeButton = new Button();
            minimizeButton.Text = "_";
            minimizeButton.Font = new Font("Arial", 12);
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.ForeColor = Color.White;
            minimizeButton.BackColor = Color.FromArgb(64, 64, 64);
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.Size = new Size(30, 30);
            minimizeButton.Location = new Point(this.ClientSize.Width - 65, 0);
            minimizeButton.Click += MinimizeButton_Click;
            this.Controls.Add(minimizeButton);
            closeButton = new Button();
            closeButton.Text = "X";
            closeButton.Font = new Font("Arial", 12);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.ForeColor = Color.White;
            closeButton.BackColor = Color.FromArgb(64, 64, 64);
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Size = new Size(30, 30);
            closeButton.Location = new Point(this.ClientSize.Width - 30, 0);
            closeButton.Click += CloseButton_Click;
            this.Controls.Add(closeButton);
            this.panel1.Controls.Add(generalTaskPanel);
            this.generalTaskPanel.BringToFront();
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStart = new Point(e.X, e.Y);
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point screenPos = PointToScreen(e.Location);
                this.Location = new Point(screenPos.X - dragStart.X, screenPos.Y - dragStart.Y);
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.database.save();
        }
    }
}
