using LibraryForRecords;

namespace TestsForRecords
{
    [TestClass]
    public class TestMatrix
    {

        /// <summary>
        /// Тест, проверяющий умножения одноэлементной матрицы.
        /// </summary>
        [TestMethod]
        public void OutputOfOneRecords()
        {
            RecordsManage records = new RecordsManage(1);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;

            string time = records.records[0].Time;

            string record1 = "renat 01.01.2001 1\n";

            string result = RecordsManage.TimeRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий умножение матриц, в результате которого получается одноэлементная матрица. 
        /// </summary>
        [TestMethod]
        public void OutputOfMoreRecords()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "renat";
            records.records[1].Time = "01.01.2001";
            records.records[1].Speciality = 2;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2001";
            records.records[2].Speciality = 3;

            string time = records.records[0].Time;

            string record1 = "renat 01.01.2001 1\nrenat 01.01.2001 2\nrenat 01.01.2001 3\n";

            string result = RecordsManage.TimeRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий умножение квадратных матриц.
        /// </summary>
        [TestMethod]
        public void OutputOfRecordOfDifferentDays()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "renat";
            records.records[1].Time = "01.01.2002";
            records.records[1].Speciality = 2;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2003";
            records.records[2].Speciality = 3;

            string time = records.records[0].Time;

            string record1 = "renat 01.01.2001 1\n";

            string result = RecordsManage.TimeRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий умножение столбца на строчку.
        /// </summary>
        [TestMethod]
        public void OutupOfRecordsOfDifferentDays()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "renat";
            records.records[1].Time = "01.01.2002";
            records.records[1].Speciality = 2;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2001";
            records.records[2].Speciality = 3;

            string time = records.records[0].Time;

            string record1 = "renat 01.01.2001 1\nrenat 01.01.2001 3\n";

            string result = RecordsManage.TimeRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий возможность умножения матриц.
        /// </summary>
        [TestMethod]
        public void OutputWhenNoRecordsOfDay()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "renat";
            records.records[1].Time = "01.01.2002";
            records.records[1].Speciality = 2;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2001";
            records.records[2].Speciality = 3;

            string time = "02.02.2001";

            string record1 = "На данный день нет записей";

            string result = RecordsManage.TimeRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий умножение матрицы на число.
        /// </summary>
        [TestMethod]
        public void InHospitalOneDoctorAndOnePatient()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;

            string time = "01.01.2001";

            string record1 = "renat:\n1\n\n";

            string result = RecordsManage.DoctorRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий умножение матрицу на вещественное число.
        /// </summary>
        [TestMethod]
        public void InHospitalOneDoctor()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "renat";
            records.records[1].Time = "01.01.2001";
            records.records[1].Speciality = 2;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2001";
            records.records[2].Speciality = 3;

            string time = "01.01.2001";

            string record1 = "renat:\n3\n\n";

            string result = RecordsManage.DoctorRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий умножение матрицы на единицу.
        /// </summary>
        [TestMethod]
        public void InHospitalOneDoctorInDifferntDays()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "renat";
            records.records[1].Time = "01.01.2002";
            records.records[1].Speciality = 2;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2001";
            records.records[2].Speciality = 3;

            string time = "01.01.2001";

            string record1 = "renat:\n2\n\n";

            string result = RecordsManage.DoctorRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий умножение матрицы на отрицательное число.
        /// </summary>
        [TestMethod]
        public void InHospitalSomeDoctors()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "ford";
            records.records[1].Time = "01.01.2001";
            records.records[1].Speciality = 2;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2001";
            records.records[2].Speciality = 3;

            string time = "01.01.2001";

            string record1 = "renat:\n2\n\nford:\n1\n\n";

            string result = RecordsManage.DoctorRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий умножение матрицы на ноль.
        /// </summary>
        [TestMethod]
        public void InThisDayNotRecords()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "ford";
            records.records[1].Time = "01.01.2001";
            records.records[1].Speciality = 2;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2001";
            records.records[2].Speciality = 3;

            string time = "01.01.2002";

            string record1 = "На данный день нет записей.";

            string result = RecordsManage.DoctorRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        [TestMethod]
        public void OnePatientOnDay()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;

            string record1 = "Специальность 1:\n1\n\n";

            string result = RecordsManage.AveragePatients(records.records);

            Assert.AreEqual(result, record1);
        }
        [TestMethod]
        public void SomePatientsOnDay()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "ford";
            records.records[1].Time = "01.01.2001";
            records.records[1].Speciality = 1;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2001";
            records.records[2].Speciality = 1;

            string record1 = "Специальность 1:\n3\n\n";

            string result = RecordsManage.AveragePatients(records.records);

            Assert.AreEqual(result, record1);
        }
        [TestMethod]
        public void SomePatientsOnDifferentDays()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "ford";
            records.records[1].Time = "01.01.2002";
            records.records[1].Speciality = 1;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2003";
            records.records[2].Speciality = 1;

            string record1 = "Специальность 1:\n1\n\n";

            string result = RecordsManage.AveragePatients(records.records);

            Assert.AreEqual(result, record1);
        }
        [TestMethod]
        public void SomePatientsOfDifferentSpeciality()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;
            records.records[1].Initials = "ford";
            records.records[1].Time = "01.01.2002";
            records.records[1].Speciality = 2;
            records.records[2].Initials = "renat";
            records.records[2].Time = "01.01.2003";
            records.records[2].Speciality = 5;

            string record1 = "Специальность 1:\n1\n\nСпециальность 2:\n1\n\nСпециальность 5:\n1\n\n";

            string result = RecordsManage.AveragePatients(records.records);

            Assert.AreEqual(result, record1);
        }
        [TestMethod]
        public void NoRecords()
        {
            RecordsManage records = new RecordsManage(0);

            string record1 = "Записей нет.";

            string result = RecordsManage.AveragePatients(records.records);

            Assert.AreEqual(result, record1);
        }
    }
}