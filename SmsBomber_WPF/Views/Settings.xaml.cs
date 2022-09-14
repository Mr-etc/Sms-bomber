using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using SmsBomber_WPF.Services;
using System.Text.RegularExpressions;

namespace SmsBomber_WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : INotifyPropertyChanged
    {
        DoubleAnimation Animation = new DoubleAnimation();
        string NameCheck;
        public bool Check_proxy
        {
            get
            {
                return Data.Proxys != null ? true : Data.Proxy != null ? true : false;
            }
            set
            {
                OnPropertyChanged();
            }
        }
        public string Proxy
        {
            get
            {
                return Data.Proxy;
            }
            set
            {
                if (Regex.IsMatch(value, @"^\d+\.\d+\.\d+\.\d+\:\d+$"))
                    Data.Proxy = value;
                else
                {
                    Data.Proxy = "";
                    if(value != "") throw new ArgumentException();
                }
                Check_proxy = true;
                OnPropertyChanged();
            }
        }
        public string Number
        {
            get
            {
                return Data.Number;
            }
            set
            {
                if(value == "")
                    Data.Number = "";
                else if (value.Length < 12 && char.IsDigit(value, value.Length - 1))
                    Data.Number = value;
                OnPropertyChanged();
            }
        }
        public string delay
        {
            get
            {
                if (Data.delay == 0)
                    return null;
                else return Data.delay.ToString();
            }
            set
            {
                if (value == "")
                    Data.delay = 0;
                else if (value.Length < 6 && char.IsDigit(value, value.Length - 1))
                    Data.delay = Convert.ToInt32(value);
                OnPropertyChanged();
            }
        }
        public string Threads
        {
            get
            {
                return Home.CountThread == 0 ? "" : Home.CountThread.ToString();
            }
            set
            {
                if (value == "")
                    Home.CountThread = 0;
                else if (char.IsDigit(value, value.Length - 1) && Convert.ToInt32(value) < 251)
                    Home.CountThread = Convert.ToByte(value);
                OnPropertyChanged();
            }
        }

        public Settings()
        {
            InitializeComponent();
            Animation.Duration = TimeSpan.FromSeconds(1);
            DataContext = this;
        }


        #region Анимации в настройках
        private void Animation_Settings(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as Label).Content.ToString())
            {
                case "SMS сервисы":
                    Animation.From = SMS_Block.ActualHeight;
                    Animation.To = SMS_Block.ActualHeight == 30 ? 183 : 30;
                    SMS_Block.BeginAnimation(HeightProperty, Animation);
                    break;
                case "Call me сервисы":
                    Animation.From = CallMe_Block.ActualHeight;
                    Animation.To = CallMe_Block.ActualHeight == 30 ? 183 : 30;
                    CallMe_Block.BeginAnimation(HeightProperty, Animation);
                    break;
                case "Основные настройки":
                    Animation.From = Main_Block.ActualHeight;
                    Animation.To = Main_Block.ActualHeight == 30 ? 183 : 30;
                    Main_Block.BeginAnimation(HeightProperty, Animation);
                    break;
            }
        }
        #endregion

        #region Загрузка Номеров
        private void Load_Nimbers(object sender, MouseButtonEventArgs e)
        {
            if ((string)(sender as Label).Content == "Загрузить номера")
            {
                OpenFileDialog OpFile = new OpenFileDialog();
                OpFile.Filter = "Text Files|*.txt";
                if (OpFile.ShowDialog() == true)
                {
                    Data.Numbers = File.ReadAllLines(OpFile.FileName);
                    (sender as Label).Content = "Удалить номера";
                    Number = "";
                    Number_texbox.IsEnabled = false;
                    foreach (string x in Data.Numbers)
                        NumbersList.AppendText(x);
                }
            }
            else
            {
                NumbersList.Document.Blocks.Clear();
                Number_texbox.IsEnabled = true;
                (sender as Label).Content = "Загрузить номера";
                Data.Numbers = null;
            }
        }
        #endregion

        #region Загрузить Proxy
        private void Load_Proxy(object sender, MouseButtonEventArgs e)
        {
            if ((string)(sender as Label).Content == "Загрузить proxy")
            {
                OpenFileDialog OpFile = new OpenFileDialog();
                OpFile.Filter = "Text Files|*.txt";
                if (OpFile.ShowDialog() == true)
                {
                    foreach (string x in File.ReadAllLines(OpFile.FileName))
                        if (!Regex.IsMatch(x, @"^\d+\.\d+\.\d+\.\d+\:\d+$"))
                        {
                            MessageBox.Show("Не все proxy соответствуют стандарту 'Ip:port' !", "Error");
                            return;
                        }
                    Data.Proxys = File.ReadAllLines(OpFile.FileName);
                    Check_proxy = true;
                    (sender as Label).Content = "Удалить proxy";
                }
            }
            else
            {
                Data.Proxys = null;
                (sender as Label).Content = "Загрузить proxy";
                Check_proxy = true;
            }
        }
        #endregion

        #region Установка и Снятие Чека
        private void SMS_CheckBox(object sender, RoutedEventArgs e)
        {
            NameCheck = (string)(sender as CheckBox).Content;
            if (NameCheck == "All" || NameCheck == "Yandex") if ((sender as CheckBox).IsChecked == true) Home.Send_SMS += SMS_Services.Yandex;
                else Home.Send_SMS -= SMS_Services.Yandex;
            if (NameCheck == "All" || NameCheck == "ICQ") if ((sender as CheckBox).IsChecked == true) Home.Send_SMS += SMS_Services.ICQ;
                else Home.Send_SMS -= SMS_Services.ICQ;
            if (NameCheck == "All" || NameCheck == "Odnoklassniki") if ((sender as CheckBox).IsChecked == true) Home.Send_SMS += SMS_Services.odnoklass;
                else Home.Send_SMS -= SMS_Services.odnoklass;
            if (NameCheck == "All" || NameCheck == "VipPlay") if ((sender as CheckBox).IsChecked == true) Home.Send_SMS += SMS_Services.VipPlay;
                else Home.Send_SMS -= SMS_Services.VipPlay;
            if (NameCheck == "All" || NameCheck == "Instagram") if ((sender as CheckBox).IsChecked == true) Home.Send_SMS += SMS_Services.Instagram;
                else Home.Send_SMS -= SMS_Services.Instagram;
            if (NameCheck == "All" || NameCheck == "Bxmaker") if ((sender as CheckBox).IsChecked == true) Home.Send_SMS += SMS_Services.bxmaker;
                else Home.Send_SMS -= SMS_Services.bxmaker;
            if (NameCheck == "All" || NameCheck == "Strelka Card") if ((sender as CheckBox).IsChecked == true) Home.Send_SMS += SMS_Services.strelkacard;
                else Home.Send_SMS -= SMS_Services.strelkacard;
            if (NameCheck == "All" || NameCheck == "YouLa") if ((sender as CheckBox).IsChecked == true) Home.Send_SMS += SMS_Services.YouLa;
                else Home.Send_SMS -= SMS_Services.YouLa;
            if (NameCheck == "All" || NameCheck == "HoTik") if ((sender as CheckBox).IsChecked == true) Home.Send_SMS += SMS_Services.HoTik;
                else Home.Send_SMS -= SMS_Services.HoTik;
        }

        private void CallMe_Check(object sender, RoutedEventArgs e)
        {
            NameCheck = (string)(sender as CheckBox).Content;
            if (NameCheck == "All" || NameCheck == "Regard") if ((sender as CheckBox).IsChecked == true) Home.CallMe += CallMe_Services.Regard;
                else Home.CallMe -= CallMe_Services.Regard;
            if (NameCheck == "All" || NameCheck == "Brauberg") if ((sender as CheckBox).IsChecked == true) Home.CallMe += CallMe_Services.Brauberg;
                else Home.CallMe -= CallMe_Services.Brauberg;
            if (NameCheck == "All" || NameCheck == "Actioncams") if ((sender as CheckBox).IsChecked == true) Home.CallMe += CallMe_Services.Actioncams;
                else Home.CallMe -= CallMe_Services.Actioncams;
            if (NameCheck == "All" || NameCheck == "CompYou") if ((sender as CheckBox).IsChecked == true) Home.CallMe += CallMe_Services.CompYou;
                else Home.CallMe -= CallMe_Services.CompYou;
            if (NameCheck == "All" || NameCheck == "Lamobile") if ((sender as CheckBox).IsChecked == true) Home.CallMe += CallMe_Services.Lamobile;
                else Home.CallMe -= CallMe_Services.Lamobile;
            if (NameCheck == "All" || NameCheck == "RcToday") if ((sender as CheckBox).IsChecked == true) Home.CallMe += CallMe_Services.RcToday;
                else Home.CallMe -= CallMe_Services.RcToday;
        }
        private void Type_Proxy(object sender, RoutedEventArgs e)
        {
            Data.Type_Proxy = (sender as RadioButton).IsChecked == true ? (string)(sender as RadioButton).Content : "";
        } //radiobutton's

        #endregion

        #region Обновление элементов формы
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
