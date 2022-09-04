namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = Double(1, 12.5, 1);
        }

        public static IEnumerable<double> Double(double from, double to, double step)
        {
            if (step <= 0.0) step = (step == 0.0) ? 1.0 : -step;

            if (from <= to)
            {
                for (double d = from; d <= to; d += step) yield return d;
            }
            else
            {
                for (double d = from; d >= to; d -= step) yield return d;
            }
        }
    }
}