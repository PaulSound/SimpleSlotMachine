using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleSlotMachine  /////////////////////////////////// НУЖНО ДОДЕЛАТЬ!
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int finalScore = 0; 
        public static CancellationTokenSource tokenSource = new CancellationTokenSource();
        public MainWindow()
        {
            InitializeComponent();

        }
        private async void _pull_Click(object sender, RoutedEventArgs e)
        {
         

            var task = FirstDrumValue(new Random().Next(1,6));
            var task2 = FirstDrumValue2(new Random().Next(1, 6));
            var task3 = FirstDrumValue3(new Random().Next(1, 6));


            int[]arr = await Task.WhenAll(task, task2,task3);

            Task taskResult = ResultCalculation(arr);

            await taskResult;
            tokenSource.Dispose();
            tokenSource=new CancellationTokenSource();
        }

        async Task ResultCalculation(int[]arr)
        {
            if (arr[0]==7&& arr[1] == 7&& arr[2] == 7)
            {
                _jackpot.Text = "!! JACKPOT !!";
            }
            int result = arr.Sum();
            finalScore = result;
            _score.Text = finalScore.ToString();
        }

        async private Task<int> FirstDrumValue(int seconds)
        {
            int result = 0;
            while(seconds>=0)
            {
                ValueChanger1(tokenSource.Token);
                seconds -= 1;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            tokenSource.Cancel();
     
            result = int.Parse(_display1.Text);
            return result;
        }
        async void ValueChanger1(CancellationToken token)
        {
            while(!tokenSource.IsCancellationRequested)
            {
                _display1.Text = new Random().Next(1, 9).ToString();
                await Task.Delay(50);
            }
        }



        async private Task<int> FirstDrumValue2(int seconds)
        {
            int result = 0;
            while (seconds >= 0)
            {
                ValueChanger2(tokenSource.Token);
                seconds -= 1;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            tokenSource.Cancel();

            result = int.Parse(_display2.Text);
            return result;
        }
        async void ValueChanger2(CancellationToken token)
        {
            while (!tokenSource.IsCancellationRequested)
            {
                _display2.Text = new Random().Next(1, 9).ToString();
                await Task.Delay(50);
            }
        }


        async private Task<int> FirstDrumValue3(int seconds)
        {
            int result = 0;
            while (seconds >= 0)
            {
                ValueChanger3(tokenSource.Token);
                seconds -= 1;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            tokenSource.Cancel();

            result = int.Parse(_display3.Text);
            return result;
        }
        async void ValueChanger3(CancellationToken token)
        {
            while (!tokenSource.IsCancellationRequested)
            {
                _display3.Text = new Random().Next(1, 9).ToString();
                await Task.Delay(50);
            }
        }
    }
}

