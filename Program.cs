/* 
Här kommer header
*/

using System;
using System.Collections.Generic;

namespace guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista som sparar alla inlägg
            List<Post> listPosts = new List<Post>();

            while(true)
            {
                // Loopar igenom listan
                foreach(Post post in listPosts)
                {
                    Console.WriteLine(post.owner);
                    Console.WriteLine(post.postText);
                }

                // Skriver ut instruktioner
                Console.WriteLine("1. Lägg till inlägg");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("3. Avsluta");

                // Läs menyval från användaren
                string menyVal = Console.ReadLine();
                Console.WriteLine(menyVal);

                // Menyval 1 - lägger till inlägg
                if(menyVal == "1")
                {
                    Console.WriteLine("Du valde att lägga till ett inlägg");

                    // Vem äger inlägget?
                    Console.WriteLine("Vem är ägaren till inlägget?");
                    string owner = Console.ReadLine();
                    Console.WriteLine(owner);

                    // Felhantering för om ingen ägare skrivits in
                    while(string.IsNullOrWhiteSpace(owner))
                    {
                        Console.WriteLine("Du har inte skrivit in någon ägare.");
                        Console.WriteLine("Vem är ägaren till inlägget?");
                        owner = Console.ReadLine();
                    }

                    // Vad står i inlägget
                    Console.WriteLine("Vad vill du skriva i inlägget?");
                    string postText = Console.ReadLine();
                    Console.WriteLine(postText);

                    // Felhantering för om inget har skrivits i inlägget
                    while(string.IsNullOrWhiteSpace(postText))
                    {
                        Console.WriteLine("Du har inte skrivit något i inlägget.");
                        Console.WriteLine("Vad vill du skriva i inlägget?");
                        postText = Console.ReadLine();
                    }

                    // Skapar ett projekt av klassen Post och lägger till i listan
                    Post userPost = new Post();

                    userPost.owner = owner;
                    userPost.postText = postText;

                    listPosts.Add(userPost);
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
                    break;
                }
            }
        }
    }
}