using System;
using System.Text;

namespace Lab01_01
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.OutputEncoding = Encoding.UTF8;



            Console.WriteLine("=== Chương trình đoán số ===");

            Random random = new Random();
            int targetNumber = random.Next(100, 1000);
            string targetString = targetNumber.ToString();

            int attempt = 1;
            const int MAX_GUESS = 7;
            string guess = "";
            string feedback = "";
            bool isWin = false;
           
            while (attempt <= MAX_GUESS)
            {
                Console.Write("Lần đoán thứ {0}: ", attempt);
                guess = Console.ReadLine();
                
                if (guess.Length != 3)
                {
                    Console.WriteLine("Vui lòng nhập số có 3 chữ số!");
                    continue;
                }
                
                feedback = GetFeedback(targetString, guess);

                Console.WriteLine("Phản hồi từ máy tính: {0}", feedback);

                
                if (feedback == "+++")
                {
                    Console.WriteLine("Người chơi đã đoán {0} lần. Trò chơi kết thúc!", attempt);
                    Console.WriteLine("Người chơi thắng cuộc!");
                    isWin = true;
                    break; 
                }

                attempt++; 
            }

            if (!isWin)
            {
                Console.WriteLine("Người chơi thua cuộc. Số cần đoán là: {0}", targetNumber);
                Console.WriteLine("Người chơi thua cuộc!");
            }

            
            Console.ReadKey();
        }

        
        static string GetFeedback(string target, string guess)
        {
            string feedback = "";

            
            for (int i = 0; i < target.Length; i++)
            {
                // Đúng vị trí và số
                if (target[i] == guess[i])
                {
                    feedback += "+";
                }
                // Đúng nhưng sai
                else if (target.Contains(guess[i].ToString()))
                {
                    feedback += "?";
                }
                // Sai bét
            }

            return feedback;
        }
    }
}