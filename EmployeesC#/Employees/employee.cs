using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeePair
{

    public class employee
    {
        public string EmpId;
        public string ProjectID;
        public string DateFrom;
        public string DateTo;
        public int duration;

        public employee(string EmpId, string ProjectID, string DateFrom, string DateTo)
        {
            this.EmpId = EmpId;
            this.ProjectID = ProjectID;
            this.DateFrom = DateFrom;
            if (DateTo == "NULL")
            {
                this.DateTo = DateTime.Now.ToString();
            }
            else
            {
                this.DateTo = DateTo;
            }
            DateTime to = DateTime.Parse(this.DateTo);
            DateTime from = DateTime.Parse(this.DateFrom);
            TimeSpan time = to - from;
            double minutes = Math.Round(time.TotalDays);
            this.duration = (int)minutes;
        }
    }
}

