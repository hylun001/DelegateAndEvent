using System;
using static DelegateAndEvent.MultiLanguageHandler;

namespace DelegateAndEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegateTest();
            Console.WriteLine("==========================分割线==========================");
            EventTest();

            Console.ReadLine();
        }

        private static void DelegateTest()
        {
            MultiLanguageHandler multiLanguageHandler = new MultiLanguageHandler();

            #region 委托
            TranslateDelegate chineseDelegate = multiLanguageHandler.ChineseTranslate;
            Console.WriteLine(chineseDelegate.Invoke("123"));
            string chineseMsg = multiLanguageHandler.GetMessage("您好", chineseDelegate);
            //string chineseMsg = multiLanguageHandler.GetMessage("您好", multiLanguageHandler.ChineseTranslate);
            Console.WriteLine(chineseMsg);
            #endregion 委托

            #region 委托
            TranslateDelegate englishDelegate = multiLanguageHandler.EnglishTranslate;
            string englishMsg = multiLanguageHandler.GetMessage("Hello", englishDelegate);
            //string englishMsg = multiLanguageHandler.GetMessage("Hello", multiLanguageHandler.EnglishTranslate);
            Console.WriteLine(englishMsg);

            #endregion 委托

            #region 多播委托
            TranslateDelegate @delegate = multiLanguageHandler.ChineseTranslate;
            @delegate += multiLanguageHandler.EnglishTranslate;
            string res = multiLanguageHandler.GetMessage(" HaHa", @delegate);
            Console.WriteLine(res);

            #endregion 多播委托
        }

        private static void EventTest()
        {
            PublisherHandler publisherHandler = new PublisherHandler();
            publisherHandler.OnSendMessageEvent += SubscribeHandler.ReceivedMessage;
            publisherHandler.OnSendMessageEvent += SubscribeHandler.ReceivedMessage;
            publisherHandler.SendMessage("Hello Word!");

        }

    }
}
