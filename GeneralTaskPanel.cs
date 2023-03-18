using System;
using System.Windows.Forms;

namespace ITask2 {
    public class GeneralTaskPanel : Panel {
        public ITask itask;
        public int curDay = 1;
        public DayTask? dayTask;
        public Label tasksNumber;
        private Button createTaskBtn;
        private Button backToMainBtn;
        private TableLayoutPanel tPanel;
        private PictureBox pictureBox1;

        public GeneralTaskPanel(ITask itask) {
            this.itask = itask;
            this.tasksNumber = new Label();
            this.tPanel = new TableLayoutPanel();
            this.backToMainBtn = new Button();
            this.createTaskBtn = new Button();
            this.pictureBox1 = new PictureBox();
            //////////////////////////////////
            this.Location = new System.Drawing.Point(12, 97);
            this.Name = "TaskPanel";
            this.Size = new System.Drawing.Size(938, 686);
            this.TabIndex = 60;
            this.Visible = false;
            this.tasksNumber.Font = new System.Drawing.Font("Segoe UI", 16.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tasksNumber.ForeColor = System.Drawing.Color.White;
            this.tasksNumber.Location = new System.Drawing.Point(750, 15);
            this.tasksNumber.Size = new System.Drawing.Size(338, 30);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ITask7.Properties.Resources.business_tasklist;
            this.pictureBox1.Location = new System.Drawing.Point(233, 140);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(434, 400);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // tPanel
            // 
            this.tPanel.AutoScroll = true;
            this.tPanel.Location = new System.Drawing.Point(0, 59);
            this.tPanel.Name = "tPanel";
            this.tPanel.Size = new System.Drawing.Size(938, 627);
            this.tPanel.TabIndex = 4;
            this.tPanel.ColumnCount = 1;
            this.tPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            this.tPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize, 100F));
            // 
            // backToMainBtn
            // 
            this.backToMainBtn.Location = new System.Drawing.Point(149, 15);
            this.backToMainBtn.Name = "backToMainBtn";
            this.backToMainBtn.Size = new System.Drawing.Size(101, 38);
            this.backToMainBtn.TabIndex = 3;
            this.backToMainBtn.Text = "<- Back";
            this.backToMainBtn.UseVisualStyleBackColor = true;
            this.backToMainBtn.Click += new EventHandler(backToMainBtn_Click);
            // 
            // createTaskBtn
            // 
            this.createTaskBtn.Location = new System.Drawing.Point(3, 15);
            this.createTaskBtn.Name = "createTaskBtn";
            this.createTaskBtn.Size = new System.Drawing.Size(140, 38);
            this.createTaskBtn.TabIndex = 0;
            this.createTaskBtn.Text = "Create Task";
            this.createTaskBtn.UseVisualStyleBackColor = true;
            this.createTaskBtn.Click += new EventHandler(createTaskBtn_Click);
            this.Controls.Add(this.tasksNumber);
            this.Controls.Add(this.tPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.backToMainBtn);
            this.Controls.Add(this.createTaskBtn);
            this.pictureBox1.BringToFront();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        }
        public void setDayTask(DayTask dayTask) {
            this.dayTask = dayTask;
            this.curDay = dayTask.Day;
            this.reload();
        }
        public void reload() {
            if (this.dayTask == null) {
                return;
            }
            int tasks = this.dayTask.Tasks.Count;
            this.tPanel.Controls.Clear();
            this.tasksNumber.Text = dayTask.Tasks.Count + " Tasks available.";
            if (tasks <= 0) {
                this.pictureBox1.Visible = true;
                return;
            }
            this.pictureBox1.Visible = false;
            foreach (Task t in this.dayTask.Tasks) {
                TaskPanel tp = new TaskPanel(t, this);
                this.tPanel.Controls.Add(tp);
            }
            this.Refresh();
            return;
        }
        public void reloadButons()
        {
            if (this.itask.isTaskView)
            {
                var list = itask.database.TasksInAMonth(this.dayTask.Month);
                if (curDay <= 0)
                {
                    this.itask.PrevBtn.Enabled = false;
                    return;
                }
                if (curDay >= list.Count)
                {
                    this.itask.NextBtn.Enabled = false;
                    return;
                }
                this.itask.NextBtn.Enabled = true;
                this.itask.PrevBtn.Enabled = true;
            } else {
                if (this.itask.app.curMonth <= 1)
                {
                    this.itask.PrevBtn.Enabled = false;
                }
                if (this.itask.app.curMonth >= 12)
                {
                    this.itask.NextBtn.Enabled = false;
                }
                this.itask.NextBtn.Enabled = true;
                this.itask.PrevBtn.Enabled = true;
            }
        }
        public void nextDay() {
            var list = itask.database.TasksInAMonth(this.dayTask.Month);
            if (curDay >= list.Count) {
                this.itask.NextBtn.Enabled = false;
                return;
            }
            if (DayCalendar.isOldDate(list[this.curDay + 2])) {
                this.itask.NextBtn.Enabled = false;
                return;
            }
            this.curDay += 1;
            setDayTask(list[this.curDay - 1]);
            this.itask.PrevBtn.Enabled = true;
            this.itask.NextBtn.Enabled = true;
            this.itask.MonthLabel.Text = this.curDay + " " + this.itask.app.GetMonthName(this.dayTask.Month) + " 2023";
        }
        public void prevDay() {
            var list = itask.database.TasksInAMonth(this.dayTask.Month);
            if (curDay <= 1) {
                this.itask.PrevBtn.Enabled = false;
                return;
            }
            if (DayCalendar.isOldDate(list[this.curDay - 2])) {
                this.itask.PrevBtn.Enabled = false;
                return;
            }
            this.curDay -= 1;
            setDayTask(list[this.curDay - 1]);
            this.itask.PrevBtn.Enabled = true;
            this.itask.NextBtn.Enabled = true;
            this.itask.MonthLabel.Text = this.curDay + " " + this.itask.app.GetMonthName(this.dayTask.Month) + " 2023";
        }
        private void createTaskBtn_Click(object sender, EventArgs e) {
            if (this.dayTask == null) {
                return;
            }
            int curHour = DateTime.Now.Hour;
            int curMinute = DateTime.Now.Minute;
            string desc = Microsoft.VisualBasic.Interaction.InputBox("Task description", "Enter the task description");
            string hour = Microsoft.VisualBasic.Interaction.InputBox("Task hour", "Enter the hour when the task is gonna take place");
            string minute = Microsoft.VisualBasic.Interaction.InputBox("Task minute", "Enter the minute when the task is gonna take place");
            string important = Microsoft.VisualBasic.Interaction.InputBox("Task importance", "Enter the task importance: HIGH, MEDIUM, LOW");
            try
            {
                Importance importance;
                important = important.ToLower();
                switch(important)
                {
                    case "low":
                        importance = Importance.LOW;
                        break;
                    case "medium":
                        importance = Importance.MEDIUM;
                        break;
                    case "high":
                        importance = Importance.HIGH;
                        break;
                    default:
                        importance = Importance.LOW;
                        break;
                }
                int enteredHour = int.Parse(hour);
                int enteredMinute = int.Parse(minute);
                //////////////////////////////////////
                Task task = new Task
                { 
                    Desc = desc,
                    Hour = enteredHour,
                    Minute = enteredMinute,
                    Importance = importance,
                    Day = this.dayTask.Day,
                    UUID = Task.newUUID()
                };
                if (enteredHour < curHour) {
                    MessageBox.Show("Task couldn't be added, you can't enter a hour less than the current hour.");
                    return;
                }
                if (enteredHour >= 24) {
                    MessageBox.Show("Task couldn't be added, the hour must be beetween 1 and 24.");
                    return;
                }
                if (enteredMinute >= 60) {
                    MessageBox.Show("Task couldn't be added, the minute must be beetween 1 and 60.");
                    return;
                }
                if (enteredHour == curHour && enteredMinute < curMinute) {
                    MessageBox.Show("Task couldn't be added, you can't enter a minute less than the current minute.");
                    return;
                }
                this.itask.database.AddTaskInADay(this.itask.app.curMonth, this.dayTask.Day, task);
                MessageBox.Show("Task #" + task.UUID + " have been added in the database.", "Task created", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.reload();
            } catch(Exception ex) {
                MessageBox.Show("Task couldn't be added: " + ex.Message, "Error: " + ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void backToMainBtn_Click(object sender, EventArgs e) {
            this.Visible = false;
            this.itask.isTaskView = false;
            this.itask.MonthLabel.Text = this.itask.app.GetMonthName(this.itask.app.curMonth) + " 2023";
            this.itask.app.generate_days();
            this.reloadButons();
        }
    }
}
