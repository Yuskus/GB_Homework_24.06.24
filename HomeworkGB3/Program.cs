namespace HomeworkGB3
{
    internal class Program
    {
        static void Main()
        {
            // На семинаре вы делали с двойками, но мне кажется, что это даже проще.
            // Сделала без них, если принципиально - могу переделать.
            // Изменения будут тогда по сути на 38 строке.

            int[,] labirynth = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 0 },
                {1, 1, 0, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 }
            };

            Console.WriteLine("Количество выходов из лабиринта: " + HasExit(3, 0, labirynth));

            Console.ReadKey(true);
        }
        static int HasExit(int startI, int startJ, int[,] l)
        {
            int exitCount = 0;

            Stack<Tuple<int, int>> _path = new();

            if (l[startI, startJ] == 0) _path.Push(new(startI, startJ));

            while (_path.Count > 0)
            {
                var current = _path.Pop();

                if (current.Item1 == l.GetLength(0) - 1 || current.Item1 == 0 || current.Item2 == l.GetLength(1) - 1 || current.Item2 == 0) //38 строка
                {
                    Console.WriteLine($"Имеется выход на координате: [{current.Item1}, {current.Item2}]");
                    exitCount++;
                }

                l[current.Item1, current.Item2] = 1;

                if (current.Item1 + 1 < l.GetLength(0)
                && l[current.Item1 + 1, current.Item2] != 1)
                    _path.Push(new(current.Item1 + 1, current.Item2));

                if (current.Item2 + 1 < l.GetLength(1) &&
                l[current.Item1, current.Item2 + 1] != 1)
                    _path.Push(new(current.Item1, current.Item2 + 1));

                if (current.Item1 > 0 && l[current.Item1 - 1, current.Item2] != 1)
                    _path.Push(new(current.Item1 - 1, current.Item2));

                if (current.Item2 > 0 && l[current.Item1, current.Item2 - 1] != 1)
                    _path.Push(new(current.Item1, current.Item2 - 1));
            }

            return exitCount;
        }
    }
}
