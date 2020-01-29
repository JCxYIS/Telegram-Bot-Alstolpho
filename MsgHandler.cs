using System;
using Telegram.Bot.Args;

namespace AlstolphoBot
{
    public class MessageHandler : ConsoleTools
    {
        public void OnMessage(object sender, MessageEventArgs e) 
        {
            if (e.Message.Text != null)
            {
                Print($"{e.Message.From.Username}：{e.Message.Text}");
                new nhTest().Test(e);
                //await Core.botClient.SendTextMessageAsync(e.Message.Chat, "收到訊息:\n" + e.Message.Text);
            }
        }
        void CallComponents(MessageEventArgs e)
        {
            
        }

        public void OnInlineQuery(object sender, InlineQueryEventArgs i)
        {
            Print($"{i.InlineQuery.From} CHOOSE {i.InlineQuery.Query} in {i.InlineQuery.Id} | {i.InlineQuery.Offset}");            
            //await Core.botClient.SendTextMessageAsync(e.Message.Chat, "收到訊息:\n" + e.Message.Text);
        }
        
        public void OnInlineResultChosen(object sender, ChosenInlineResultEventArgs c)
        {
            Print($"{c.ChosenInlineResult.From} CHOOSE {c.ChosenInlineResult.Query}({c.ChosenInlineResult.ResultId}) in msg {c.ChosenInlineResult.InlineMessageId}");            
            //await Core.botClient.SendTextMessageAsync(e.Message.Chat, "收到訊息:\n" + e.Message.Text);
        }

        public void OnCallbackQuery(object sender, CallbackQueryEventArgs q)
        {
            Print($"{q.CallbackQuery.From} CHOOSE {q.CallbackQuery.Data} in msg {q.CallbackQuery.Message.Text}");            
            //await Core.botClient.SendTextMessageAsync(e.Message.Chat, "收到訊息:\n" + e.Message.Text);
        }
    }
}
