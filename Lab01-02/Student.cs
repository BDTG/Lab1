using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    class Student
    {
        // Tạo biến 
        private string studentID;
        private string fullName;
        private float averageScore;
        private string faculty;

        // Thuộc tính
        public string StudentID { get => studentID; set => studentID = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public float AverageScore { get => averageScore; set => averageScore = value; }
        public string Faculty { get => faculty; set => faculty = value; }

        // 3. Constructor
        public Student()
        {
        }

        public Student(string id, string name, float score, string faculty)
        {
            this.studentID = id;
            this.fullName = name;
            this.averageScore = score;
            this.faculty = faculty;
        }

        // Methods
        public void Input()
        {
            Console.Write("Nhập MSSV: ");
            StudentID = Console.ReadLine();

            Console.Write("Nhập Họ tên Sinh viên: ");
            FullName = Console.ReadLine();

            Console.Write("Nhập Điểm TB: ");         
            AverageScore = float.Parse(Console.ReadLine()); // ép kiểu

            Console.Write("Nhập Khoa: ");
            Faculty = Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine("| {0,-15} | {1,-25} | {2,-10} | {3,5} |",
            this.StudentID, this.FullName, this.Faculty, this.AverageScore);
        }
    }
}