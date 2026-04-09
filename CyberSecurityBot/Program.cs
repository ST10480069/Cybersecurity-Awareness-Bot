using System;
using System.IO;
using System.Media; // Required for SoundPlayer

namespace CyberSecurityBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Display the ASCII Art Logo
            DisplayLogo();

            // 2. Play the welcome audio
            PlayWelcomeSound("welcome.wav");

            // 3. Interactive Greeting
            Console.Write("\n[SYSTEM]: Please enter your name to authenticate: ");
            string userName = Console.ReadLine();

            // 4. Personalized Welcome with Decorative Border
            DisplayPersonalizedMessage(userName);

            // Keep the console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
                __________________
               /                  \
              /   ##############   \
             |    ##          ##    |
             |    ##  [ SHIELD ] ##    |
             |    ##          ##    |
              \   ##############   /
               \__________________/
                      |    |
                    --|____|--
            ");
            Console.WriteLine("========================================");
            Console.WriteLine("               CYBER BOT                ");
            Console.WriteLine("========================================");
            Console.ResetColor();
        }

        static void PlayWelcomeSound(string fileName)
        {
            try
            {
                // SoundPlayer looks for the file relative to the .exe location
                using (SoundPlayer player = new SoundPlayer(fileName))
                {
                    player.Play(); // Use .PlaySync() if you want the code to wait for audio to finish
                }
            }
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[NOTICE]: Audio file 'welcome.wav' not found. Continuing in silent mode.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR]: Could not play audio. {ex.Message}");
            }
        }

        static void DisplayPersonalizedMessage(string name)
        {
            string message = $"Welcome to the system, {name}. Your security is our priority.";
            string border = new string('*', message.Length + 4);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(border);
            Console.WriteLine($"* {message} *");
            Console.WriteLine(border);
            Console.ResetColor();
        }
    }
}