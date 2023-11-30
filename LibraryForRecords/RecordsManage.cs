using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForRecords
{

    enum Speciality
    {
        Cardiologist = 1,
        Otolaryngologist = 2,
        Psychiatrist = 3,
        Rheumatologist = 4,
        Ophthalmologist = 5,
    }
    internal class RecordsManage
    {
        public static Records[] records;

        public RecordsManage(int NumberOfRecords)
        {
            records = new Records[NumberOfRecords];
            for (int i = 0; i < NumberOfRecords; i++)
            {
                records[i] = new Records();
            }
        }

        public static string TimeRecords(string time)
        {
            int count = 0;
            string timeRecords = "";
            foreach(var record in records)
            {
                if (record.Time == time);
                {
                    timeRecords = record.Initials + " " + record.Time + " " + record.Speciality + "\n";
                    count++;
                }
            }
            if (count > 0)
            {
                return timeRecords;
            }
            else
            {
                return "На данный день нет записей";
            }
        }

        public static string DoctorRecords(string time) 
        {
            int patients = 0, doctors = 0, diff = 0;
            string numberPatients = "";
            string[] names = new string[doctors];
            foreach (var record in records)
            {
                if (record.Time == time) ;
                {
                    for (int i = 0;i <= doctors;i++)
                    {
                        if (names[i] == record.Initials)
                        {
                            diff++;
                        }
                    }
                    if (diff == doctors)
                    {
                        names[doctors] = record.Initials;
                        doctors++;
                    }
                }
            }
            for (int i = 0; i < doctors;i++) 
            {
                patients = 0;
                foreach (var record in records)
                {
                    if (record.Time == time && record.Initials == names[i])
                    {
                        patients++;
                    }
                }
                numberPatients = names[i] + ":\n" + patients + "\n\n";
            }
            if (!string.IsNullOrEmpty(numberPatients))
            {
                return numberPatients;
            }
            else
            {
                return "На данный день нет записей.";
            }
        }

        public static string AveragePatients()
        {
            double patients = 0, diff = 0;
            int days = 0;
            string average = "";
            string[] times = new string[days];
            for (int i = 1; i <= 5 ; i++) 
            { 
                foreach (var record in records)
                {
                    if (record.Speciality == i)
                    {
                        for (int j = 0; j <= days; j++)
                        {
                            if (times[j] == record.Time)
                            {
                                diff++;
                            }
                        }
                        if (diff == days)
                        {
                            times[days] = record.Time;
                            days++;
                        }
                        patients++;
                    }
                }
                if (days > 0)
                {
                    average = "Speciality" + i + ":\n" + patients / days + "\n\n";
                }
            }
            if (!string.IsNullOrEmpty(average))
            {
                return average;
            }
            else
            {
                return "Записей нет.";
            }
        }
    }
}
