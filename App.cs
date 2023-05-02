using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ITask2
{
    public class App {
        private ITask itask;
        private Database db;
        private String toEmail;
        private Timer timer1;
        public int curMonth { get; set; }
        public int gap { get; set; }
        private int Count { get; set; }
        public App(ITask itask, Database db) {
            this.db = db;
            this.gap = 15;
            this.toEmail = "";
            this.curMonth = 1;
            this.itask = itask;
            this.timer1 = new Timer();
            this.itask.PrevBtn.Enabled = false;
            this.timer1.Tick += new System.EventHandler(timer1_Tick);
        }
        public class DayInfo
        {
            public int DayYear { get; set; }
            public string? DayName { get; set; }
            public int DayNumber { get; set; }
            public int DayTasks { get; set; }
            public DayInfo() { }
        }
        public void run() {
            this.generate_days();
            this.timer1.Enabled = true;
            this.toEmail = Microsoft.VisualBasic.Interaction.InputBox("Email address", "Enter your email address");
            if (!IsValidEmail(toEmail)) {
                MessageBox.Show("Wrong email address", "Error: Email wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.itask.Close();
                return;
            }
        }
        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();
            if (trimmedEmail.EndsWith(".")) {
                return false;
            }
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e) {
            int curDay = DateTime.Now.Day;
            int curHour = DateTime.Now.Hour;
            int curMonth = DateTime.Now.Month;
            int curMinute = DateTime.Now.Minute;
            List<Task> tasks = itask.database.TasksInADay(curMonth, curDay);
            for (int i = 0; i < tasks.Count; i++) {
                Task task = tasks[i];
                int min = task.Minute;
                int hour = task.Hour;
                if (curMinute == min && curHour == hour) {
                    itask.database.RemoveTaskInADay(curMonth, curDay, task);
                    sendMail("Task #" + task.UUID + " is ready!", task.Desc);
                    MessageBox.Show(task.Desc, "Task #" + task.UUID + " is ready!");
                    if (itask.generalTaskPanel.curDay == curDay) {
                        this.itask.generalTaskPanel.reload();
                    }
                    if (this.curMonth == curMonth) {
                        this.generate_days();
                    }
                } else if ((min - curMinute) == 1 && !task.Notified) {
                    task.Notified = true;
                    sendMail("Task #" + task.UUID + " is about to start in 1 minute!", task.Desc);
                    MessageBox.Show(task.Desc, "Task #" + task.UUID + " is about to start in 1 minute!");
                }
            };
        }
  
       private void sendMail(String subject, String body) {
            string fromEmail = "floreaclaudiu128@gmail.com";
            ////////////////////////////////////////////////
             try {
                SmtpClient smtpClient = new SmtpClient("smtp.elasticemail.com", 2525);
                smtpClient.Credentials = new NetworkCredential("floreaclaudiu37@yahoo.com", "9D4B5865DD230BE31416D1270CEB98A79D8F");
                smtpClient.EnableSsl = true;
                MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body);
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
       }

        public void generate_days() {
            int x = 15;
            int y = 10;
            this.Count = 0;
            this.itask.DaysPanel.Controls.Clear();
            this.itask.loadingpanel.Visible = true;
            this.itask.Refresh();
            if (!this.itask.isTaskView)
            {
                this.itask.MonthLabel.Text = GetMonthName(this.curMonth) + " 2023";
            } else
            {
                this.itask.MonthLabel.Text = this.itask.generalTaskPanel.curDay + " " + GetMonthName(this.curMonth) + " 2023";
            }
            List<DayTask> daysMonth = db.TasksInAMonth(this.curMonth);
            daysMonth.ForEach((day) =>
            {
                if (this.Count >= 7)
                {
                    this.Count = 0;
                    y += 120;
                    x = 15;
                }
                switch (this.Count)
                {
                    case 0:
                        itask.Day1Lbl.Text = day.DayName.ToUpper();
                        break;
                    case 1:
                        itask.Day2Lbl.Text = day.DayName.ToUpper();
                        break;
                    case 2:
                        itask.Day3Lbl.Text = day.DayName.ToUpper();
                        break;
                    case 3:
                        itask.Day4Lbl.Text = day.DayName.ToUpper();
                        break;
                    case 4:
                        itask.Day5Lbl.Text = day.DayName.ToUpper();
                        break;
                    case 5:
                        itask.Day6Lbl.Text = day.DayName.ToUpper();
                        break;
                    case 6:
                        itask.Day7Lbl.Text = day.DayName.ToUpper();
                        break;
                    default: break;
                }
                DayCalendar dc = new DayCalendar(day, itask);
                dc.SetBounds(x, y, 115, 105);
                itask.DaysPanel.Controls.Add(dc);
                x += (115 + this.gap);
                this.Count += 1;
            });
            this.itask.loadingpanel.Visible = false;
            return;
        }
        public static List<DayInfo> GetMonthDays(int month)
        {
            var year = DateTime.Now.Year;
            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                .Select(day => new DayInfo
                {
                    DayName = new DateTime(year, month, day).ToString("dddd"),
                    DayNumber = day,
                    DayTasks = 1,
                    DayYear = year
                })
                .ToList();
        }
        public String GetMonthName(int month)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month).ToUpper();
        }
        public void nextMonth()
        {
            if (!this.itask.isTaskView)
            {
                this.itask.loadingpanel.Visible = true;
                this.itask.Refresh();
                this.curMonth += 1;
                if (this.curMonth >= 12)
                {
                    this.itask.NextBtn.Enabled = false;
                }
                this.generate_days();
                this.itask.PrevBtn.Enabled = true;
                this.itask.loadingpanel.Visible = false;
            }
            else
            {
                this.itask.generalTaskPanel.nextDay();
            }
        }
        public void prevMonth()
        {
            if (!this.itask.isTaskView)
            {
                this.itask.loadingpanel.Visible = true;
                this.itask.Refresh();
                this.curMonth -= 1;
                if (this.curMonth <= 1)
                {
                    this.itask.PrevBtn.Enabled = false;
                }
                this.generate_days();
                this.itask.NextBtn.Enabled = true;
                this.itask.loadingpanel.Visible = false;

            }
            else
            {
                this.itask.generalTaskPanel.prevDay();
            }
        }
    }
}
