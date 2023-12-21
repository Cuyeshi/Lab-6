using LibraryForRecords;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsForRecords
{
    [TestClass]
    public class TestMatrix
    {

        /// <summary>
        /// Тест, проверяющий вывод одной записи.
        /// </summary>
        [TestMethod]
        public void OutputOfOneRecords()
        {
            RecordsManage records = new RecordsManage(1);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;

            string time = records.records[0].Time;

            string record1 = "renat 01.01.2001 Кардиолог\n";

            string result = RecordsManage.TimeRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий вывод нескольких записей. 
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

            string record1 = "renat 01.01.2001 Кардиолог\nrenat 01.01.2001 Отоларинголог\nrenat 01.01.2001 Психиатр\n";

            string result = RecordsManage.TimeRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий вывод записи с отличной датой.
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

            string record1 = "renat 01.01.2001 Кардиолог\n";

            string result = RecordsManage.TimeRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий вывод записей с различной датой.
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

            string record1 = "renat 01.01.2001 Кардиолог\nrenat 01.01.2001 Психиатр\n";

            string result = RecordsManage.TimeRecords(time, records.records);

            Assert.AreEqual(result, record1);
        }
        /// <summary>
        /// Тест, проверяющий вывод при отсуствие записи в этот день.
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
        /// Тест, проверяющий вывод пациента у одного доктора.
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
        /// Тест, проверяющий вывод пациентов у одного доктора.
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
        /// Тест, проверяющий вывод пациентов у одного доктора в различные дни.
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
        /// Тест, проверяющий вывод пациентов у нескольких докторов.
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
        /// Тест, проверяющий вывод, когда в этот день нет записей.
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

        /// <summary>
        /// Тест, проверяющий среднее количество пациентов, когда один пациент в день.
        /// </summary>
        [TestMethod]
        public void OnePatientOnDay()
        {
            RecordsManage records = new RecordsManage(3);
            records.records[0].Initials = "renat";
            records.records[0].Time = "01.01.2001";
            records.records[0].Speciality = 1;

            string record1 = "Специальность Кардиолог:\n1\n\n";

            string result = RecordsManage.AveragePatients(records.records);

            Assert.AreEqual(result, record1);
        }

        /// <summary>
        /// Тест, проверяющий среднее количество пациентов, когда несколько пациент в день.
        /// </summary>
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

            string record1 = "Специальность Кардиолог:\n3\n\n";

            string result = RecordsManage.AveragePatients(records.records);

            Assert.AreEqual(result, record1);
        }

        /// <summary>
        /// Тест, проверяющий среднее количество пациентов, когда несколько пациент в различные дни.
        /// </summary>
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

            string record1 = "Специальность Кардиолог:\n1\n\n";

            string result = RecordsManage.AveragePatients(records.records);

            Assert.AreEqual(result, record1);
        }

        /// <summary>
        /// Тест, проверяющий среднее количество пациентов, когда несколько пациент по различным специальностям.
        /// </summary>
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

            string record1 = "Специальность Кардиолог:\n1\n\nСпециальность Отоларинголог:\n1\n\nСпециальность Офтальмолог:\n1\n\n";

            string result = RecordsManage.AveragePatients(records.records);

            Assert.AreEqual(result, record1);
        }

        /// <summary>
        /// Тест, проверяющий среднее количество пациентов, когда нет записей.
        /// </summary>
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