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

namespace My_Simple_Emu_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool launchEmu(string emufilePath)
        {
            Console.WriteLine("Launching emulator in side function");
            Console.WriteLine(emufilePath);
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = emufilePath;
                process.EnableRaisingEvents = true;
                process.Exited += EmulatorClosed;
                WindowState = WindowState.Minimized;
                process.Start();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ps2_button_Click(object sender, RoutedEventArgs e)
        {
            /*
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = "C:\\Emulation\\PS2\\pcsx2-qt.exe";
                process.EnableRaisingEvents = true;
                process.Exited += EmulatorClosed;
                
                WindowState = WindowState.Minimized;
                process.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Debug.Log(ex.Message);
            }
            */
            Console.WriteLine("Launching PS1 Emulator from Function");
            launchEmu("C:\\Emulation\\PS2\\pcsx2-qt.exe");
        }

        private void EmulatorClosed(object sender, EventArgs e)
        {
            //this.WindowState = WindowState.Normal;
            //Application.Current.MainWindow.WindowState = WindowState.Normal;
            this.Dispatcher.Invoke(() => { Application.Current.MainWindow.WindowState = WindowState.Normal; Application.Current.MainWindow.Activate(); });
            //throw new NotImplementedException();
        }

        private void ps1_button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Launching PS1 Emulator from Function");
            launchEmu("C:\\Emulation\\PSX\\duckstation-qt-x64-ReleaseLTCG.exe");
        }

        private void ps3_button_Click(object sender, RoutedEventArgs e)
        {
            launchEmu("C:\\Emulation\\RPCS3\\rpcs3.exe");
        }

        private void nsw_button_Click(object sender, RoutedEventArgs e)
        {
            launchEmu("C:\\Emulation\\Switch\\Ryujinx\\Ryujinx.exe");
        }
    }
}
