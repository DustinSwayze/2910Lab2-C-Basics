namespace Lab2_C__Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddTwoNumbers();
            NextStep();
            MultiTable();
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


    }
}