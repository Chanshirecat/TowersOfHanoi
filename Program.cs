using System;

namespace TowersOfHanoi
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Parses command line arguments
            if (args.Length < 2)
            {
                Console.WriteLine("How to write your Argument: hanoi [-Recursive|-Iterative] [number of disks]");
                return;
            }

            string method = args[0];
            int numDisks = int.Parse(args[1]);

            // Create and initialize TowersOfHanoi instance
            var hanoi = new TowersOfHanoi(numDisks);

            // Call appropriate method based on user input
            switch (method.ToLower())
            {
                case "hanoi-recursive":
                    hanoi.MoveDisksRecursive();
                    break;
                case "hanoi-iterative":
                    hanoi.MoveDisksIterative();
                    break;
                default:
                    Console.WriteLine("Invalid method specified. Usage: hanoi [-Recursive|-Iterative] [numDisks]");
                    return;
            }

            Console.WriteLine($"Number of moves: {hanoi.MovesCounter}");
        }
    }

    class TowersOfHanoi
    {
        public Stack<int>[] _sticks = new Stack<int>[3];
        public int _numDisks;
        public int _movesCounter = 0;

        public int MovesCounter
        {
            get { return _movesCounter; }
        }

        public TowersOfHanoi(int numDisks)
        {
            _numDisks = numDisks;
            for (int i = 0; i < 3; i++)
            {
                _sticks[i] = new Stack<int>();
            }
            for (int i = numDisks; i >= 1; i--)
            {
                _sticks[0].Push(i);
            }
        }

        public void MoveDisk(int fromStick, int toStick)
        {
            if(_sticks[fromStick].Count == 0) // If from stick is empty, then the disk should go from toStick to fromStick
            {
                int tempDisk = _sticks[toStick].Pop();
                _sticks[fromStick].Push(tempDisk);
                Console.WriteLine($"Moved disk {tempDisk} from stick {toStick} to stick {fromStick}");
                return;
            }

            if(_sticks[toStick].Count == 0) // If to stick is empty, then the disk should go to toStick from fromStick
            {
                int tempDisk = _sticks[fromStick].Pop();
                _sticks[toStick].Push(tempDisk);
                Console.WriteLine($"Moved disk {tempDisk} from stick {fromStick} to stick {toStick}");
                return;
            }

            if (_sticks[fromStick].Peek() < _sticks[toStick].Peek())
            {
                int tempDisk = _sticks[fromStick].Pop();
                _sticks[toStick].Push(tempDisk);
                Console.WriteLine($"Moved disk {tempDisk} from stick {fromStick} to stick {toStick}");
                return;
            }

            if (_sticks[fromStick].Peek() > _sticks[toStick].Peek())
            {
                int tempDisk = _sticks[toStick].Pop();
                _sticks[fromStick].Push(tempDisk);
                Console.WriteLine($"Moved disk {tempDisk} from stick {toStick} to stick {fromStick}");
            }
        }

        public void MoveDisksRecursive()
        {
            MoveDisksRecursive(_sticks, _numDisks, 0, 2);
        }

        public void MoveDisksRecursive(Stack<int>[] sticks, int numDisks, int fromStick, int toStick)
        {
            if (numDisks == 1)
            {
                MoveDisk(fromStick, toStick);
            }
            else
            {
                int spareStick = 3 - fromStick - toStick;
                MoveDisksRecursive(sticks, numDisks - 1, fromStick, spareStick);
                MoveDisk(fromStick, toStick);
                MoveDisksRecursive(sticks, numDisks - 1, spareStick, toStick);
            }
        }

        public void MoveDisksIterative()
        {
            // Calculates the total number of moves required to solve the Towers of Hanoi
            int totalMoves = (int)Math.Pow(2, _numDisks) - 1;

            // Set up the starting positions of the three sticks.
            int fromStick = 0, auxStick = 1, toStick = 2;

            // If the number of disks is even, swap the auxiliary and target stick.
            if (_numDisks % 2 == 0)
            {
                toStick = 1;
                auxStick = 2;
            }

            // Loops through each move and performs the appropriate action
            for (int i = 1; i <= totalMoves; i++)
            {
                if (i % 3 == 1)
                {
                    // If the move number is a multiple of 3 plus 1, move a disk from the fromStick to the toStick
                    MoveDisk(fromStick, toStick);
                }
                else if (i % 3 == 2)
                {
                    // If the move number is a multiple of 3 plus 2, move a disk from the fromStick to the AuxStick
                    MoveDisk(fromStick, auxStick);
                }
                else if (i % 3 == 0)
                {
                    // If the move number is a multiple of 3, move a disk from the AuxStick to the toStick
                    MoveDisk(auxStick, toStick);
                }
                _movesCounter ++;
            }
        }
    }
}