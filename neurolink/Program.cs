using System;

namespace neurolink
{
    class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }
            public decimal Smoothing { get; set; } = 0.0001m

            public decimal ConvertInputData(decimal input);
            {
                return input * weight;
            }

            public decimal RestoreOutputData(decimal output)
            {
                return output / weight;
            }

            public void Train(decimal input, decimal expectedResult)
            {
                var actualResult = input * weight;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction; 
            }
        }

        static void Main(string[] args)
        {
            decimal km = 100;
            decimal mile = 62.1371m;

            Neuron neuron = new Neuron();
            do
            {
                neuron.Train(km, mile);
                Console.WriteLine(neuron.LastError);
            } while (Math.Abs(neuron.LastError) > neuron.Smoothing);

            Console.WriteLine("done!");
            Console.WriteLine(neuron.ConvertInputData(km));
        }
    }
}
