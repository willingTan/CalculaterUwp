using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace text
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private List<double> Record = new List<double>();//记录数字
        private List<int> Character = new List<int>();//记录符号状态
        private bool ADD = false;
        private bool MINUS = false;
        private bool MULTIPLY = false;
        private bool DIVIDE = false;
        private bool RESULT = false;
        string redown;

        public void WriteDown(string num)
        {
            if(ADD||MINUS||MULTIPLY||DIVIDE||RESULT)
            {
                if(RESULT)
                {
                    In.Text = "";
                }
                Out.Text = "";
                ADD = false;
                MINUS = false;
                MULTIPLY = false;
                DIVIDE = false;
                RESULT = false;
            }
            In.Text += num;
            redown += num;          
        }
        private void Re_Down(string txt)//最为重要的一个重载
        {
            Record.Add(double.Parse(redown));
            redown = "";
        }

        private void c1_Click(object sender, RoutedEventArgs e)
        {
            WriteDown("1");
        }

        private void c2_Click(object sender, RoutedEventArgs e)
        {
            WriteDown("2");
        }

        private void c3_Click(object sender, RoutedEventArgs e)
        {
            WriteDown("3");
        }

        private void c4_Click(object sender, RoutedEventArgs e)
        {
            WriteDown("4");
        }

        private void c5_Click(object sender, RoutedEventArgs e)
        {
            WriteDown("5");
        }

        private void c6_Click(object sender, RoutedEventArgs e)
        {
            WriteDown("6");
        }

        private void c7_Click(object sender, RoutedEventArgs e)
        {
            WriteDown("7");
        }

        private void c8_Click(object sender, RoutedEventArgs e)
        {
            WriteDown("8");
        }

        private void c9_Click(object sender, RoutedEventArgs e)
        {
            WriteDown("9");
        }

        private void c0_Click(object sender, RoutedEventArgs e)
        {
            WriteDown("0");
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (!ADD)
            {
                RESULT = false;
                Re_Down(In.Text);
                Character.Add(0);
                In.Text += "+";
                ADD = true;
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (!MINUS)
            {
                RESULT = false;
                Re_Down(In.Text);
                Character.Add(1);
                In.Text += "-";
                MINUS = true;
            }
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            if(!MULTIPLY)
            {
                RESULT = false;  
                Character.Add(2);
                Re_Down(In.Text);
                In.Text = "(" + In.Text + ")" + "*";
                MULTIPLY = true;
            }
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            if(!DIVIDE)
            {
                RESULT = false;
                Re_Down(In.Text);
                Character.Add(3);
                In.Text = "(" + In.Text + ")" + "/";
                DIVIDE = true;
            }
        }

        private void Is_Click(object sender, RoutedEventArgs e)
        {
            Record.Add(double.Parse(redown));
            if (Record.Count > 0 && Character.Count > 0)
            {
                //double total;
                //total = Record[0];
                //Out.Text += total;

                double total = Record[0];                           //有问题。。。
                string check="";
                for (int i = 0; i < Character.Count; i++)
                {
                    int character = Character[i];
                    switch (character)
                    {
                        case 0:
                            total += Record[i + 1];
                            check = "";
                            break;
                        case 1:
                            total -= Record[i + 1];
                            check = "";
                            break;
                        case 2:
                            total *= Record[i + 1];
                            check = "";
                            break;
                        case 3:
                            if (Record[i + 1] == 0)
                            {
                                total = 2222222222222;
                                check = "很二的Error";
                                break;
                            }
                            total /= Record[i + 1];
                            check = " ";
                            break;
                    }
                }
                Out.Text = "=" + total+check;
                Character.Clear();
                Record.Clear();
                redown = "";
                RESULT = true;
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            Record.Clear();
            Character.Clear();
            ADD = false;
            MINUS = false;
            MULTIPLY = false;
            DIVIDE = false;
            RESULT = false;
            Out.Text = "";
            In.Text = "";
        }



        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //base.OnNavigatedTo(e);

        //Debug.WriteLine("OK");
        //}




    }
}
