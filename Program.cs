/* 
Här kommer header
*/

using System;

namespace guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriver ut instruktioner
            Console.WriteLine("1. Lägg till inlägg");
            Console.WriteLine("2. Ta bort inlägg");
            Console.WriteLine("3. Avsluta");

            // Läs inlägg från användaren
            string menyVal = Console.ReadLine();
            Console.WriteLine(menyVal);

            // Menyval 1 - lägger till inlägg
            if(menyVal == "1")
            {
                Console.WriteLine("Du valde att lägga till ett inlägg");
            }

            // Menyval 2 - tar bort ett inlägg
            if(menyVal == "2")
            {
                Console.WriteLine("Du valde att ta bort ett inlägg");
            }

            // Menyval 3 - Avsluta
            if(menyVal == "3")
            {
                Console.WriteLine("Du valde att avsluta");
            }

            // Array där alla inlägg sparas
            string[] posts = new string[] {};
        }
    }
}