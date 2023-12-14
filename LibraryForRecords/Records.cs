namespace LibraryForRecords
{
    /// <summary>
    /// Класс о информации в записи.
    /// </summary>
    public class Records
    {
        public string Initials;

        public string Time;

        public int Speciality;

        /// <summary>
        /// Пустой конструктор.
        /// </summary>
        public Records()
        {
            this.Initials = "";
            this.Time = "00.00.0000";
            this.Speciality = 0;
        }

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="initials"></param>
        /// <param name="time"></param>
        /// <param name="speciality"></param>
        public Records(string initials, string time, int speciality)
        {
            Initials = initials;
            Time = time;
            Speciality = speciality;
        }
    }
}