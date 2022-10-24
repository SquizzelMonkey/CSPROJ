using System.Data;

namespace FormsDatabase
{
    public class EnTask
    {
        private DataAccess D = new DataAccess();
        private string _TaskName;
        private int _TaskID;
        private int _TaskSet;//compositeKey
        private int _Points;

        public string TaskName { get => _TaskName; set => _TaskName = value; }
        public int TaskID { get => _TaskID; set => _TaskID = value; }
        public int TaskSetID { get => _TaskSet; set => _TaskSet = value; }
        public int Points { get => _Points; set => _Points = value; }

        public EnTask()//If new
        {
            TaskID = -1;
        }

        public EnTask(DataRow DR) //if Existing, override
        {
            TaskSetID = int.Parse(DR["TaskSet"].ToString());
            TaskName = DR["Task"].ToString();
            TaskID = int.Parse(DR["TaskID"].ToString());
            Points = int.Parse(DR["Points"].ToString());
        }

        public string GetTSName(int tID)//get name from ID
        {
            string name = "";
            foreach (TaskSet TS in D.tasksetList())
            {
                if (TS.TaskSetID == tID)
                {
                    name = TS.TaskSetName;
                }
            }
            return name;
        }

        public string FullInfo
        {
            get
            {
                return $"taskSetID:{TaskSetID}({GetTSName(TaskSetID)}), Name:{TaskName},taskID: {TaskID}, points: {Points} ";
            }
        }
    }
}