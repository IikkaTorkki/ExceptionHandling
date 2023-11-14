namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicExceptionHandling();
            MultipleExceptionTypes();
            FinalyBlockUsage();
            CustomExceptionClass();
            ExceptionPropagation();
            UsingThrowAndCatch();
        }

        static void BasicExceptionHandling()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Convert the input to an integer using int.Parse().
            // Use a try-catch block to handle FormatException if the user enters a non-numeric value.
            // Display an error message in case of an exception.
            // Output the input if correct
            try
            {
                int nun = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"Parsed the number: {nun}");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"An exception ocurred: {e.Message}");
            }
        }

        static void MultipleExceptionTypes()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Include a catch block for OverflowException to handle cases where the number is too large or small for an int.
            // Display appropriate error messages for different exceptions.
            try
            {
                int num = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"Parsed the numer: {num}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Error parsing number: {e.Message}");
            }
        }

        static void FinalyBlockUsage()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Add a finally block to the program.
            // Use the finally block to display a message whether an exception was caught or not.
            bool caughtException = false;
            try
            {
                int num = int.Parse(Console.ReadLine()!);
                Console.WriteLine($"Parsed number: {num}");
            } catch (FormatException e)
            {
                caughtException = true;
            }
            finally
            {
                Console.WriteLine($"Exception occurred: {caughtException}");
            }
        }

        // Class for custom exception type
        class NegativeNumberException : ApplicationException
        {
            public NegativeNumberException(string message) : base(message) { }
        }

        static void CustomExceptionClass()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Modify your number input program to throw NegativeNumberException if the user enters a negative number.
            // Handle this exception in a separate catch block and display an appropriate message.
            try
            {
                int num = int.Parse(Console.ReadLine()!);
                if (num < 0)
                {
                    throw new NegativeNumberException("Negative number entered");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Error parsing number: {e.Message}");
            }
            catch (NegativeNumberException e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
            }
        }

        static void ExceptionPropagation()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumber that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // In this function, call CheckNumber inside a try block and handle the exception.
            try
            {
                int num = int.Parse(Console.ReadLine()!);
                CheckNumber(num);
                Console.WriteLine($"Number {num} checked");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Parsing failed: {e.Message}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Invalid input: {e.Message}");
            }
        }

        // NOTE: You can implement the CheckNumber here
        static void CheckNumber(int num)
        {
            if (num > 100)
            {
                throw new ArgumentOutOfRangeException($"{num} is out of range");
            }
        }

        static void UsingThrowAndCatch()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumberWithLogging that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // Modify the CheckNumberWithLogging function to log the exception message before throwing it.
            // In this function, catch the exception in the main program and display the logged message.
            try
            {
                int num = int.Parse(Console.ReadLine()!);
                CheckNumberWithLogging(num);
                Console.WriteLine($"Number {num} checked");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Parsing failed: {e.Message}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"Caught thrown exception: {e.Message}");
            }
        }

        // NOTE: You can implement the CheckNumberWithLogging here
        static void CheckNumberWithLogging(int num)
        {
            if (num > 100)
            {
                Console.WriteLine($"Error: The number {num} is out of range");
                throw new ArgumentOutOfRangeException($"{num} is out of range");
            }
        }
    }
}