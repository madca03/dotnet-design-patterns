using System;
using System.Numerics;

namespace coding_exercise_21
{
    public interface IDiscrimnantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public class OrdinaryDiscriminantStrategy : IDiscrimnantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            return Math.Pow(b, 2) - (4 * a * c);
        }
    }

    public class RealDiscriminantStrategy : IDiscrimnantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            var discriminant = Math.Pow(b, 2) - (4 * a * c);
            return discriminant < 0 ? double.NaN : discriminant;
        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscrimnantStrategy strategy;

        public QuadraticEquationSolver(IDiscrimnantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            var discriminant = strategy.CalculateDiscriminant(a, b, c);
            Complex solution1 = (-b + Complex.Sqrt(discriminant)) / (2 * a);
            Complex solution2 = (-b - Complex.Sqrt(discriminant)) / (2 * a);
            return new Tuple<Complex, Complex>(solution1, solution2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var strategy = new OrdinaryDiscriminantStrategy();
            var tester = new QuadraticEquationSolver(strategy);
            var a = tester.Solve(1, 2, 3);
            Console.WriteLine(a.Item1.ToString());
            Console.WriteLine(a.Item2.ToString());
        }
    }
}
