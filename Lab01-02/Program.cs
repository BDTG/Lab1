using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Khởi tạo danh sách sinh viên
            // List<Student> studentList = new List<Student>();
            List<Student> studentList = GetMockData();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== MENU QUẢN LÝ SINH VIÊN ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị tất cả sinh viên");
                Console.WriteLine("3. Tìm SV khoa CNTT");
                Console.WriteLine("4. Tìm SV có ĐTB >= 5");
                Console.WriteLine("5. Sắp xếp SV theo ĐTB tăng dần");
                Console.WriteLine("6. Tìm SV ĐTB >= 5 và thuộc khoa CNTT");
                Console.WriteLine("7. Tìm SV có ĐTB cao nhất khoa CNTT");
                Console.WriteLine("8. Thống kê xếp loại học lực");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        DisplayStudentList(studentList);
                        break;
                    case "3": // Bài 2B - Câu 3
                        ShowStudentByFaculty(studentList, "CNTT");
                        break;
                    case "4": // Bài 2B - Câu 4
                        ShowStudentByScore(studentList, 5.0f);
                        break;
                    case "5": // Bài 2B - Câu 5
                        SortStudentByScoreAsc(studentList);
                        break;
                    case "6": // Bài 2B - Câu 6
                        ShowStudentByFacultyAndScore(studentList, "CNTT", 5.0f);
                        break;
                    case "7": // Bài 2B - Câu 7
                        ShowBestStudentInFaculty(studentList, "CNTT");
                        break;
                    case "8": // Bài 2B - Câu 8
                        StudentStatistics(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Chức năng không tồn tại!");
                        break;
                }
            }
        }

        //Case 1
        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("\n=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void DisplayStudentList(List<Student> listToDisplay)
        {
            if (listToDisplay.Count == 0)
            {
                Console.WriteLine("\n=> Không có sinh viên nào trong danh sách kết quả!");
                return;
            }

            Console.WriteLine("\n");
            Console.WriteLine(new string('-', 65));
            Console.WriteLine("| {0,-15} | {1,-25} | {2,-10} | {3,5} |", "MSSV", "HỌ TÊN", "KHOA", "ĐTB");
            Console.WriteLine(new string('-', 65));

            foreach (Student sv in listToDisplay)
            {
                sv.Show();
            }
            Console.WriteLine(new string('-', 65));
        }

        // 3. Xuất ra thông tin của các SV đều thuộc khoa "CNTT"
        static void ShowStudentByFaculty(List<Student> list, string faculty)
        {
            Console.WriteLine($"\n=== DANH SÁCH SINH VIÊN KHOA {faculty} ===");

            // Dùng LINQ Where để lọc
            var result = list.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();

            DisplayStudentList(result);
        }

        // 4. Xuất ra thông tin sinh viên có điểm TB lớn hơn bằng 5
        static void ShowStudentByScore(List<Student> list, float minScore)
        {
            Console.WriteLine($"\n=== DANH SÁCH SINH VIÊN CÓ ĐTB >= {minScore} ===");

            var result = list.Where(s => s.AverageScore >= minScore).ToList();

            DisplayStudentList(result);
        }

        // 5. Xuất ra danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần
        static void SortStudentByScoreAsc(List<Student> list)
        {
            Console.WriteLine("\n=== DANH SÁCH SẮP XẾP THEO ĐIỂM TĂNG DẦN ===");

            var result = list.OrderBy(s => s.AverageScore).ToList();

            DisplayStudentList(result);
        }

        //Xuất danh sách điểm TB >= 5 khoa CNTT
        static void ShowStudentByFacultyAndScore(List<Student> list, string faculty, float minScore)
        {
            Console.WriteLine($"\n=== SV KHOA {faculty} CÓ ĐIỂM >= {minScore} ===");

            var result = list.Where(s => s.AverageScore >= minScore &&
                                         s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();

            DisplayStudentList(result);
        }

        //Xuất ra danh sách điểm TB cao nhất thuộc CNTT
        static void ShowBestStudentInFaculty(List<Student> list, string faculty)
        {
            Console.WriteLine($"\n=== SINH VIÊN CÓ ĐIỂM CAO NHẤT KHOA {faculty} ===");

            //Lọc danh sách CNTT
            var cnttStudents = list.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();

            if (cnttStudents.Count == 0)
            {
                Console.WriteLine("Không có sinh viên nào thuộc khoa này.");
                return;
            }

            //  Tìm điểm cao nhất
            float maxScore = cnttStudents.Max(s => s.AverageScore);
            var result = cnttStudents.Where(s => s.AverageScore == maxScore).ToList();

            DisplayStudentList(result);
        }

        // 8. Thống kê số lượng từng xếp loại
        static void StudentStatistics(List<Student> list)
        {
            Console.WriteLine("\n=== THỐNG KÊ XẾP LOẠI HỌC LỰC ===");

            // Đếm số lượng theo điều kiện
            int xuatSac = list.Count(s => s.AverageScore >= 9.0 && s.AverageScore <= 10.0);
            int gioi = list.Count(s => s.AverageScore >= 8.0 && s.AverageScore < 9.0);
            int kha = list.Count(s => s.AverageScore >= 7.0 && s.AverageScore < 8.0);
            int trungBinh = list.Count(s => s.AverageScore >= 5.0 && s.AverageScore < 7.0);
            int yeu = list.Count(s => s.AverageScore >= 4.0 && s.AverageScore < 5.0);
            int kem = list.Count(s => s.AverageScore < 4.0);

            Console.WriteLine(new string('-', 30));
            Console.WriteLine("| {0,-15} | {1,8} |", "Xếp loại", "Số lượng");
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("| {0,-15} | {1,8} |", "Xuất sắc", xuatSac);
            Console.WriteLine("| {0,-15} | {1,8} |", "Giỏi", gioi);
            Console.WriteLine("| {0,-15} | {1,8} |", "Khá", kha);
            Console.WriteLine("| {0,-15} | {1,8} |", "Trung Bình", trungBinh);
            Console.WriteLine("| {0,-15} | {1,8} |", "Yếu", yeu);
            Console.WriteLine("| {0,-15} | {1,8} |", "Kém", kem);
            Console.WriteLine(new string('-', 30));
        }
        static List<Student> GetMockData()
        {
            List<Student> list = new List<Student>();

            list.Add(new Student("SV001", "Nguyễn Văn An", 9.5f, "CNTT"));  // Xuất sắc, CNTT
            list.Add(new Student("SV002", "Trần Thị Bích", 8.2f, "CNTT"));  // Giỏi, CNTT
            list.Add(new Student("SV003", "Lê Hoàng Cường", 7.0f, "QTKD")); // Khá, Khác khoa
            list.Add(new Student("SV004", "Phạm Thị Duyên", 5.5f, "NNA"));  // Trung bình
            list.Add(new Student("SV005", "Đỗ Văn Eo", 4.5f, "CNTT"));      // Yếu, CNTT (Test lọc <5)
            list.Add(new Student("SV006", "Vũ Thị F", 3.0f, "QTKD"));       // Kém

            return list;
        }
    }
}
