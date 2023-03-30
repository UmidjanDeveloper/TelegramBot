using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace BasicTelegramBot
{
    class Bot
    {
        private static ITelegramBotClient botClient;

        static void Main()
        {
            botClient = new TelegramBotClient("5745073828:AAFOp2VamkHzKio6MG3EuVj7LfMnQ5eHEUE");

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, my name is {me.FirstName}");

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }

        static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"Received a message from {e.Message.Chat.Id}: {e.Message.Text}");

            if (e.Message.Text.ToLower() == "/start")
            {
                botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Hello! I can help you download any video from social media. Please send me the link.");
            }
            else
            {
                botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "Sorry, I didn't understand your message. Please type /start to begin.");
            }
        }
    }
}
