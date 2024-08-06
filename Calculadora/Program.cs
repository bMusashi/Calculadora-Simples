using System.Data;
using System.Xml.XPath;

namespace Calculadora
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WindowHeight = 12;
            Console.WindowWidth = 38;
            Console.BufferHeight = 12;
            Console.BufferWidth = 38;
            Console.Title = "Calculadora";

            double valOne = 0.0;            
            double valTwo = 0.0;               
            string Operation = "";            
            double result = 0.0;
            int first = 1;
            bool successOperation = true;
            string[] texts = {"Valor: ", "Operação: ", "Valor: ", "Resultado: "};

            while (true)
            {
                bool OneCorrect = false;
                bool TwoCorrect = false;
                bool OperationCorrect = false;
                Console.Clear();
                for (int i = 0; i < 4; i++)
                {
                    Console.SetCursorPosition(0,0 + i);
                    Console.Write(texts[i]);
                }                

                if (first == 1)
                {
                    do
                    {
                        Console.SetCursorPosition(7, 0);
                        try
                        {
                            valOne = Convert.ToDouble(Console.ReadLine());
                            OneCorrect = true;
                        }
                        catch
                        {                            
                            Messages.ClearField(7, 0, 31);
                            Messages.Error("Digite um número válido!");
                        }
                    }
                    while (!OneCorrect);

                    do
                    {
                        Console.SetCursorPosition(10, 1);
                        Operation = Console.ReadLine();
                        if (Operation != "+" && Operation != "-" && Operation != "*" && Operation != "/")
                        {                            
                            Messages.ClearField(10, 1, 28);                            
                            Messages.Error("Digite uma operação válida");
                        }
                        else
                        {
                            OperationCorrect = true;
                        }
                    } while (!OperationCorrect);

                    do
                    {
                        Console.SetCursorPosition(7, 2);
                        try
                        {
                            valTwo = Convert.ToDouble(Console.ReadLine());
                            TwoCorrect = true;
                        }
                        catch
                        {                            
                            Messages.ClearField(7, 2, 31);
                            Messages.Error("Digite um número válido!");
                        }
                    }
                    while (!TwoCorrect);

                    switch(Operation)
                    {
                        case "+":
                            result = Calculator.Sum(valOne, valTwo);
                            break;
                        case "-":                            
                            result = Calculator.Sub(valOne, valTwo);
                            break;
                        case "*":                            
                            result = Calculator.Mul(valOne,valTwo);
                            break;
                        case "/":
                            if (valTwo == 0.0)
                            {                                
                                Messages.Error("Não é possível dividir por zero!");
                                successOperation = false;
                            }
                            else
                            {
                                result = Calculator.Div(valOne, valTwo);
                            }                            
                            break;
                    }

                    Console.SetCursorPosition(11, 3);
                    Console.Write(result);

                    Console.ReadKey();

                    if (successOperation) first = 0;
                }
                else
                {
                    valOne = result;

                    Console.SetCursorPosition(7, 0);
                    Console.Write(valOne);

                    do
                    {
                        Console.SetCursorPosition(10, 1);
                        Operation = Console.ReadLine();
                        if (Operation != "+" && Operation != "-" && Operation != "*" && Operation != "/")
                        {                            
                            Messages.ClearField(10, 1, 28);
                            Messages.Error("Digite uma operação válida");
                        }
                        else
                        {
                            OperationCorrect = true;
                        }
                    } while (!OperationCorrect);

                    do
                    {
                        Console.SetCursorPosition(7, 2);
                        try
                        {
                            valTwo = Convert.ToDouble(Console.ReadLine());
                            TwoCorrect = true;
                        }
                        catch
                        {
                            Messages.ClearField(7, 2, 31);
                            Messages.Error("Digite um número válido!");
                        }
                    }
                    while (!TwoCorrect);

                    switch(Operation)
                    {
                        case "+":
                            result = Calculator.Sum(valOne, valTwo);
                            break;
                        case "-":                            
                            result = Calculator.Sub(valOne, valTwo);
                            break;
                        case "*":                            
                            result = Calculator.Mul(valOne,valTwo);
                            break;
                        case "/":
                            if (valTwo == 0.0) Messages.Error("Não é possível dividir por zero!");                            
                            else result = Calculator.Div(valOne, valTwo);                                                       
                            break;
                    }

                    Console.SetCursorPosition(11, 3);
                    Console.Write(result);

                    Console.ReadKey();
                }
            }
        }
    }
}

