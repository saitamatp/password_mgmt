using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace password_mgmt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string masterPwd = "";
        private string accountNme = "";
        private string accountPwd = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void view_Click(object sender, RoutedEventArgs e)
        {
            masterPwd = password.Password;
            if (masterPwd == "")
            {
                MessageBox.Show("Please enter a value");
            }
            else 
            { 
            showPwd.Content = execute(masterPwd.ToString());
            }  
        }

        public static string execute(string b)
        {
            string xchacha = @"D:\rust_src\xchacha\target\debug\xchacha.exe";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = xchacha;
            string c = $"1 {b}";
            p.StartInfo.Arguments = c;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;           
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            masterPwd = master_Password.Password;
            accountNme = account_Name.Text;
            accountPwd = account_password.Password;
            if (masterPwd == ""|accountNme==""|accountPwd=="")
            {
                MessageBox.Show("Please enter a value");
            }
            else
            {
                MessageBox.Show(addpwd(masterPwd.ToString(), accountNme.ToString(), accountPwd.ToString()));
            }

        }
        public static string addpwd(string a, string b, string d)
        {
            string xchacha = @"D:\rust_src\xchacha\target\debug\xchacha.exe";
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = xchacha;
            string c = $"2 {a} {b} {d}";
            p.StartInfo.Arguments = c;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output;
        }
    }
}
