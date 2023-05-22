using System.Data;
using System.Runtime.InteropServices;
using ConsoleTables;

namespace Lab2_C__Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddTwoNumbers();
            NextStep();
            MultiTable();
            NextStep();
            TypeTable();
            Calculator();
        }

        public static void NextStep() //method for usability. simple press any key to continue
        {
            Console.WriteLine("Press any key to continue:");
            var x = Console.ReadLine();
            Console.Clear();
        }
        public static void AddTwoNumbers() //Takes two user inputs, adds them together. basic validation
        {
            Console.WriteLine("Enter the first integer:");
            int input1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second integer:");
            int input2 = Convert.ToInt32(Console.ReadLine());

            int sum = input1 + input2;

            Console.WriteLine($"{input1} + {input2} = {sum}");
        }

        public static void MultiTable() //multiplication table, takes two integers and iterates through the table
        {

            Console.WriteLine("Enter an integer:");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the maximum integer to multiply by:");
            int maxNumber = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= maxNumber; i++)
            {
                int result = number * i;
                Console.WriteLine($"{number} * {i} = {result}");
            }
        }

        public static void TypeTable() //call methods for the type table
        {
            DisplayNumberTypeInfo<sbyte>("sbyte");
            DisplayNumberTypeInfo<byte>("byte");
            DisplayNumberTypeInfo<short>("short");
            DisplayNumberTypeInfo<ushort>("ushort");
            DisplayNumberTypeInfo<int>("int");
            DisplayNumberTypeInfo<uint>("uint");
            DisplayNumberTypeInfo<long>("long");
            DisplayNumberTypeInfo<ulong>("ulong");
            DisplayNumberTypeInfo<float>("float");
            DisplayNumberTypeInfo<double>("double");
            DisplayNumberTypeInfo<decimal>("decimal");
        }

        static void DisplayNumberTypeInfo<T>(string typeName) where T : struct //define constrained type and output as a ConsoleTable
        {
            int sizeInBytes = GetSizeOf<T>();
            T minValue = (T)Convert.ChangeType(GetMinValue<T>(), typeof(T));
            T maxValue = (T)Convert.ChangeType(GetMaxValue<T>(), typeof(T));

            var table = new ConsoleTable("Type", "Size (Bytes)", "Min Value", "Max Value");
            table.AddRow(typeName, sizeInBytes, minValue, maxValue);
            table.Write(Format.Alternative);
        }

        static int GetSizeOf<T>()
        {
            return Marshal.SizeOf(typeof(T));
        } //get generic size

        static T GetMinValue<T>()
        {
            Type underlyingType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            return (T)underlyingType.GetField("MinValue").GetValue(null);
        } //get generic minvalue

        static T GetMaxValue<T>()
        {
            Type underlyingType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            return (T)underlyingType.GetField("MaxValue").GetValue(null);
        } //get generic max value

        static void Calculator() //very basic calculator. user gets to choose operations
        {
            bool exit = false;
            double result = 0.0;
            double newResult = 0.0;

            while (!exit)
            {
                Console.WriteLine($"Current result is : {result}");
                Console.WriteLine("Enter 'esc' to exit or enter a new number to continue");
                string input = Console.ReadLine();

                if (input.ToLower() == "esc")
                {
                    exit = true;
                    break;
                }

                double num1;
                if (!double.TryParse(input, out num1))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                Console.WriteLine("Enter an operation (+, -, *, /, %):");
                string operation = Console.ReadLine();

                Console.WriteLine("Enter the second number: ");
                double num2;
                if (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            Console.WriteLine("Error: Division by zero is not allowed.");
                            continue;
                        }
                        break;
                    case "%":
                        result = num1 % num2;
                        break;
                    default:
                        Console.WriteLine("Invalid operation. Please enter a valid operation.");
                        continue;
                }

                Console.WriteLine("Result: {0}", result);
            }

            Console.WriteLine("Exiting the calculator.");
        }
    }
}