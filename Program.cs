using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace AlstolphoBot
{
    public class Core : ConsoleTools
    {
        static public ITelegramBotClient botClient;

        static public void Main ( string [] args )
        {
            int retryTime = 0 ;
            Console.OutputEncoding = System.Text.Encoding.UTF8 ; // System.Text.Encoding.GetEncoding(950)
            while ( retryTime  <  10 )
            {
                retryTime ++ ;
                try
                {
                    new Core().InitAsync().GetAwaiter().GetResult();
                    Thread.Sleep(int.MaxValue);
                }
                catch ( Exception  e )
                {
                    Print( $"進行init時發生錯誤:重試次數{retryTime} / 10 \r\n {e} " , ConsoleColor.Red );
                    Thread.Sleep(1000);
                }
            }
            Print( $"無法init，主程序終結。按任何鍵結束... ", ConsoleColor.Cyan);
            Console.ReadKey();
        }
        async Task InitAsync()
        {
            string token = await File.ReadAllTextAsync("token.txt");
            botClient = new TelegramBotClient(token);

            var me = await botClient.GetMeAsync();
            Print($"認證成功！登入身分：{me.Id} 名：{me.FirstName}.", ConsoleColor.Cyan);

            botClient.OnMessage += new MessageHandler().OnMessage;
            //botClient.OnInlineResultChosen += new MessageHandler().OnInlineResultChosen;
            botClient.OnCallbackQuery += new MessageHandler().OnCallbackQuery;
            botClient.StartReceiving();
        }

        
        
    }
}
