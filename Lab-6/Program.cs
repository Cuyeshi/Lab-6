using System;
using LibraryForRecords;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество записей: ");
            int numberOfRecords = 0;
            bool ValidateValue = true;
            while (ValidateValue)
            {
                try
                {
                    string number = Console.ReadLine();
                    RecordsException.ValidateInt(number, out numberOfRecords);
                    ValidateValue = false;
                }
                catch (RecordsException ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}");
                }
            }

            RecordsManage recordsManage = new RecordsManage(numberOfRecords);
            string result = "";

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n╔═══════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                         Выберите действие:                        ║");
                Console.WriteLine("║                      1. Ввод записи на приём                      ║");
                Console.WriteLine("║                     2. Редактирование записей                     ║");
                Console.WriteLine("║                        3. Просмотр записей                        ║");
                Console.WriteLine("║                4. Вывод записей на определённый день              ║");
                Console.WriteLine("║     5. Вывод количества пациентов по доктору в определённый день  ║");
                Console.WriteLine("║  6. Подсчёт среднего количества пациентов в день по специальности ║");
                Console.WriteLine("║                            0. Выход                               ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝\n");

                int choice = 0;
                ValidateValue = true;
                while (ValidateValue)
                {
                    try
                    {
                        string number = Console.ReadLine();
                        RecordsException.ValidateInt(number, out choice);
                        ValidateValue = false;
                    }
                    catch (RecordsException ex)
                    {
                        Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                    }
                }

                switch (choice)
                {
                    case 1: // Ввод записей.
                        for (int i = 0; i < numberOfRecords; i++)
                        {
                            Console.WriteLine($"Введите данные для записи {i + 1}:");

                            Console.Write("ФИО доктора: ");
                            bool empty = true;
                            while (empty)
                            {
                                recordsManage.records[i].Initials = Console.ReadLine();
                                if (recordsManage.records[i].Initials != "")
                                {
                                    empty = false;
                                }
                                else
                                {
                                    Console.WriteLine("Строка пуста!");
                                }
                            }

                            Console.Write("Дата: ");
                            recordsManage.records[i].Time = Program.InputData();

                            Console.Write($"Специальность(1.Кардиолог;2.Отоларинголог;3.Психиатр;4.Ревматолог;5.Офтальмолог): ");
                            recordsManage.records[i].Speciality = 0;
                            ValidateValue = true;
                            while (ValidateValue)
                            {
                                try
                                {
                                    string number = Console.ReadLine();
                                    RecordsException.ValidateSpeciality(number, out recordsManage.records[i].Speciality);
                                    ValidateValue = false;
                                }
                                catch (RecordsException ex)
                                {
                                    Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                                }
                            }

                            Console.WriteLine();
                        }
                        break;

                    case 2: // Редактирование записи.
                        Console.Write("Введите номер записи для редактирования: ");
                        int recordNumber = 0;
                        ValidateValue = true;
                        while (ValidateValue)
                        {
                            try
                            {
                                string number = Console.ReadLine();
                                RecordsException.ValidateInt(number, out recordNumber);
                                recordNumber--;
                                ValidateValue = false;
                            }
                            catch (RecordsException ex)
                            {
                                Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                            }
                        }

                        if (recordNumber >= 0 && recordNumber < numberOfRecords)
                        {
                            Console.WriteLine($"----------- Редактирование данных для записи {recordNumber + 1} -----------");

                            Console.Write("\nФИО доктора: ");
                            bool empty = true;
                            while (empty)
                            {
                                recordsManage.records[recordNumber].Initials = Console.ReadLine();
                                if (recordsManage.records[recordNumber].Initials != "")
                                {
                                    empty = false;
                                }
                                else
                                {
                                    Console.WriteLine("Строка пуста!");
                                }
                            }

                            Console.Write("Дата: ");
                            recordsManage.records[recordNumber].Time = InputData();

                            Console.Write($"Специальность(1.Кардиолог;2.Отоларинголог;3.Психиатр;4.Ревматолог;5.Офтальмолог): ");
                            recordsManage.records[recordNumber].Speciality = 0;
                            ValidateValue = true;
                            while (ValidateValue)
                            {
                                try
                                {
                                    string number = Console.ReadLine();
                                    RecordsException.ValidateSpeciality(number, out recordsManage.records[recordNumber].Speciality);
                                    ValidateValue = false;
                                }
                                catch (RecordsException ex)
                                {
                                    Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                                }
                            }

                            Console.WriteLine("----------- Данные успешно отредактированы -----------\n");
                        }
                        else
                        {
                            Console.WriteLine("Записи с таким номером не существует.\n");
                        }
                        break;

                    case 3: // Вывод записей.
                        Console.WriteLine("Записи в поликлинике:");

                        for (int i = 0; i < numberOfRecords; i++)
                        {
                            if (recordsManage.records[i].Initials != null)
                            {
                                Console.WriteLine("\n══════════════════════════════════════════════════════════════════════════════════════");
                                Console.WriteLine($"\n Запись {i + 1}");
                                Console.WriteLine($" ФИО доктора: {recordsManage.records[i].Initials}");
                                Console.WriteLine($" Дата: {recordsManage.records[i].Time}");
                                Console.WriteLine($" Специальность(1.Кардиолог;2.Отоларинголог;3.Психиатр;4.Ревматолог;5.Офтальмолог): {recordsManage.records[i].Speciality}");
                                Console.WriteLine("\n═══════════════════════════════════════════════════════════════════════════════════════\n");
                            }
                        }
                        break;

                    case 4: // Вывод записей на определённый день.
                        Console.Write("Введите дату дня приёма: ");
                        string time = Program.InputData();
                        result = RecordsManage.TimeRecords(time, recordsManage.records);
                        Console.WriteLine(result);
                        break;

                    case 5: // Вывод количества пациентов по доктору в определённый день.
                        Console.Write("Введите дату дня приёма: ");
                        time = Program.InputData();
                        Console.WriteLine();
                        result = RecordsManage.DoctorRecords(time, recordsManage.records);
                        Console.WriteLine(result);
                        break;

                    case 6: // Подсчёт среднего количества пациентов в день по специальности.
                        result = RecordsManage.AveragePatients(recordsManage.records);
                        Console.WriteLine(result);
                        break;

                    case 0:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите существующую опцию.");
                        break;
                }
            }
        }

        /// <summary>
        /// Метод ввода даты.
        /// </summary>
        /// <returns></returns>
        private static string InputData()
        {
            int day, month, year;
            string time;
            bool ValidateValue = true;
            Console.Write("\nДень: ");
            day = 0;
            ValidateValue = true;
            while (ValidateValue)
            {
                try
                {
                    string number = Console.ReadLine();
                    RecordsException.ValidateDay(number, out day);
                    ValidateValue = false;
                }
                catch (RecordsException ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                }
            }
            Console.Write("\nМесяц: ");
            month = 0;
            ValidateValue = true;
            while (ValidateValue)
            {
                try
                {
                    string number = Console.ReadLine();
                    RecordsException.ValidateMonth(number, out month);
                    ValidateValue = false;
                }
                catch (RecordsException ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                }
            }
            Console.Write("\nГод: ");
            year = 0;
            ValidateValue = true;
            while (ValidateValue)
            {
                try
                {
                    string number = Console.ReadLine();
                    RecordsException.ValidateYear(number, out year);
                    ValidateValue = false;
                }
                catch (RecordsException ex)
                {
                    Console.WriteLine($"Ошибка ввода: {ex.Message}\n");
                }
            }
            time = day + "." + month + "." + year;
            return time;
        }
    }
}

