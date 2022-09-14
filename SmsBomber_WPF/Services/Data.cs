using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace SmsBomber_WPF.Services
{
    class Data
    {
        static Random Rnd = new Random();
        public static int delay;
        public static string[] Numbers;
        public static string Number;
        public static string[] Proxys;
        public static string Proxy;
        public static string Type_Proxy;
        public static string[] Names = {"Абрам","Аваз","Август","Авдей","Автандил","Адам","Адис","Адольф","Адриан", "Азарий","Аким","Алан",
            "Александр","Алексей","Альберт","Альфред","Амадей","Амадеус","Амаяк","Анатолий","Ангел","Андоим","Андрей","Аникита","Антон" };
        public static void CheckProxy(HttpRequest browser)
        {
            browser.UserAgent = Http.ChromeUserAgent();
            switch (Type_Proxy)
            {
                case "Http":
                    browser.Proxy = HttpProxyClient.Parse(Data.Proxys != null ? Data.Proxys[Rnd.Next(Data.Proxys.Length)] : Data.Proxy != null ? Data.Proxy : null);
                    break;
                case "Socks4":
                    browser.Proxy = Socks4ProxyClient.Parse(Data.Proxys != null ? Data.Proxys[Rnd.Next(Data.Proxys.Length)] : Data.Proxy != null ? Data.Proxy : null);
                    break;
                case "Socks4a":
                    browser.Proxy = Socks4aProxyClient.Parse(Data.Proxys != null ? Data.Proxys[Rnd.Next(Data.Proxys.Length)] : Data.Proxy != null ? Data.Proxy : null);
                    break;
                case "Socks5":
                    browser.Proxy = Socks5ProxyClient.Parse(Data.Proxys != null ? Data.Proxys[Rnd.Next(Data.Proxys.Length)] : Data.Proxy != null ? Data.Proxy : null);
                    break;
            }
        }
    }
}
