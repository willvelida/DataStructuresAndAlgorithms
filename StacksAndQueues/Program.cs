using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    class Program
    {
        private const int DISCS_COUNT = 10;
        private const int DELAY_MS = 250;
        private static int _columnSize = 30;

        static void Main(string[] args)
        {
            // Reversing words example
            ReversingWords("William Velida");

            // HanoiTower example
            //_columnSize = Math.Max(6, GetDiscWidth(DISCS_COUNT) + 2);
            //HanoiTower algorithm = new HanoiTower(DISCS_COUNT);
            //algorithm.MoveCompleted += Algorithm_Visualize;
            //Algorithm_Visualize(algorithm, EventArgs.Empty);
            //algorithm.Start();

            // Call center example: QUEUES
            Random random = new Random();

            CallCenter center = new CallCenter();
            center.Call(1234);
            center.Call(5678);
            center.Call(1468);
            center.Call(9641);

            while (center.AreWaitingCalls())
            {
                IncomingCall call = center.Answer("Will");
                Log($"Call #{call.Id} from {call.ClientId} is answered by {call.Consultant}.");
                Thread.Sleep(random.Next(1000, 10000));
                center.End(call);
                Log($"Call #{call.Id} from {call.ClientId} is answered by {call.Consultant}.");
            }
        }

        private static void Log(string text)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}]{text}");
        }

        private static int GetDiscWidth(int size)
        {
            return 2 * size - 1;
        }

        private static void Algorithm_Visualize(object sender, EventArgs e)
        {
            Console.Clear();

            HanoiTower algorithm = (HanoiTower)sender;
            if (algorithm.DiscsCount <= 0)
            {
                return;
            }

            char[][] visualization = InitializeVisualization(algorithm);
            PrepareColumn(visualization, 1, algorithm.DiscsCount, algorithm.From);
            PrepareColumn(visualization, 2, algorithm.DiscsCount, algorithm.To);
            PrepareColumn(visualization, 3, algorithm.DiscsCount, algorithm.Auxillary);

            Console.WriteLine(Center("FROM") + Center("TO") + Center("AUXILIARY"));
            DrawVisualization(visualization);
            Console.WriteLine();
            Console.WriteLine($"Number of moves: {algorithm.MovesCount}");
            Console.WriteLine($"Number of discs: {algorithm.DiscsCount}");

            Thread.Sleep(DELAY_MS);
        }

        private static string Center(string text)
        {
            int margin = (_columnSize - text.Length) / 2;
            return text.PadLeft(margin + text.Length).PadRight(_columnSize);
        }

        private static void DrawVisualization(char[][] visualization)
        {
            for (int y = 0; y < visualization.Length; y++)
            {
                Console.WriteLine(visualization[y]);
            }
        }

        private static void PrepareColumn(char[][] visualization, int column, int discsCount, Stack<int> stack)
        {
            int margin = _columnSize * (column - 1);
            for (int y = 0; y < stack.Count; y++)
            {
                int size = stack.ElementAt(y);
                int row = discsCount - (stack.Count - y);
                int columnStart = margin + discsCount - size;
                int columnEnd = columnStart + GetDiscWidth(size);
                for (int x = columnStart; x <= columnEnd; x++)
                {
                    visualization[row][x] = '=';
                }
            }
        }

        private static char[][] InitializeVisualization(HanoiTower algorithm)
        {
            char[][] visualization = new char[algorithm.DiscsCount][];

            for (int y = 0; y < visualization.Length; y++)
            {
                visualization[y] = new char[_columnSize * 3];
                for (int x = 0; x < _columnSize * 3; x++)
                {
                    visualization[y][x] = ' ';
                }
            }

            return visualization;
        }

        public static string ReversingWords(string word)
        {
            Stack<char> chars = new Stack<char>();

            foreach (char c in word)
            {
                chars.Push(c);
            }

            while (chars.Count > 0)
            {
                Console.Write(chars.Pop());
            }

            Console.WriteLine();

            return word;
        }


    }
}
