namespace Lab2_C__Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            addTwoNumbers();
        }
        public static void addTwoNumbers()
        {
            Console.WriteLine("Enter the first number:");
            int input1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            int input2 = Convert.ToInt32(Console.ReadLine());

            int sum = input1 + input2;

            Console.WriteLine($"{input1} + {input2} = {sum}");

            //make some changes for the pull
        }


    }
}