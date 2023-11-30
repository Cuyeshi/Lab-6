namespace LibraryForRecords
{
    public class Records
    {
        public string Initials;

        public string Time;

        public string Speciality;

        public Records()
        {
            this.Initials = "";
            this.Time = "00.00.0000";
            this.Speciality = "";
        }

        public Records(string initials, string time, string speciality)
        {
            Initials = initials;
            Time = time;
            Speciality = speciality;
        }
    }
}