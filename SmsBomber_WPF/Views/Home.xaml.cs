using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using SmsBomber_WPF.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace SmsBomber_WPF
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : INotifyPropertyChanged
    {
        public static bool Working;
        public static sbyte[] Run_Fun;
        public delegate string delegate_Send_SMS(string number);
        public static event delegate_Send_SMS Send_SMS;
        public delegate string delegate_CallMe(string number);
        public static event delegate_CallMe CallMe;
        List<Thread> Threads = new List<Thread>();
        public static byte CountThread;

        Thread potok;

        public Home()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Start_Click(object sender, MouseButtonEventArgs e)
        {
            if ((string)(sender as Label).Content == "Start")
            {
                Working = true;
                if (CountThread != 0)
                {
                    for (int i = 0; i < CountThread; i++)
                    {
                        Threads.Add(new Thread(Global));
                        Threads[i].IsBackground = true;
                    }
                    foreach (var x in Threads)
                    {
                        Thread.Sleep(20);
                        x.Start();
                    }
                    (sender as Label).Content = "Stop";
                    return;
                }
                potok = new Thread(Global);
                potok.IsBackground = true;
                potok.Start();
                (sender as Label).Content = "Stop";

            }
            else {
                Working = false;
                if (Threads != null)
                {
                    foreach(var x in Threads)
                        x.Abort();
                    Threads.Clear();
                    (sender as Label).Content = "Start"; return;
                }
                potok.Abort();
                (sender as Label).Content = "Start";
            }
        }

        private Random rnd = new Random();
        void Global()
        {
             while (Working)
            {
                if (Send_SMS != null && Data.delay != 0 && (Data.Numbers != null || Data.Number != null))
                    Dispatcher.Invoke(new _AppendLog(AppendLog), Send_SMS(Data.Numbers != null ? Data.Numbers[rnd.Next(Data.Numbers.Length)] : Data.Number));
                else if (CallMe != null && Data.delay != 0 && (Data.Numbers != null || Data.Number != null))
                    Dispatcher.Invoke(new _AppendLog(AppendLog), CallMe(Data.Numbers != null ? Data.Numbers[rnd.Next(Data.Numbers.Length)] : Data.Number));
                else { MessageBox.Show("Не все поля заполнены!", "Error"); break; }
            }
        }

        delegate void _AppendLog(string text);
        private void AppendLog(string text)
        {
            if (Log.Document.Blocks.Count < 500)
                Log.AppendText(text + "\r");
            else
                Log.Document.Blocks.Clear();
        }              

        #region Обновление элементов формы
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
