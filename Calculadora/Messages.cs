namespace Calculadora
{
    internal class Messages
    {        
        internal static void Error(string message)
        {
            Console.SetCursorPosition(0, 10);
            Console.WriteLine(message);
        }
        internal static void ClearField(int posX, int posY, int size)
        {
            Console.SetCursorPosition(posX, posY);
            for (int i = 0; i < size; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
