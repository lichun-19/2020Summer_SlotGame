using System;
using System.Threading;
using System.Windows.Forms;
namespace project1
{
    class Program
    {
        public static System.Drawing.Point Position { get;}

        static void display(int x, int y)
        {
            char[] factors = { '@', '#', '$', '%', '&', '*', '!', '=' };
            Random num = new Random();
            for (int i = 0; i < 20; ++i)
            {
                    int space = num.Next(0, 69);
                    Console.Write(factors[space / 10]);
                    Console.SetCursorPosition(x, y);
                    Thread.Sleep(200);

            }
        }
        static void Main(string[] args)
        {
            int lifes = 10;
            Console.WriteLine("歡迎來到超級拉霸機！ee");
            Console.WriteLine("進入遊戲後您可以選擇不同遊戲模式，每種模式產生的結果會使您獲得/失去不同數量的金幣，盡情地探索吧！");
            while (true)
            {
                char[] factors = { '@', '#', '$', '%', '&', '*', '!', '=' };
                int[] compare = new int[3];
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("目前剩餘" + lifes + "枚金幣");
                Console.WriteLine("使用一枚金幣開始遊戲");
                lifes--;
                Console.WriteLine("請選擇模式: 1.一般模式  2.成功者（需額外使用三枚金幣）");
                int mode = Int32.Parse(Console.ReadLine());

                //一般模式
                if (mode == 1)
                {

//this.Cursor = new Cursor(Cursor.Current.Handle);
                    display(Cursor.Position.X,Cursor.Position.Y);
                    /*Random num = new Random();
                    for (int i = 0; i < 100; i++)
                    {
                        int space = num.Next(0, 69);
                        Console.Write(factors[space / 10]);
                        this.Cursor = new Cursor(Cursor.Current.Handle);
                        Console.SetCursorPosition(Cursor.Position.X - 1, Cursor.Position.y);
                        Console.ReadKey(true);
                        compare[i] = space;
                    }
                    */

                    Console.Write("\n");
                }

                //成功者模式
                else if (mode == 2 && lifes >= 3)
                {
                    lifes -= 3;
                    int[] smallrange = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        Random num = new Random();
                        int space2 = num.Next(0, 69);
                        smallrange[i] = space2 / 10;
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        Random num2 = new Random();
                        int HigherProbability = num2.Next(0, 2);
                        Console.Write(factors[smallrange[HigherProbability]]);
                        Console.Write(" ");
                        compare[j] = smallrange[HigherProbability];
                        Console.ReadKey(true);
                    }
                    Console.Write("\n");
                }
                //選擇成功者模式卻金幣不足

                else if (mode == 2 && lifes < 3)
                {
                    Console.WriteLine("餘額不足，別無選擇的回去當一般人。");
                    Console.ReadKey(true);
                    Random num = new Random();
                    for (int i = 0; i < 3; i++)
                    {
                        int space = num.Next(0, 7);
                        Console.Write(factors[space]);
                        Console.Write(" ");
                        Console.ReadKey(true);
                        compare[i] = space;
                    }
                    Console.Write("\n");
                }
                //防止錯誤
                else
                {
                    Console.WriteLine("輸入格式錯誤，請重新開始。");
                    continue;
                }
                //判斷遊戲結果
                if (compare[0] == compare[1] & compare[1] == compare[2])
                {
                    Console.WriteLine("恭喜您奪得頭獎，並獲得10枚金幣！");
                    lifes += 10;
                }
                //2.成功者模式的全異
                else if (mode == 2 && compare[0] != compare[1] && compare[1] != compare[2] && compare[0] != compare[2])
                {
                    Console.WriteLine("全都不一樣，再失去三枚金幣～");
                    lifes -= 3;
                }
                //一般模式的全異
                else if (mode == 1 && compare[0] != compare[1] && compare[1] != compare[2] && compare[0] != compare[2])
                {
                    Console.WriteLine("全都不一樣，再失去一枚金幣～");
                    lifes--;
                }
                //成功者模式的二同一異
                else if (mode == 2)
                {
                    Console.WriteLine("哎呀差一點點，再失去一枚金幣～");
                    lifes--;
                }
                //一般模式的二同一異
                else
                {
                    Console.WriteLine("哎呀差一點點，下次再試試！");
                }
                //判斷是否繼續遊戲
                if (lifes <= 0)
                {
                    Console.WriteLine("金幣不足，遊戲結束");
                    break;
                }
                else { };
                Console.WriteLine("按下0重新開始，或按下1結束遊戲");
                int starter = Int32.Parse(Console.ReadLine());
                if (starter == 1)
                {
                    Console.WriteLine("遊戲結束");
                    break;
                }
                else continue;
            }


        }

    }

}