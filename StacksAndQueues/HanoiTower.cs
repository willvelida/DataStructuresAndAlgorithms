using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    public class HanoiTower
    {
        public int DiscsCount { get; set; }
        public int MovesCount { get; set; }
        public Stack<int> From { get; set; }
        public Stack<int> To { get; set; }
        public Stack<int> Auxillary { get; set; }
        public event EventHandler<EventArgs> MoveCompleted;

        public HanoiTower(int discs)
        {
            DiscsCount = discs;
            From = new Stack<int>();
            To = new Stack<int>();
            Auxillary = new Stack<int>();
            for (int i = 1; i <= discs; i++)
            {
                int size = discs - i + 1;
                From.Push(size);
            }
        }

        public void Start()
        {
            Move(DiscsCount, From, To, Auxillary);
        }

        private void Move(int discs, Stack<int> from, Stack<int> to, Stack<int> auxillary)
        {
            if (discs > 0)
            {
                Move(discs - 1, from, auxillary, to);

                to.Push(from.Pop());
                MovesCount++;
                MoveCompleted?.Invoke(this, EventArgs.Empty);
                Move(discs - 1, auxillary, to, from);
            }
        }
    }
}
