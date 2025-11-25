using System;

namespace Lab01_03
{
    class Student : Person
    {
        public float AverageScore { get; set; }
        public string Faculty { get; set; }

        public Student() { }

        public Student(string id, string name, float score, string faculty)
            : base(id, name)
        {
            this.AverageScore = score;
            this.Faculty = faculty;
        }

        public override void Input()
        {
            base.Input();

            Console.Write("Nhập Điểm TB: ");
            AverageScore = float.Parse(Console.ReadLine());
            Console.Write("Nhập Khoa: ");
            Faculty = Console.ReadLine();
        }

        public override void Show()
        {
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,5} |",
                this.ID, this.FullName, this.Faculty, this.AverageScore);
        }
    }
}