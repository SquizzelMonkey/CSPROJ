using System.Data;

namespace FormsDatabase
{
    public class TaskSet
    {
        private string _TaskSetName;
        private string taskSetDescription;
        private int _TaskSetID;
        public string TaskSetName { get => _TaskSetName; set => _TaskSetName = value; }
        public string TaskSetDescription { get => taskSetDescription; set => taskSetDescription = value; }
        public int TaskSetID { get => _TaskSetID; set => _TaskSetID = value; }

        public string FullInfo
        {
            get
            {
                return $"ID: {TaskSetID}  Name: {TaskSetName},    Description: {taskSetDescription} ";
            }
        }

        public TaskSet()//If new
        {
            TaskSetID = -1;
        }

        public TaskSet(DataRow DR) //if Existing, override
        {
            TaskSetID = int.Parse(DR["TaskSetID"].ToString());
            taskSetDescription = DR["TaskSetDescription"].ToString();
            TaskSetName = DR["TaskSetName"].ToString();
        }
    }
}