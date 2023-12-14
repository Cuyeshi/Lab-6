using System;
using LibraryForRecords;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество записей: ");
            int numberOfRecords = int.Parse(Console.ReadLine());

            RecordsManage recordsManage = new RecordsManage(numberOfRecords);
            string result = "";

            bool exit = false;

            while (!exit) 
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Ввод записи на приём");
                Console.WriteLine("2. Редактирование записей");
                Console.WriteLine("3. Просмотр записей");
                Console.WriteLine("4. Вывод записей на определённый день");
                Console.WriteLine("5. Вывод количества пациентов по доктору в определённый день");
                Console.WriteLine("6. Подсчёт среднего количества пациентов в день по специальности");
                Console.WriteLine("0. Выход");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        for (int i = 0; i < numberOfRecords; i++)
                        {
                            Console.WriteLine($"Введите данные для записи {i + 1}:");

                            Console.Write("ФИО доктора: ");
                            recordsManage.records[i].Initials = Console.ReadLine();

                            Console.Write("Дата: ");
                            recordsManage.records[i].Time = Program.InputData();

                            Console.Write($"Специальность(1.Кардиолог;2.Отоларинголог;3.Психиатр;4.Ревматолог;5.Офтальмолог): ");
                            recordsManage.records[i].Speciality = int.Parse(Console.ReadLine());

                            Console.WriteLine();
                        }
                        break;

                    case 2:
                        Console.Write("Введите номер записи для редактирования: ");
                        int recordNumber = int.Parse(Console.ReadLine()) - 1;

                        if (recordNumber >= 0 && recordNumber < numberOfRecords)
                        {
                            Console.WriteLine($"Редактирование данных для записи {recordNumber + 1}:");

                            Console.Write("ФИО доктора: ");
                            recordsManage.records[recordNumber].Initials = Console.ReadLine();

                            Console.Write("Дата: ");
                            recordsManage.records[recordNumber].Time = Console.ReadLine();

                            Console.Write($"Специальность(1.Кардиолог;2.Отоларинголог;3.Психиатр;4.Ревматолог;5.Офтальмолог): ");
                            recordsManage.records[recordNumber].Speciality = int.Parse(Console.ReadLine());

                            Console.WriteLine("Данные успешно отредактированы.\n");
                        }
                        else
                        {
                            Console.WriteLine("Записи с таким номером не существует.\n");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Записи в поликлинике:");

                        for (int i = 0; i < numberOfRecords; i++)
                        {
                            if (recordsManage.records[i].Initials != null)
                            {
                                Console.WriteLine($"Запись {i + 1}:");
                                Console.WriteLine($"ФИО доктора: {recordsManage.records[i].Initials}");
                                Console.WriteLine($"Дата: {recordsManage.records[i].Time}");
                                Console.WriteLine($"Специальность(1.Кардиолог;2.Отоларинголог;3.Психиатр;4.Ревматолог;5.Офтальмолог): {recordsManage.records[i].Speciality}\n\n");
                            }
                        }
                        break;

                    case 4:
                        Console.Write("Введите дату дня приёма: ");
                        string time = Program.InputData();
                        result = RecordsManage.TimeRecords(time,recordsManage.records);
                        Console.WriteLine(result);
                        break;

                    case 5:
                        Console.Write("Введите дату дня приёма: ");
                        time = Program.InputData();
                        result = RecordsManage.DoctorRecords(time,recordsManage.records);
                        Console.WriteLine(result);
                        break;

                    case 6:
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

        public static string InputData()
        {
            string day,month,year,time;
            Console.Write("\nДень: ");
            day = Console.ReadLine();
            Console.Write("\nМесяц: ");
            month = Console.ReadLine();
            Console.Write("\nГод: ");
            year = Console.ReadLine();
            time = day + "/" + month + "/" + year;
            return time;
        }
    }
}

