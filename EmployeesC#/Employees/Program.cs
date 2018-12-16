using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeePair
{
    class Program
    {
        static void Main(string[] args)
        {
            //fetch employees
            List<employee> employees = new List<employee>();
            try
            {
                using (StreamReader sr = new StreamReader("employees.txt"))
                {
                    string lines;
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((lines = sr.ReadLine()) != null)
                    {
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string[] words = lines.ToString().Split(',');
                            employee employeeObj = new employee(words[0], words[1], words[2], words[3].Trim());
                            employees.Add(employeeObj);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            longestWorkingPair(employees);
        }

        //generate pair
        public static void longestWorkingPair(List<employee> emp)
        {
            Console.WriteLine("Pair of employees that have worked for the longest period of time on a single project" + "\n");

            int totalDays = 0;
            bool foundPair = false;
            int firstEmployee = 0;
            int firstEmployeeDuration = 0;
            int secondEmployee = 0;
            int secondEmployeeDuration = 0;
            int firstEmpProjId = 0;
            int secondEmpProjId = 0;
            for (int i = 0; i < emp.Count; i++)
            {
                for (int j = 0; j < emp.Count; j++)
                {
                    int totalDuration = emp[i].duration + emp[j].duration;
                    if (emp[i].EmpId != emp[j].EmpId && emp[i].ProjectID == emp[j].ProjectID && totalDuration > totalDays)
                    {
                        totalDays = totalDuration;
                        firstEmployee = int.Parse(emp[i].EmpId);
                        firstEmployeeDuration = emp[i].duration;
                        secondEmployee = int.Parse(emp[j].EmpId);
                        secondEmployeeDuration = emp[j].duration;
                        firstEmpProjId = int.Parse(emp[i].ProjectID);
                        secondEmpProjId = int.Parse(emp[j].ProjectID);
                        foundPair = true;
                    }
                }
            }
            if (foundPair)
            {
                Console.WriteLine("Employee with id " + firstEmployee + " " + "has worked for " + firstEmployeeDuration + " " + "days " + "on project " + firstEmpProjId + "\n" + "Employee with id " + secondEmployee + " " + "has worked for " + secondEmployeeDuration + " " + "days " + "on project " + secondEmpProjId);
            }
        }
    }
}
