using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using xNet;

namespace SmsBomber_WPF.Services
{
    class CallMe_Services
    {
        static Random Rnd = new Random();

        public static string Regard(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);

                browser.AddHeader("X-Requested-With", "XMLHttpRequest");
                browser.AddHeader("Referer", "https://www.regard.ru/catalog/tovar297901.htm?ymclid=15669091338427679041000001");
                string response = Regex.Match(browser.Post("https://www.regard.ru/ajax/send_oz.php?flag=0&fio=" + Data.Names[Rnd.Next(Data.Names.Length)] + "&tel=" + number).ToString(), @"<span>(.*?)<\/span>").Groups[1].Value;
                return response == "Спасибо!" ? "Regard: Заявка на обратный звонок отправлена!" : "Regard: Fail";
            }
            catch (Exception e) { return $"Regard: {e.Message}"; }
        }
        public static string Brauberg(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);
                StringBuilder num = new StringBuilder(number);

                browser.AddHeader("X-Requested-With", "XMLHttpRequest");
                browser.AddHeader("Referer", "https://www.brauberg-rus.ru/");
                browser.Post("https://www.brauberg-rus.ru/index.php?route=common/send/zvonok", "name=" + Data.Names[Rnd.Next(Data.Names.Length)] + "&phone=+7 (" + num[1] + num[2] + num[3] +") " + num[4] + num[5] + num[6] + '-' + num[7] + num[8] + '-' + num[9] + num[10], "application/x-www-form-urlencoded");
                return "Brauberg: Заявка на обратный звонок отправлена!";
            }
            catch (Exception e) { return $"Brauberg: {e.Message}"; } 
        }
        public static string Actioncams(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);
                StringBuilder num = new StringBuilder(number);

                browser.AddHeader("X-Requested-With", "XMLHttpRequest");
                string response = Regex.Match(browser.Post("http://actioncams.pro/index.php?route=revolution/revpopupphone/make_order_phone", "firstname=" + Data.Names[Rnd.Next(Data.Names.Length)] + "&phone=+7 (" + num[1] + num[2] + num[3] + ") " + num[4] + num[5] + num[6] + num[7] + num[8] + num[9] + num[10] + "&email=" + Rnd.Next(52000) + "@yandex.ru&comment=Перезвоните&agree_pol_konf=on", "application/x-www-form-urlencoded; charset=UTF-8").ToString(), @"{""(.*?)""").Groups[1].Value;
                return response == "output"? "Actioncams: Заявка на обратный звонок отправлена!" : "Actioncams: Fail";
            }
            catch (Exception e) { return $"Actioncams: {e.Message}"; }
        }
        public static string CompYou(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);
                StringBuilder num = new StringBuilder(number);

                browser.AddHeader("X-Requested-With", "XMLHttpRequest");
                browser.Post("https://compyou.ru/call-me-back.html", "name=" + Data.Names[Rnd.Next(Data.Names.Length)] + "&phone=+7 (" + num[1] + num[2] + num[3] + ") " + num[4] + num[5] + num[6] + "-" + num[7] + num[8] + num[9] + num[10] + "&pdn_agree=yes", "application/x-www-form-urlencoded; charset=UTF-8");
                return "CompYou: Заявка на обратный звонок отправлена!";
            }
            catch (Exception e) { return $"CompYou: {e.Message}"; }
        }
        public static string Lamobile(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);
                StringBuilder num = new StringBuilder(number);

                browser.AddHeader("X-Requested-With", "XMLHttpRequest");
                browser.Post("https://lamobile.ru/ajax/callback/", "name=" + Data.Names[Rnd.Next(Data.Names.Length)] + "&phone=+7 (" + num[1] + num[2] + num[3] + ") " + num[4] + num[5] + num[6] + '-' + num[7] + num[8] + '-' + num[9] + num[10], "application/x-www-form-urlencoded; charset=UTF-8");
                return "Lamobile: Заявка на обратный звонок отправлена!";
            }
            catch (Exception e) { return $"Lamobile: {e.Message}"; }
        }
        public static string RcToday(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);
                StringBuilder num = new StringBuilder(number);

                browser.AddHeader("X-Requested-With", "XMLHttpRequest");
                 string response = browser.Post("https://rc-today.ru/phpshop/ajax/callback/controller.php", "user_name=" + Data.Names[Rnd.Next(Data.Names.Length)] + "&user_phone=+7 (" + num[1] + num[2] + num[3] + ") " + num[4] + num[5] + num[6] + '-' + num[7] + num[8] + '-' + num[9] + num[10] + "&form_send=1", "application/x-www-form-urlencoded; charset=UTF-8").ToString();
                return "RcToday: Заявка на обратный звонок отправлена!";
            }
            catch (Exception e) { return $"RcToday: {e.Message}"; }
        }



    }
}
