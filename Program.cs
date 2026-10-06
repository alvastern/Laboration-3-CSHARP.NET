/* 
Projekt: Gästbok i C#

Författare: Alva Stern
Datum: 06-10-2026

Beskrivning: En gästbok som sparar inlägg i en lista och sparar
             den i en JSON-fil. En användare kan lägga till inlägg,
             ta bort inlägg och se alla inlägg som finns i gästboken.
*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista som sparar alla inlägg
            List<Post> listPosts = new List<Post>();

            // Filnamn som används när inlägg sparas i JSON-format
            string filePath = "guestbook.json";

            // Om en fil finns läses den in och deserialiseras till listan med inlägg
            if(File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                listPosts = JsonSerializer.Deserialize<List<Post>>(json);
            }

            while(true)
            {
                // Rensar konsolen
                Console.Clear();

                // Skapar ett index för varje inlägg
                int index = 0;

                // Loopar igenom listan
                foreach(Post post in listPosts)
                {
                    Console.Write("[" + index + "] ");
                    Console.WriteLine(post.owner);
                    Console.WriteLine(post.postText);
                    index++;
                }

                // Skriver ut instruktioner
                Console.WriteLine("1. Lägg till inlägg");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("3. Avsluta");

                // Läs menyval från användaren
                string menyVal = Console.ReadLine();

                // Felhantering om fel menyval anges
                if(menyVal != "1" && menyVal != "2" && menyVal != "3")
                {
                    Console.WriteLine("Du har inte angivit något giltigt menyval");
                }

                // Menyval 1 - lägger till inlägg
                if(menyVal == "1")
                {
                    Console.WriteLine("Du valde att lägga till ett inlägg");

                    // Vem äger inlägget?
                    Console.WriteLine("Vem är ägaren till inlägget?");
                    string owner = Console.ReadLine();

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

                    // Felhantering för om inget har skrivits i inlägget
                    while(string.IsNullOrWhiteSpace(postText))
                    {
                        Console.WriteLine("Du har inte skrivit något i inlägget.");
                        Console.WriteLine("Vad vill du skriva i inlägget?");
                        postText = Console.ReadLine();
                    }

                    // Skapar ett objekt av klassen Post, omvandlar till JSON och lägger till i listan
                    Post userPost = new Post();

                    userPost.owner = owner;
                    userPost.postText = postText;

                    listPosts.Add(userPost);

                    // Sparar listan med inlägg i JSON-format
                    string json = JsonSerializer.Serialize(listPosts);
                    File.WriteAllText(filePath, json);
                }

                // Menyval 2 - tar bort ett inlägg
                if(menyVal == "2")
                {
                    Console.WriteLine("Vilket index vill du ta bort?");
                    string deleteIndex = Console.ReadLine();

                    int selectedIndex = 0;

                    if(int.TryParse(deleteIndex, out selectedIndex))
                    {
                       if(selectedIndex >= 0 && selectedIndex < listPosts.Count)
                        {
                            listPosts.RemoveAt(selectedIndex);

                            string json = JsonSerializer.Serialize(listPosts);
                            File.WriteAllText(filePath, json);

                        } else
                        {
                            Console.WriteLine("Det finns inget inlägg med det indexet");
                        }

                    } else
                    {
                        Console.WriteLine("Du måste ange ett heltal");
                    }
                }

                // Menyval 3 - Avsluta
                if(menyVal == "3")
                {
                    Console.WriteLine("Du valde att avsluta");
                    break;
                }

                Console.WriteLine("Tryck enter för att fortsätta");
                Console.ReadLine();
            }
        }
    }
}