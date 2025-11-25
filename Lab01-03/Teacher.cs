using System;

namespace Lab01_03
{
    class Teacher : Person
    {
        public string Address { get; set; }

        public Teacher() { }

        public Teacher(string id, string name, string address)
            : base(id, name)
        {
            this.Address = address;
        }

        public override void Input()
        {
            base.Input();

            Console.Write("Nhập Địa chỉ: ");
            Address = Console.ReadLine();
        }

        public override void Show()
        {
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-20} |",
                this.ID, this.FullName, this.Address);
        }
    }
}