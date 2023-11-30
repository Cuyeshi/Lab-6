namespace LibraryForRecords
{
    public class Records
    {
        public string Initials;

        public string Time;

        public int Speciality;

        public Records()
        {
            this.Initials = "";
            this.Time = "00.00.0000";
            this.Speciality = 0;
        }

        public Records(string initials, string time, int speciality)
        {
            Initials = initials;
            Time = time;
            Speciality = speciality;
        }
    }
}