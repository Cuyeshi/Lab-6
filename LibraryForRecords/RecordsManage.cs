﻿using System;

namespace LibraryForRecords
{
    /// <summary>
    /// Нумерация по специальности.
    /// </summary>
    enum Speciality
    {
        Кардиолог = 1,
        Отоларинголог = 2,
        Психиатр = 3,
        Ревматолог = 4,
        Офтальмолог = 5,
    }

    /// <summary>
    /// Класс с хранением записей.
    /// </summary>
    public class RecordsManage
    {

        /// <summary>
        /// Поле записей.
        /// </summary>
        public Records[] records;

        /// <summary>
        /// Конструктор по количеству записей.
        /// </summary>
        /// <param name="NumberOfRecords"></param>
        public RecordsManage(int NumberOfRecords)
        {
            records = new Records[NumberOfRecords];
            for (int i = 0; i < NumberOfRecords; i++)
            {
                records[i] = new Records();
            }
        }

        /// <summary>
        /// Метод для вывода значений констант из enum по передаваемому индексу.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static string EnumerationExtract(int index)
        {
            // Получение всех значений перечисления в массив
            Speciality[] specialitiesArray = (Speciality[])Enum.GetValues(typeof(Speciality));

            string spec = "";
            index--;
            // Обращение к элементу по индексу
            if (index > 0 && index < specialitiesArray.Length)
            {
                spec = specialitiesArray[index].ToString();
            }
            return spec;
        }

        /// <summary>
        /// Метод, для вывода записей в определённый день.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public static string TimeRecords(string time, Records[] records)
        {
            int count = 0;
            string timeRecords = "";
            foreach (var record in records)
            {
                if (record.Time == time)
                {
                    timeRecords = timeRecords + record.Initials + " " + record.Time + " " + EnumerationExtract(record.Speciality) + "\n";
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

        /// <summary>
        /// Метод вывода количества пациентов у докторов в определённый день.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public static string DoctorRecords(string time, Records[] records)
        {
            int patients = 0, doctors = 0, diff = 0;
            string numberPatients = "";
            string[] names = new string[records.Length];
            foreach (var record in records)
            {
                if (record.Time == time)
                {
                    for (int i = 0; i <= doctors; i++)
                    {
                        if (names[i] == record.Initials)
                        {
                            diff++;
                        }
                    }
                    if (diff == 0)
                    {
                        names[doctors] = record.Initials;
                        doctors++;
                    }
                }
            }
            for (int i = 0; i < doctors; i++)
            {
                patients = 0;
                foreach (var record in records)
                {
                    if (record.Time == time && record.Initials == names[i])
                    {
                        patients++;
                    }
                }
                numberPatients = numberPatients + names[i] + ":\n" + patients + "\n\n";
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

        /// <summary>
        /// Метод подсчёта среднего количества пациентов в день по специальностям.
        /// </summary>
        /// <param name="records"></param>
        /// <returns></returns>
        public static string AveragePatients(Records[] records)
        {
            double patients = 0, diff = 0;
            int days = 0;
            string average = "";
            string[] times = new string[records.Length];
            for (int i = (int)Speciality.Кардиолог; i <= (int)Speciality.Офтальмолог; i++)
            {
                for (int j = 0; j < days; j++)
                {
                    times[j] = "";
                }
                diff = 0;
                days = 0;
                patients = 0;
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
                        if (diff == 0)
                        {
                            times[days] = record.Time;
                            days++;
                        }
                        patients++;
                    }
                }
                if (days > 0)
                {
                    average = average + "Специальность " + EnumerationExtract(i) + ":\n" + patients / days + "\n\n";
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
