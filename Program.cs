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
        }

        public static void NextStep()
        {
            Console.WriteLine("Press any key to continue:");
            var x = Console.ReadLine();
            Console.Clear();
        }
        public static void AddTwoNumbers()
        {
            Console.WriteLine("Enter the first number:");
            int input1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            int input2 = Convert.ToInt32(Console.ReadLine());

            int sum = input1 + input2;

            Console.WriteLine($"{input1} + {input2} = {sum}");

            //make some changes for the pull
        }

        public static void MultiTable()
        {

            Console.WriteLine("Enter a number:");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the maximum number to multiply by:");
            int maxNumber = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= maxNumber; i++)
            {
                int result = number * i;
                Console.WriteLine($"{number} * {i} = {result}");
            }
        }

        public static void TypeTable()
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

        static void DisplayNumberTypeInfo<T>(string typeName) where T : struct
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
        }

        static T GetMinValue<T>()
        {
            Type underlyingType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            return (T)underlyingType.GetField("MinValue").GetValue(null);
        }

        static T GetMaxValue<T>()
        {
            Type underlyingType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
            return (T)underlyingType.GetField("MaxValue").GetValue(null);
        }

    }
}