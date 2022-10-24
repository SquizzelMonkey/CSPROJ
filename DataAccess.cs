using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace FormsDatabase
{
    public class DataAccess
    {
        /// <summary>
        /// To Setup with correct connections and file paths:  (Should just be able to change the Drive name)
        /// Use find function.
        /// SaltFinder = Salt.txt locations
        /// ConnFinder = Connection string locations
        /// ReportFinder = Report.txt locations
        /// </summary>

        private OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\FormsDatabase\FormsDatabase\TrackerDatabase.accdb"); //ConnFinder

        #region User

        public List<User> GetUsers(string LastName, string Year, string Form, bool DAtick, bool SENDtick)
        {
            string queryString;
            var OutputList = new List<User>();

            queryString = "SELECT * FROM Users";

            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(queryString, conn);//get data from DB
            DataTable Results = new DataTable();
            da.Fill(Results);
            string AcaYear = GetAcademicYear();
            foreach (DataRow dr in Results.Rows)
            {
                User U = new User(dr);
                if (LastName != "")//If using name search - overrides all filters
                {
                    if (U.Surname == LastName) { OutputList.Add(U); }
                }
                else
                {
                    string NewYear = Year.Replace("Year ", "");//gets year as just the number, but does not replace "all years" as it is not a direct match
                    if ((12 - (U.YearGroup - int.Parse(AcaYear))).ToString() == NewYear || Year == "All Years")
                    {
                        if (((Form == "All Tutor Groups") || (Form == U.TutorGroup.ToString())))//Filter by Form
                        {
                            if (DAtick == U.DA || DAtick == false)//DA Filter
                            {
                                if (SENDtick == U.SEND || SENDtick == false)//SEND filter
                                {
                                    OutputList.Add(U);//Adds to list ready to be displayed
                                }
                            }
                        }
                    }
                }
                conn.Close();

            }
            return OutputList;
        }

        public void AddUser(string UserType, string FirstName, string LastName, string Year, string Form, bool DAtick, bool SENDtick)
        {
            string AcaYear = GetAcademicYear();
            User NewUser = new User();
            NewUser.ID = "-1"; //newUser
            NewUser.UserType = UserType;
            NewUser.Forename = FirstName;
            NewUser.Surname = LastName;
            NewUser.YearGroup = int.Parse(AcaYear) + (12 - int.Parse(Year));//year of leaving school
            NewUser.TutorGroup = Form;
            NewUser.DA = DAtick;
            NewUser.SEND = SENDtick;
            SaveUser(NewUser.ID, NewUser.UserType, NewUser.Forename, NewUser.Surname, NewUser.YearGroup.ToString(), NewUser.TutorGroup, NewUser.DA, NewUser.SEND);
        }

        public void SaveUser(string ID, string UserType, string FirstName, string LastName, string Year, string Form, bool DAtick, bool SENDtick)
        {
            conn.Open();
            if (ID == "-1") // First Time
            {
                string isql = "INSERT INTO Users (UserType,Forename,Surname,YearGroup,TutorGroup,DA,SEND) VALUES (?,?,?,?,?,?,?)";
                OleDbCommand Cmd = new OleDbCommand(isql, conn);
                Cmd.Parameters.AddWithValue("UserType", UserType);
                Cmd.Parameters.AddWithValue("Forename", FirstName);
                Cmd.Parameters.AddWithValue("Surname", LastName);
                Cmd.Parameters.AddWithValue("YearGroup", Year);
                Cmd.Parameters.AddWithValue("Tutorgroup", Form);
                Cmd.Parameters.AddWithValue("DA", DAtick);
                Cmd.Parameters.AddWithValue("SEND", SENDtick);
                Cmd.ExecuteNonQuery();
                Cmd.CommandText = "Select @@Identity";
                ID = Cmd.ExecuteScalar().ToString();
            }
            else // existing User
            {
                string isql = "INSERT INTO Users (UserType,ID,Forename,Surname,YearGroup,TutorGroup,DA,SEND) VALUES (?,?,?,?,?,?,?,?)";
                OleDbCommand Cmd = new OleDbCommand(isql, conn);
                Cmd.Parameters.AddWithValue("UserType", UserType);
                Cmd.Parameters.AddWithValue("Forename", FirstName);
                Cmd.Parameters.AddWithValue("Surname", LastName);
                Cmd.Parameters.AddWithValue("YearGroup", Year);
                Cmd.Parameters.AddWithValue("Tutorgroup", Form);
                Cmd.Parameters.AddWithValue("DA", DAtick);
                Cmd.Parameters.AddWithValue("SEND", SENDtick);
                Cmd.Parameters.AddWithValue("ID", ID);
                Cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public string getSplitname()
        {
            string Username = Environment.UserName.ToString(); // the line below overrides this, but this is how normally it would find the currently logged in username.
            Username = "26Stuart.Lucas@lhs.aspireplus.org.uk"; // an example of a working username
            ///////REGEX VALIDATION///////
            string UNregex = "[1-9]{2}[A-z]+.[A-z]+@lhs.aspireplus.org.uk";
            bool validity = regex_Validation(Username, UNregex);
            //////////////////////////////

            if (validity == true)
            {
                int counter = 0;
                int counter2 = 0;
                foreach (char c in Username)//get forename length
                {
                    if (c == '.')
                    {
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }
                foreach (char c2 in Username.Remove(0, counter))//get surname length
                {
                    if (c2 == '@')
                    {
                        break;
                    }
                    else
                    {
                        counter2++;
                    }
                }

                //split down the username and recombine with commas in correct places
                string year = Username.Substring(0, 2);
                string forename = Username.Substring(2, counter - 2);
                string surname = Username.Substring(counter + 1, counter2 - 1);

                return year + "," + forename + "," + surname;
            }
            else
            {
                System.Environment.Exit(1);//exit if Username is invalid
                return null;
            }
        }

        public string GetUsertype()
        {//YearForename.Surname@.....
            string FormToLoad = "";
            string name = getSplitname();
            string[] splitName = name.Split(',');
            string year = "20" + splitName[0];
            string forename = splitName[1];
            string surname = splitName[2];
            DataAccess da = new DataAccess();

            string ThisUser = GetThisUserinfo(forename, surname, year, da);
            string t1 = ThisUser.Substring(1, 1);
            string t2 = ThisUser.Substring(1, 3);
            if (ThisUser.Substring(1, 1) == "A")// load based on this user's auth level
            {
                FormToLoad = "ADMIN";
            }
            if (ThisUser.Substring(1, 3) == "Sta")
            {
                FormToLoad = "STAFF";
            }
            if (ThisUser.Substring(1, 3) == "Stu")
            {
                FormToLoad = "STUDENT";
            }

            return FormToLoad;
        }

        public string GetThisUserinfo(string forename, string surname, string year, DataAccess da)
        {
            string ThisUser = "";
            foreach (User U in da.GetUsers("", "All Years", "All Tutor Groups", false, false))
            {
                if ((U.Forename == forename))
                {
                    if ((U.Surname == surname))
                    {
                        if ((U.YearGroup.ToString() == year))
                        {
                            ThisUser = U.FullInfo;// if name and year match fully, return user FULLINFO
                        }
                    }
                }
            }
            return ThisUser;
        }

        public List<User> getUser(string forename, string surname, string year, DataAccess da)
        {
            List<User> TheUserList = new List<User>();
            foreach (User U in da.GetUsers("", "All Years", "All Tutor Groups", false, false))
            {
                if ((U.Forename == forename))
                {
                    if ((U.Surname == surname))
                    {
                        if ((U.YearGroup.ToString() == "20" + year))
                        {
                            TheUserList.Add(U);//if filters match, return User OBJECT
                        }
                    }
                }
            }
            return TheUserList; // this should only contain one user. However, returning a user object outright requires some fields to become public that should remain private (May just be a VS thing)
        }
        public void AnnihilateUser(string ID)//removes ALL RECORDS associated with the user.
        {
            conn.Open();
            string isql = $"DELETE FROM Users WHERE UserID = {ID}";
            OleDbCommand Cmd = new OleDbCommand(isql, conn);
            Cmd.ExecuteNonQuery();
            isql = $"DELETE FROM CompletedTask WHERE UserID = {ID}";
            Cmd = new OleDbCommand(isql, conn);
            Cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AnnihilateYear(string Year)//removes all users in a given year. Used to wipe a year out after they leave the school.
        {
            conn.Open();
            string isql = $"DELETE FROM Users WHERE YearGroup = {Year}";
            OleDbCommand Cmd = new OleDbCommand(isql, conn);
            Cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void AmendUser(string ID, string UserType, string FirstName, string LastName, string Year, string Form, bool DAtick, bool SENDtick, string PSY1, string PSY2, string PSY3, string PSY4, string PSY5)
        {
            List<string> commands = new List<string>();
            string AcaYear = GetAcademicYear();
            int NY = int.Parse(AcaYear) + (12 - int.Parse(Year));

            string isql = $"UPDATE Users SET UserType = '{UserType}' WHERE UserID = {ID}";
            commands.Add(isql);
            isql = $"UPDATE Users SET Forename = '{FirstName}' WHERE UserID = {ID}";
            commands.Add(isql);
            isql = $"UPDATE Users SET Surname = '{LastName}' WHERE UserID = {ID}";
            commands.Add(isql);
            isql = $"UPDATE Users SET YearGroup = {NY} WHERE UserID = {ID}";
            commands.Add(isql);
            isql = $"UPDATE Users SET TutorGroup = '{Form}' WHERE UserID = {ID}";
            commands.Add(isql);
            isql = $"UPDATE Users SET SEND = {SENDtick} WHERE UserID = {ID}";
            commands.Add(isql);
            isql = $"UPDATE Users SET DA = {DAtick} WHERE UserID = {ID}";
            commands.Add(isql);
            isql = $"UPDATE Users SET PointScoreY1 = {PSY1} WHERE UserID = {ID}";
            commands.Add(isql);
            isql = $"UPDATE Users SET PointScoreY2 = {PSY2} WHERE UserID = {ID}"; ///////////add commands to a list//////////
            commands.Add(isql);
            isql = $"UPDATE Users SET PointScoreY3 = {PSY3} WHERE UserID = {ID}";
            commands.Add(isql);
            isql = $"UPDATE Users SET PointScoreY4 = {PSY4} WHERE UserID = {ID}";
            commands.Add(isql);
            isql = $"UPDATE Users SET PointScoreY5 = {PSY5} WHERE UserID = {ID}";
            commands.Add(isql);
            conn.Open();
            foreach (string isqlcomm in commands)//loop through the list and execute all commands
            {
                OleDbCommand Cmd = new OleDbCommand(isqlcomm, conn);
                Cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        #endregion User

        #region Task

        public List<EnTask> taskList(string TaskSet)
        {
            List<EnTask> Tasks = new List<EnTask>();
            List<TaskSet> TaskSets = new List<TaskSet>();
            string querystring = "";
            if (TaskSet != "All Tasks")
            {
                querystring = $"SELECT * FROM Tasks WHERE TaskSet = {TaskSet}";//select just this TS
            }
            else
            {
                querystring = "SELECT * FROM Tasks";//no filter, select all
            }
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(querystring, conn);
            DataTable Results = new DataTable();
            da.Fill(Results);
            string AcaYear = GetAcademicYear();
            foreach (DataRow dr in Results.Rows)
            {
                EnTask T = new EnTask(dr);
                Tasks.Add(T);//add to list
            }
            conn.Close();
            return Tasks;
        }

        public string GetTaskName(int TaskID)
        {
            List<EnTask> TL = new List<EnTask>();
            TL = taskList("All Tasks");
            foreach (EnTask T in TL)
            {
                if (T.TaskID == TaskID)// gets the name assoaciated with the ID
                {
                    return T.TaskName;
                }
            }
            return null;
        }

        public void Addtask(string taskSet, string taskname, int Points)
        {
            DataAccess D = new DataAccess();
            EnTask T = new EnTask();
            T.TaskName = taskname;
            T.TaskID = 86;//default
            T.Points = Points;
            foreach (TaskSet TS in D.tasksetList())
            {
                if (TS.TaskSetName == taskSet)
                {
                    T.TaskSetID = TS.TaskSetID;//add TS ID from TS name
                }
            }
            Savetask(T.TaskID, T.TaskName, T.TaskSetID, T.Points);
        }

        public void Savetask(int ID, string name, int TS, int Points)
        {
            conn.Open();
            if (ID == -1) // First Time
            {
                string isql = "INSERT INTO Tasks (TaskSet,Task,TaskID,Points) VALUES (?,?,?,?)";
                OleDbCommand Cmd = new OleDbCommand(isql, conn);
                Cmd.Parameters.AddWithValue("TaskSet", TS);
                Cmd.Parameters.AddWithValue("Task", name);
                Cmd.Parameters.AddWithValue("TaskID", ID);
                Cmd.Parameters.AddWithValue("Points", Points);
                Cmd.ExecuteNonQuery();
                Cmd.CommandText = "Select @@Identity";
                ID = int.Parse(Cmd.ExecuteScalar().ToString());
            }
            else//existing
            {
                string isql = "INSERT INTO Tasks (TaskSet,Task,TaskID) VALUES (?,?,?)";
                OleDbCommand Cmd = new OleDbCommand(isql, conn);
                Cmd.Parameters.AddWithValue("TaskSet", TS);
                Cmd.Parameters.AddWithValue("Task", name);
                Cmd.Parameters.AddWithValue("TaskID", ID);
                Cmd.Parameters.AddWithValue("Points", Points);
                Cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        #endregion Task

        #region TaskSet

        public List<string> tasksetnamesList()
        {
            List<string> TaskSetnames = new List<string>();

            List<TaskSet> TSList = new List<TaskSet>();
            foreach (TaskSet TS in TSList)
            {
                TaskSetnames.Add(TS.TaskSetName);// gets list of taskset names
            }
            return TaskSetnames;
        }

        public List<TaskSet> tasksetList()
        {
            List<TaskSet> TaskSets = new List<TaskSet>();

            string queryString = "SELECT * FROM TaskSets";

            OleDbDataAdapter da = new OleDbDataAdapter(queryString, conn);
            DataTable Results = new DataTable();
            da.Fill(Results);
            foreach (DataRow dr in Results.Rows)
            {
                TaskSet TS = new TaskSet(dr);//gets list of taskset objects
                TaskSets.Add(TS);
            }
            return TaskSets;
        }

        public void Addtaskset(string name, string description)
        {
            TaskSet T = new TaskSet();
            T.TaskSetName = name;
            T.TaskSetID = -1;//new TS
            T.TaskSetDescription = description;
            Savetaskset(T.TaskSetID, T.TaskSetName, T.TaskSetDescription);
        }

        public void Savetaskset(int ID, string name, string desc)//saves to DB
        {
            conn.Open();
            if (ID == -1) // First Time
            {
                string isql = "INSERT INTO TaskSets (TaskSetName,TaskSetDescription) VALUES (?,?)";
                OleDbCommand Cmd = new OleDbCommand(isql, conn);
                Cmd.Parameters.AddWithValue("TaskSetName", name);
                Cmd.Parameters.AddWithValue("TaskSetDescription", desc);
                Cmd.ExecuteNonQuery();
                Cmd.CommandText = "Select @@Identity";
                ID = int.Parse(Cmd.ExecuteScalar().ToString());
            }
            else // existing
            {
                string isql = "INSERT INTO TaskSets (TaskSet Name,TaskSet Description,TaskSetID) VALUES (?,?,?)";
                OleDbCommand Cmd = new OleDbCommand(isql, conn);
                Cmd.Parameters.AddWithValue("TaskSetDescription", desc);
                Cmd.Parameters.AddWithValue("TaskSetName", name);
                Cmd.Parameters.AddWithValue("TaskSetID", ID);
                Cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public string TSID(string TSName)//gets taskset ID from name of TS
        {
            DataAccess D = new DataAccess();
            string ID = "";
            foreach (TaskSet TS in D.tasksetList())
            {
                if (TS.TaskSetName == TSName)
                {
                    ID = TS.TaskSetID.ToString();
                }
            }
            return ID;
        }

        #endregion TaskSet

        #region Submissions

        public void CompleteTask(User U, EnTask T, string Evidence, string D)
        {
            conn.Open();
            string isql = "INSERT INTO CompletedTask (UserID,TaskID,Evidence,TSTAMP) VALUES (?,?,?,?)";
            OleDbCommand Cmd = new OleDbCommand(isql, conn);
            Cmd.Parameters.AddWithValue("UserID", int.Parse(U.ID));
            Cmd.Parameters.AddWithValue("TaskID", T.TaskID);// add the user and task ID as a record
            Cmd.Parameters.AddWithValue("Evidence", Evidence);
            Cmd.Parameters.AddWithValue("TSTAMP", D);
            Cmd.ExecuteNonQuery();
            conn.Close();
            AddPoints(U, T);
        }

        public List<CompletedTask> VeiwCompletedTasks(User U)// Looks up one user's completed tasks
        {
            List<CompletedTask> CT = new List<CompletedTask>();
            string isql = $"SELECT * FROM CompletedTask WHERE UserID = {U.ID}";
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(isql, conn);// Completed Tasks
            DataTable Results = new DataTable();
            da.Fill(Results);
            foreach (DataRow DR in Results.Rows)
            {
                CompletedTask CompTask = new CompletedTask(DR);
                CT.Add(CompTask);//adds to list
            }
            conn.Close();
            return CT;
        }

        public void AddPoints(User U, EnTask T)
        {
            //calculate which user's year total to add it to...
            string acayear = GetAcademicYear();
            double newScore = U.PointScoreY1 + T.Points;//calculate the new running total
            int CurrentUserYear1to5 = (int.Parse(acayear)) + 12 - U.YearGroup;
            //Add the points
            string isql = pointsisql(CurrentUserYear1to5, newScore.ToString(), U.ID);
            OleDbCommand Cmd = new OleDbCommand(isql, conn);
            conn.Open();
            Cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void TakePoints(User U, EnTask T)
        {
            //calculate which user's year total to add it to...

            string acayear = GetAcademicYear();

            double newScore = U.PointScoreY1 - T.Points;//calculate the new running total
            int CurrentUserYear1to5 = (int.Parse(acayear)) + 12 - U.YearGroup;
            //remove the points
            conn.Open();
            string isql = pointsisql(CurrentUserYear1to5, newScore.ToString(), U.ID);
            OleDbCommand Cmd = new OleDbCommand(isql, conn);
            Cmd.ExecuteNonQuery();
            conn.Close();
        }

        public string pointsisql(int CU, string NS, string UID)
        {
            string isql = null;
            switch (CU)
            {
                case 7:
                    isql = $"UPDATE Users SET PointScoreY1 = {int.Parse(NS)} WHERE UserID = {UID}";
                    break;

                case 8:
                    isql = $"UPDATE Users SET PointScoreY2 = {int.Parse(NS)} WHERE UserID = {UID}";
                    break;

                case 9:
                    isql = $"UPDATE Users SET PointScoreY3 = {int.Parse(NS)} WHERE UserID = {UID}";//decide which year an duse correct SQL
                    break;

                case 10:
                    isql = $"UPDATE Users SET PointScoreY4 = {int.Parse(NS)} WHERE UserID = {UID}";
                    break;

                case 11:
                    isql = $"UPDATE Users SET PointScoreY1 = {int.Parse(NS)} WHERE UserID = {UID}";
                    break;
            }
            return isql;
        }

        public void unsubmitTask(User U, string Tstamp, CompletedTask CT)
        {
            conn.Open();
            string isql = $"DELETE FROM CompletedTask WHERE TSTAMP = '{Tstamp}' AND UserID = {U.ID} AND TaskID ={CT.TaskID}";
            OleDbCommand Cmd = new OleDbCommand(isql, conn);
            Cmd.ExecuteNonQuery();
            conn.Close();
            foreach (EnTask T in taskList("All Tasks"))
            {
                if (T.TaskID == CT.TaskID)
                {
                    TakePoints(U, T);//remove points for this task
                }
            }
        }

        #endregion Submissions

        #region General

        public bool regex_Validation(string StringToVal, string regexstring)
        {
            var r = new Regex(regexstring);//YearForename.Surname@.....
            if (r.IsMatch(StringToVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> RewardScan()// returns users and required new rewards
        {
            List<string> NeedsReward = new List<string>();

            int RL = 0;
            //Rewards Allocater: // If in the database, 

            foreach (User U in GetUsers("", "All Years", "All Tutor Groups", false, false))
            {
                int TopLevel = TestForReward(U);


                if (U.PointScoreY1 + U.PointScoreY2 + U.PointScoreY3 + U.PointScoreY4 + U.PointScoreY5 >= 15 ) //BRONZE
                {
                    RL = 1;
                    if (0 == TopLevel)// no reward yet
                    {
                        NeedsReward.Add($"{U.Forename} {U.Surname} (BRONZE)");
                        conn.Open();
                        string isql = "INSERT INTO Rewards (UserID,RewardLevel) VALUES (?,?)";
                        OleDbCommand Cmd = new OleDbCommand(isql, conn);
                        Cmd.Parameters.AddWithValue("UserID", int.Parse(U.ID));
                        Cmd.Parameters.AddWithValue("RewardLevel", RL);// add the user and rewardslevel as a record
                        Cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                }
            }
            foreach (User U in GetUsers("", "All Years", "All Tutor Groups", false, false))
            {
                int TopLevel = TestForReward(U);

                if (U.PointScoreY1 + U.PointScoreY2 + U.PointScoreY3 + U.PointScoreY4 + U.PointScoreY5 >= 25 ) //SILVER
                {
                    RL = 2;
                    if (RL > TopLevel)
                    {
                        NeedsReward.Add($"{U.Forename} {U.Surname} (SILVER)");
                        conn.Open();
                        string isql = "INSERT INTO Rewards (UserID,RewardLevel) VALUES (?,?)";
                        OleDbCommand Cmd = new OleDbCommand(isql, conn);
                        Cmd.Parameters.AddWithValue("UserID", int.Parse(U.ID));
                        Cmd.Parameters.AddWithValue("RewardLevel", RL);// add the user and rewardslevel as a record
                        Cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            foreach (User U in GetUsers("", "All Years", "All Tutor Groups", false, false))
            {
                int TopLevel = TestForReward(U);
                if (U.PointScoreY1 + U.PointScoreY2 + U.PointScoreY3 + U.PointScoreY4 + U.PointScoreY5 >= 40 ) //GOLD
                {
                    RL = 3;
                    if (RL >TopLevel)
                    {

                        NeedsReward.Add($"{U.Forename} {U.Surname} (GOLD)");
                        conn.Open();
                        string isql = "INSERT INTO Rewards (UserID,RewardLevel) VALUES (?,?)";
                        OleDbCommand Cmd = new OleDbCommand(isql, conn);
                        Cmd.Parameters.AddWithValue("UserID", int.Parse(U.ID));
                        Cmd.Parameters.AddWithValue("RewardLevel", RL);// add the user and rewardslevel as a record
                        Cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            foreach (User U in GetUsers("", "All Years", "All Tutor Groups", false, false))
            {
                int TopLevel = TestForReward(U);
                if (U.PointScoreY1 + U.PointScoreY2 + U.PointScoreY3 + U.PointScoreY4 + U.PointScoreY5 >= 50) //PLATINUM
                {
                    RL = 4;
                    if (4>=TopLevel)
                    {
                        NeedsReward.Add($"{U.Forename} {U.Surname} (PLATINUM)");
                        conn.Open();
                        string isql = "INSERT INTO Rewards (UserID,RewardLevel) VALUES (?,?)";
                        OleDbCommand Cmd = new OleDbCommand(isql, conn);
                        Cmd.Parameters.AddWithValue("UserID", int.Parse(U.ID));
                        Cmd.Parameters.AddWithValue("RewardLevel", RL);// add the user and rewardslevel as a record
                        Cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            return NeedsReward;
        }
            public int TestForReward(User U)// gets highest already attained reward for a user
        {
            int Level = 0;
            string isql = $"SELECT * FROM Rewards WHERE UserID = {U.ID}";// gets rewards for the user
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(isql, conn);
            DataTable Results = new DataTable();
            da.Fill(Results);
            conn.Close();
            foreach (DataRow DR in Results.Rows)//returns highest 1-5
            {
                if (DR[1].ToString() == "1")
                {
                    if (Level < 1)
                    {
                        Level = 1;
                    }
                }
                if (DR[1].ToString() == "2")
                {
                    if (Level < 2)
                    {
                        Level = 2;
                    }
                }
                if (DR[1].ToString() == "3")
                {
                    if (Level < 3)
                    {
                        Level = 3;
                    }
                }
                if (DR[1].ToString() == "4")
                {
                    if (Level < 4)
                    {
                        Level = 4;
                    }
                }
                if (DR[1].ToString() == "5")
                {
                    if (Level < 5)
                    {
                        Level = 5;
                    }
                }
            }
            return Level;
        }
        public string GetAcademicYear()
        {
            int academicyear;
            if (DateTime.Now.AddMonths(4).Year > DateTime.Now.Year)// Year begins in sept. if further than sept, add a year to the current year.
            {
                academicyear = DateTime.Now.AddYears(1).Year;
            }
            else
            {
                academicyear = (DateTime.Now.Year);
            }
            return academicyear.ToString();
        }

        #endregion General

        #region Crypto

        public string CryptoHash(string Plaintext, int iterations)
        {
            /////////////////////////////////////////////INITIALISATION CODE. Run if Salt/hash gets Deleted or incorrectly altered
           //   byte[] Salt = CryptoSalt();
          //    File.WriteAllBytes("D:\\FormsDatabase\\FormsDatabase\\Salt.txt", Salt); //SaltFinder
         //     var bytes = new Rfc2898DeriveBytes("IronGatePass", Salt, iterations);
            //  hashes 10x over iteratively. slow but secure
            ///////////////////////////////////////////////////////////////////

            byte[] Salt = File.ReadAllBytes("D:\\FormsDatabase\\FormsDatabase\\Salt.txt");//get from file                                  Saltfinder
                                                                                          // ComputeHash - returns byte array
            var bytes = new Rfc2898DeriveBytes(Plaintext, Salt, iterations); //  hashes 10x over iteratively. slow but secure

            string saltstring = "";
            // Convert byte array to a string
            saltstring = Convert.ToBase64String(Salt);

            byte[] hashbytes = bytes.GetBytes(28);//hash to string

            string savedPassHash = saltstring + "|" + iterations + "|" + Convert.ToBase64String(hashbytes);

            ///////////////////////////////
         //  SaveHashSalt(savedPassHash, Salt);  //INIT. CODE TOO
            ////////////////////////////////////
            ///
            return savedPassHash;//returns salt,iterations,and hash split by bars
        }

        public string Gethash()
        {
            string isql = "SELECT hash FROM UserTypes WHERE UserType = 'Admin'";//gets salt,iterations,hash from db
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(isql, conn);
            DataTable Results = new DataTable();
            da.Fill(Results);
            conn.Close();
            foreach (DataRow DR in Results.Rows)
            {
                string h1 = DR[0].ToString().Split('|')[2];//get the hash part

                return h1;//return just the hash
            }
            return null;
        }

        public void SetPassword(string newPass)
        {
            //new random salt
            byte[] clear = new byte[0];
            byte[] newSalt = CryptoSalt();
            File.WriteAllBytes("D:\\FormsDatabase\\FormsDatabase\\Salt.txt", clear);
            File.WriteAllBytes("D:\\FormsDatabase\\FormsDatabase\\Salt.txt", newSalt);//save byte array to file (new salt)      SaltFinder
            //
            //hash using new salt (now saved in file)
            string hashtosave = CryptoHash(newPass, 10);
            //get results, and save ALL (salt,iterations,and hash)

            SaveHashSalt(hashtosave, newSalt);
        }

        public bool verifyPASS(string PassTry)
        {
            string hash = Gethash();
            string attemptedhash = CryptoHash(PassTry, 10).ToString().Split('|')[2];
            if (attemptedhash == hash.Replace(" ", ""))// checks if hashing the attempt using the stored Salt returns the same as the correct hash
            {
                return true;
            }
            return false;
           
        }

        public void SaveHashSalt(string hash, byte[] salt)//saves hash and salt to db
        {
            conn.Open();
            string isql = $"UPDATE UserTypes SET hash = '{hash}' WHERE UserType = 'Admin'";//save the hash to DB
            OleDbCommand Cmd = new OleDbCommand(isql, conn);
            Cmd.ExecuteNonQuery();

            //now save salt to text file.
            //clear salt file
            byte[] clear = new byte[0];
            File.WriteAllBytes("D:\\FormsDatabase\\FormsDatabase\\Salt.txt", clear);
            File.WriteAllBytes("D:\\FormsDatabase\\FormsDatabase\\Salt.txt", salt);//save byte array.if called from SetPassword method then has no overall effect, but left in for flexibility of use for other potential purposes
            //SaltFinder
            conn.Close();
        }

        public byte[] CryptoSalt()//generates new salts
        {
            var salt = new byte[8];
            using (var random = new RNGCryptoServiceProvider())// fills byte array with random cryptographic int
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }
        #endregion Crypto
    }
}