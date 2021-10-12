using System;

namespace DelegateAndEvent
{
    public delegate bool SendMessageDelegate(int index, string message);
    public class PublisherHandler
    {
        public event SendMessageDelegate OnSendMessageEvent;

        public void SendMessage(string msg)
        {
            if (OnSendMessageEvent == null)
                return;

            Delegate[] delegates = OnSendMessageEvent.GetInvocationList();
            if (delegates == null || delegates.Length <= 0)
                return;

            Console.WriteLine($"Begin Send message");

            for (int i = 0; i < delegates.Length; i++)
            {
                bool res = ((SendMessageDelegate)delegates[i]).Invoke(i + 1, msg);
                Console.WriteLine($"Send Message:{i + 1} - {(res ? "Successfully!" : "Failure!")}");
            }

            Console.WriteLine($"End Send message");
        }
    }

    public class SubscribeHandler
    {
        public static bool ReceivedMessage(int index,string message)
        {
            Console.WriteLine($"Received message:{index} - {message}");
            return true;
        }
    }
}
