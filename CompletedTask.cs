using System.Data;

namespace FormsDatabase
{
    public class CompletedTask
    {
        private DataAccess D = new DataAccess();
        private int _UserID;
        private int _TaskID;
        private string _evidence;
        private string _TimeStamp;

        public int UserID { get => _UserID; set => _UserID = value; }
        public int TaskID { get => _TaskID; set => _TaskID = value; }
        public string Evidence { get => _evidence; set => _evidence = value; }
        public string TStamp { get => _TimeStamp; set => _TimeStamp = value; }

        public CompletedTask(User U, EnTask T, string E, string D) //new entry
        {
            UserID = int.Parse(U.ID);
            TaskID = T.TaskID;
            Evidence = E;
            TStamp = D;
        }

        public CompletedTask(DataRow DR) // Pre-existing from DB
        {
            UserID = int.Parse(DR["UserID"].ToString());
            TaskID = int.Parse(DR["TaskID"].ToString());
            Evidence = DR["Evidence"].ToString();
            TStamp = DR["TSTAMP"].ToString();
        }

        public string FullInfo
        {
            get
            {
                return $"Task: {D.GetTaskName(TaskID)}, TimeStamp: {_TimeStamp}, Evidence: {_evidence}";
            }
        }
    }
}