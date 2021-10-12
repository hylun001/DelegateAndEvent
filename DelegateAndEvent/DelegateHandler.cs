using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace DelegateAndEvent
{

    public class MultiLanguageHandler
    {
        public delegate string TranslateDelegate(string msg);
     

        public string EnglishTranslate(string msg)
        {
            return $"English - {msg}";
        }

        public string ChineseTranslate(string msg)
        {
            return $"中文 - {msg}";
        }


        public string GetMessage(string msg, TranslateDelegate translateDelegate)
        {
            Delegate[] delegates = translateDelegate.GetInvocationList();
            if (delegates == null || delegates.Length <= 0)
                return string.Empty;

            StringBuilder strBuf = new StringBuilder();
            Array.ForEach(delegates, item =>
            {
                strBuf.AppendLine(((TranslateDelegate)item).Invoke(msg));
            });

            return strBuf.ToString();
        }
    }
}
