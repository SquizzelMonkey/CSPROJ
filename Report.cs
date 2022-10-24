using System.IO;

namespace FormsDatabase
{
    internal class Report
    {//copies the information requested to a communal text file.
        public void AddLine(string info)
        {
            using (StreamWriter writer = new StreamWriter("D:\\FormsDatabase\\Report.txt", true))//enter path //ReportFinder
            {
                writer.WriteLine(info);
            }
        }
    }
}