using System.Data;

namespace FormsDatabase
{
    public class User
    {
        public string UserType { get; set; }
        public string ID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public bool DA { get; set; }
        public bool SEND { get; set; }
        public int YearGroup { get; set; }
        public string TutorGroup { get; set; }
        public double PointScoreY1 { get; set; }
        public double PointScoreY2 { get; set; }
        public double PointScoreY3 { get; set; }
        public double PointScoreY4 { get; set; }
        public double PointScoreY5 { get; set; }
        private string aca = new DataAccess().GetAcademicYear();

        public string FullInfo
        {
            get
            {
                return $"({UserType}), ID: {ID} . {Forename} {Surname} - {12 - (YearGroup - int.Parse(aca))}{TutorGroup},DA: {DA} , SEND: {SEND} , Points: Y7:{PointScoreY1}, Y8:{PointScoreY2}, Y9:{PointScoreY3}, Y10:{PointScoreY4}, Y11:{PointScoreY5}";
            }
        }

        public User()//If new
        {
            ID = "-1";
        }

        public User(DataRow DR) //if Existing, override
        {
            UserType = DR["UserType"].ToString();
            ID = DR["UserID"].ToString();
            Forename = DR["Forename"].ToString();
            Surname = DR["Surname"].ToString();
            DA = bool.Parse(DR["DA"].ToString());
            SEND = bool.Parse(DR["SEND"].ToString());
            YearGroup = int.Parse(DR["YearGroup"].ToString());
            TutorGroup = DR["TutorGroup"].ToString();
            try
            {
                PointScoreY1 = double.Parse(DR["PointScoreY1"].ToString());
                PointScoreY2 = double.Parse(DR["PointScoreY2"].ToString());
                PointScoreY3 = double.Parse(DR["PointScoreY3"].ToString());//if points available
                PointScoreY4 = double.Parse(DR["PointScoreY4"].ToString());
                PointScoreY5 = double.Parse(DR["PointScoreY5"].ToString());
            }
            catch
            {
                PointScoreY1 = 0;
                PointScoreY2 = 0;
                PointScoreY3 = 0;
                PointScoreY4 = 0;
                PointScoreY5 = 0;//default to 0
            }
        }
    }
}