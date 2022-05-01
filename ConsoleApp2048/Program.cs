using System;
using System.Threading;
using Game2048;

namespace ConsoleApp2048
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //Todo: program.Download();
            program.Start();

        }
        
        void Start()
        {
            Model model= new Model(4);
            model.Start();
            while (true)
            {
                Show(model);
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.LeftArrow: model.Left();break;
                    case ConsoleKey.RightArrow: model.Right(); break;
                    case ConsoleKey.UpArrow: model.Up(); break;
                    case ConsoleKey.DownArrow: model.Down(); break;
                    case ConsoleKey.Escape: return;
                    case ConsoleKey.F4: model.Start();break;
                }
            }
        }

        void Show(Model model)
        {
            for (int y = 0; y < model.size;y++)
                for (int x = 0; x < model.size; x++)
                {
                    Console.SetCursorPosition(x * 5 + 5, y * 2 + 2);
                    int number = model.GetMap(x, y);
                    Console.Write(number == 0 ? ". " : number.ToString() + " ");
                }
            Console.WriteLine();
            if (model.IsGameOver())
                Console.WriteLine("Game Over");
            else 
                Console.WriteLine("Still play");
        }

        void Download()
        {
            var count_poces = 5;
            int steps = 100 / count_poces + 1;
            Console.WriteLine("Download");
            Console.WriteLine("[{0}]", new String(' ', steps));

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            for (int process = 0; process < steps; process++)
            {
                Console.SetCursorPosition(process + 1, Console.CursorTop);
                Console.Write("|");

                Console.SetCursorPosition(steps + 3, Console.CursorTop);
                Console.Write("{0}%", process * count_poces);

                Random r = new Random();
                Thread.Sleep(r.Next(40, 600));
            }
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hi!Its my Console 2048 Game");
        }
    }
}
