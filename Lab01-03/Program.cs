using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Person> personList = new List<Person>();

            // Dữ liệu mẫu
            personList = GetMockData();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== MENU QUẢN LÝ (SINH VIÊN & GIẢNG VIÊN) ===");
                Console.WriteLine("1. Thêm Sinh Viên");
                Console.WriteLine("2. Thêm Giảng Viên");
                Console.WriteLine("3. Xuất danh sách Sinh Viên");
                Console.WriteLine("4. Xuất danh sách Giảng Viên");
                Console.WriteLine("5. Tổng số lượng từng loại");
                Console.WriteLine("6. Xuất SV thuộc khoa CNTT");
                Console.WriteLine("7. Xuất GV ở Quận 9");
                Console.WriteLine("8. Xuất SV điểm cao nhất khoa CNTT");
                Console.WriteLine("9. Thống kê điểm xếp loại SV");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Student s = new Student();
                        s.Input();
                        personList.Add(s);
                        break;
                    case "2":
                        Teacher t = new Teacher();
                        t.Input();
                        personList.Add(t);
                        break;
                    case "3":
                        ShowStudents(personList);
                        break;
                    case "4":
                        ShowTeachers(personList);
                        break;
                    case "5":
                        Console.WriteLine($"Tổng SV: {personList.OfType<Student>().Count()}");
                        Console.WriteLine($"Tổng GV: {personList.OfType<Teacher>().Count()}");
                        break;
                    case "6":
                        var listCNTT = personList.OfType<Student>()
                                       .Where(x => x.Faculty == "CNTT").ToList();
                        ShowStudents(new List<Person>(listCNTT));
                        break;
                    case "7":
                        var listQ9 = personList.OfType<Teacher>()
                                     .Where(x => x.Address.Contains("Quận 9")).ToList();
                        ShowTeachers(new List<Person>(listQ9));
                        break;
                    case "8":
                        ShowBestStudentCNTT(personList);
                        break;
                    case "9":
                        ShowStatistics(personList);
                        break;
                    case "0":
                        exit = true;
                        break;
                }
            }
        }
        #region CÁC HÀM HỖ TRỢ       

        static void ShowStudents(List<Person> list)
        {
            Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ---");
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,5} |", "MSSV", "HỌ TÊN", "KHOA", "ĐTB");
            Console.WriteLine(new string('-', 58));

            // Lọc ra Student để in
            foreach (var item in list.OfType<Student>())
            {
                item.Show();
            }
            Console.WriteLine(new string('-', 58));
        }

        static void ShowTeachers(List<Person> list)
        {
            Console.WriteLine("\n--- DANH SÁCH GIẢNG VIÊN ---");
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-20} |", "MSGV", "HỌ TÊN", "ĐỊA CHỈ");
            Console.WriteLine(new string('-', 58));

            // Lọc ra Teacher để in
            foreach (var item in list.OfType<Teacher>())
            {
                item.Show();
            }
            Console.WriteLine(new string('-', 58));
        }

        static void ShowBestStudentCNTT(List<Person> list)
        {
            var svCNTT = list.OfType<Student>().Where(s => s.Faculty == "CNTT").ToList();
            if (svCNTT.Count > 0)
            {
                float maxScore = svCNTT.Max(s => s.AverageScore);
                var bestStudents = svCNTT.Where(s => s.AverageScore == maxScore).ToList();
                Console.WriteLine("\nSV ĐIỂM CAO NHẤT KHOA CNTT:");
                ShowStudents(new List<Person>(bestStudents));
            }
        }

        static void ShowStatistics(List<Person> list)
        {
            var students = list.OfType<Student>().ToList();
            // Copy logic thống kê từ bài 2B vào đây, dùng biến 'students'
            int gioi = students.Count(s => s.AverageScore >= 8);
            // ... (viết tiếp các loại khác)
            Console.WriteLine($"Số lượng SV Giỏi/Xuất sắc: {gioi}");
        }
        #endregion

        // Dữ liệu mẫu
        static List<Person> GetMockData()
        {
            return new List<Person>()
            {
                new Student("SV01", "Nguyễn Văn A", 9.0f, "CNTT"),
                new Student("SV02", "Lê Thị B", 7.5f, "QTKD"),
                new Student("SV03", "Trần Văn C", 5.0f, "CNTT"),
                new Teacher("GV01", "Thầy Giáo X", "Quận 9, TP.HCM"),
                new Teacher("GV02", "Cô Giáo Y", "Quận 1, TP.HCM"),
                new Teacher("GV03", "Thầy Z", "Quận 9")
            };
        }
        
    }
}