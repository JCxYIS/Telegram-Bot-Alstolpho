using System;
using System.Collections.Generic;
using NHentaiAPI;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace AlstolphoBot
{
    public class nhTest
    {
        public async void Test(MessageEventArgs e)
        {
            var client = new NHentaiClient();
            var result = await client.GetSearchPageListAsync(e.Message.Text, 1);

            // find hon
            string s = "";     
            List<List<InlineKeyboardButton>> butts = 
                new List<List<InlineKeyboardButton>>(){new List<InlineKeyboardButton>()};
            for(int i = 0; i < 5 && i < result.Result.Count; i++)
            {
                s += $"<{i}> {result.Result[i].Title.Japanese}\n";
                InlineKeyboardButton selectbutt = new InlineKeyboardButton();
                InlineKeyboardButton previewbutt = new InlineKeyboardButton();
                selectbutt.Text = $"<{i}>";
                selectbutt.CallbackData = i.ToString();
                previewbutt.Text = "PREVIEW";
                previewbutt.Url = $"https://nhentai.net/g/{result.Result[i].Id}";
                butts.Add( new List<InlineKeyboardButton>(){selectbutt, previewbutt} );
            }
            InlineKeyboardMarkup ikb = new InlineKeyboardMarkup(butts);

            // Reply Keyboard            
            await Core.botClient.SendTextMessageAsync(
                e.Message.Chat,
                "找到:\n" + s,
                replyMarkup: ikb);
        }
    }
}