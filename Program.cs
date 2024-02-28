using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NotificationParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get user input for notification title
            Console.WriteLine("Enter notification channels:");
            var title = Console.ReadLine();
            List<string> channels = ParseChannels(title);

            if (channels.Any())
            {
                Console.WriteLine($"Receive channels: {string.Join(", ", channels)}");
            }
            else
            {
                Console.WriteLine("No relevant channels found.");
            }
        }
        static List<string> ParseChannels(string title)
        {
            // Define notification channel tags
            List<string> ChannelTags = new List<string> { "BE", "FE", "QA", "Urgent" };
            // Extract relevant tags using regular expression
            var regex = new Regex(@"\[([^\]]+)\]");
            var matches = regex.Matches(title);

            // Filter and list the notification channels
            return matches.Select(m => m.Groups[1].Value)
                .Where(tag => ChannelTags.Contains(tag))
                .ToList();
        }
    }
}