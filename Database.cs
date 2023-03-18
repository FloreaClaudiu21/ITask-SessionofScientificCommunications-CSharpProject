using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Windows.Forms;

namespace ITask2 {
    public class Database
    {
        private ITask itask;
        private List<MonthTasks> Month;
        public Database(ITask itask)
        {
            this.itask = itask;
            this.Month = new List<MonthTasks>();
        }
        public void save() {
            try
            {
                var json = JsonSerializer.Serialize<List<MonthTasks>>(this.Month, new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                });
                File.WriteAllText("database.json", json);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error: Couldn't save the data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            return;
        }
        public void load() {
            try {
                string json = File.ReadAllText("database.json");
                var list = JsonSerializer.Deserialize<List<MonthTasks>>(json, new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                });
                if (list != null && list.Count > 0 && list[0].Days?.Count > 0) {
                    int curDay = DateTime.Now.Day;
                    int curHour = DateTime.Now.Hour;
                    int curMonth = DateTime.Now.Month;
                    int curMinute = DateTime.Now.Minute;
                    for (int i = 0; i < list.Count; i++) {
                        MonthTasks mt = list[i];
                        List<DayTask> dtl = mt.Days;
                        for (int i1 = 0; i1 < dtl.Count; i1++) {
                            DayTask dt = dtl[i1];
                            for (int i2 = 0; i2 < dt.Tasks.Count; i2++) {
                                Task task = dt.Tasks[i2];
                                int day = task.Day;
                                int hour = task.Hour;
                                int min = task.Minute;
                                if (mt.Month < curMonth || (day < curDay) || (min < curMinute && hour < curHour)) {
                                    dt.Tasks.Remove(task);
                                }
                            }
                        }
                    }
                    this.Month = list;
                } else {
                    List<MonthTasks> list1 = new List<MonthTasks>();
                    for (int i = 1; i <= 12; i++)
                    {
                        MonthTasks mt = new MonthTasks();
                        List<DayTask> dtl = new List<DayTask>();
                        List<App.DayInfo> month_days = App.GetMonthDays(i);
                        month_days.ForEach((md) =>
                        {
                            DayTask day_task = new DayTask(md.DayNumber, i);
                            day_task.DayName = md.DayName;
                            dtl.Add(day_task);
                        });
                        mt.Month = i;
                        mt.Days = dtl;
                        list1.Add(mt);
                    }
                    this.Month = list1;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error: Couldn't load the data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                this.itask.Close();
            }
            return;
        }
        public List<MonthTasks> MonthTasks()
        {
            return this.Month;
        }
        public void AddTasksInAMonth(int month, DayTask task)
        {
            List<DayTask> list = this.TasksInAMonth(month);
            list.Add(task);
            return;
        }
        public void AddTaskInADay(int month, int day, Task task)
        {
            List<Task> list = this.TasksInADay(month, day);
            list.Add(task);
            return;
        }
        public void RemoveTaskInADay(int month, int day, Task task)
        {
            List<Task> list = this.TasksInADay(month, day);
            list.Remove(task);
            return;
        }
        public List<DayTask> TasksInAMonth(int month)
        {
            if (month < 1 || month > 12)
            {
                month = 1;
            }
            List<DayTask> list = new List<DayTask>();
            this.Month.ForEach((m) =>
            {
                if (m.Month == month)
                {
                    list = m.Days;
                }
            });
            return list;
        }
        public List<Task> TasksInADay(int month, int day)
        {
            List<Task> dayTasksList = new List<Task>();
            List<DayTask> dayTasks = TasksInAMonth(month);
            dayTasks?.ForEach((t) =>
            {
                if (t.Day == day)
                {
                    dayTasksList = t.Tasks;
                }
            });
            return dayTasksList;
        }
        public Task LastTaskInADay(int month, int day)
        {
            List<Task> daysTasks = this.TasksInADay(month, day);
            return daysTasks[daysTasks.Count - 1];
        }
        public Task? TaskInADay(string uuid, int month, int day)
        {
            Task? task = null;
            List<Task> daysTasks = this.TasksInADay(month, day);
            daysTasks.ForEach((t) =>
            {
                if (t.UUID.Equals(uuid))
                {
                    task = t;
                }
            });
            return task;
        }
    }
    public enum Importance
    {
        HIGH,
        MEDIUM,
        LOW,
    }
    public class MonthTasks {
        public int Month { get; set; }
        public List<DayTask> Days { get; set; }
    }
    public class DayTask
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public string DayName { get; set; }
        public List<Task> Tasks { get; set; }
        public DayTask(int day, int month)
        {
            this.Day = day;
            this.Month = month;
            this.DayName = "";
            this.Tasks = new List<Task>();
        }
    }
    public class Task {
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public String? Desc { get; set; }
        public String? UUID { get; set; }
        public bool Notified { get; set; }
        public Importance Importance { get; set; }

        public static String newUUID()
        {
            return System.Guid.NewGuid().ToString();
        }
        public static System.Drawing.Color getColor(Importance Important)
        {
            System.Drawing.Color color = System.Drawing.Color.AliceBlue;
            switch (Important)
            {
                case Importance.HIGH:
                    {
                        color = System.Drawing.Color.Red;
                        break;
                    }
                case Importance.MEDIUM:
                    {
                        color = System.Drawing.Color.Orange;
                        break;
                    }
                case Importance.LOW:
                    {
                        color = System.Drawing.Color.Green;
                        break;
                    }
                default:
                    break;
            }
            return color;
        }
    }
}
