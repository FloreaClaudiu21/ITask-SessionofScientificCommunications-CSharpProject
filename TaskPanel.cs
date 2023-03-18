using System;
using System.Windows.Forms;


namespace ITask2 {
    public class TaskPanel : Panel {
        private Button dltTaskBtn;
        private Panel taskdelimiter;
        private Label label2;
        private Label taskIDLbl;
        private TextBox descTB;
        private Task task;
        private GeneralTaskPanel taskpanel;

        public TaskPanel(Task task, GeneralTaskPanel gp) {
            this.task = task;
            this.taskpanel = gp;
            this.label2 = new Label();
            this.taskIDLbl = new Label();
            this.descTB = new TextBox();
            this.dltTaskBtn = new Button();
            this.taskdelimiter = new Panel();
            // 
            // descTB
            // 
            this.descTB.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.descTB.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descTB.Location = new System.Drawing.Point(9, 78);
            this.descTB.Multiline = true;
            this.descTB.Name = "descTB";
            this.descTB.Text = this.task.Desc;
            this.descTB.ForeColor = System.Drawing.Color.Black;
            this.descTB.PlaceholderText = "Description of the task";
            this.descTB.ReadOnly = true;
            this.descTB.Size = new System.Drawing.Size(901, 89);
            this.descTB.TabIndex = 6;
            // 
            // dltTaskBtn
            // 
            this.dltTaskBtn.Location = new System.Drawing.Point(838, 14);
            this.dltTaskBtn.Name = "dltTaskBtn";
            this.dltTaskBtn.Size = new System.Drawing.Size(72, 25);
            this.dltTaskBtn.TabIndex = 4;
            this.dltTaskBtn.Text = "DELETE";
            this.dltTaskBtn.UseVisualStyleBackColor = true;
            this.dltTaskBtn.MouseClick += new MouseEventHandler(MouseClickMethod);
            // 
            // taskdelimiter
            // 
            this.taskdelimiter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.taskdelimiter.Location = new System.Drawing.Point(9, 47);
            this.taskdelimiter.Name = "taskdelimiter";
            this.taskdelimiter.Size = new System.Drawing.Size(901, 10);
            this.taskdelimiter.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(766, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 1;
            this.label2.Text =  this.task.Hour + ":" + this.task.Minute;
            // 
            // taskIDLbl
            // 
            this.taskIDLbl.AutoSize = true;
            this.taskIDLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.taskIDLbl.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.taskIDLbl.Location = new System.Drawing.Point(9, 12);
            this.taskIDLbl.Name = "taskIDLbl";
            this.taskIDLbl.Size = new System.Drawing.Size(93, 25);
            this.taskIDLbl.TabIndex = 0;
            this.taskIDLbl.Text = "[" + this.task.Importance.ToString() + "]" + " Task #" + this.task.UUID;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = BorderStyle.Fixed3D;
            ///////////////////////////////////////
            this.Controls.Add(this.descTB);
            this.Controls.Add(this.dltTaskBtn);
            this.Controls.Add(this.taskdelimiter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.taskIDLbl);
            this.Margin = new Padding(3, 3, 3, 10);
            this.Name = "taskipanel";
            this.BackColor = Task.getColor(this.task.Importance);
            this.Size = new System.Drawing.Size(931, 191);
            this.TabIndex = 1;
        }
        private void MouseClickMethod(object sender, EventArgs e) {
            this.taskpanel.itask.database.RemoveTaskInADay(this.taskpanel.itask.app.curMonth, this.task.Day, task);
            MessageBox.Show("Task #" + task.UUID + " have been deleted from the database.", "Task deleted", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            this.taskpanel.reload();
        }
    }
}
