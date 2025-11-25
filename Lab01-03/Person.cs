using System;

namespace Lab01_03
{
    class Person
    {
        // 1. Properties
        public string ID { get; set; }
        public string FullName { get; set; }

        public Person() { }

        public Person(string id, string fullName)
        {
            this.ID = id;
            this.FullName = fullName;
        }

        // 2. Methods
        // Từ khóa 'virtual' cho phép lớp con override
        public virtual void Input()
        {
            Console.Write("Nhập Mã số: ");
            ID = Console.ReadLine();
            Console.Write("Nhập Họ tên: ");
            FullName = Console.ReadLine();
        }

        public virtual void Show()
        {
        }
    }
}