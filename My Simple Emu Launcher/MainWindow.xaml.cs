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
            var emulators = new List<Emulator>();
            var retroarch = new Emulator();
            retroarch.Path = "C:\\Emulation\\RetroArch\\retroarch.exe";
            retroarch.Name = "RetroArch";
            retroarch.Icon = "C:\\Emulation\\RetroArch\\retroarch.png";
            emulators.Add(retroarch);
            var duckstation = new Emulator();
            duckstation.Path = "C:\\Emulation\\PSX\\duckstation-qt-x64-ReleaseLTCG.exe";
            duckstation.Name = "Duckstation";
            duckstation.Icon = "C:\\Emulation\\PSX\\duckstation.png";
            emulators.Add(duckstation);
            var pcsx2 = new Emulator();
            pcsx2.Path = "C:\\Emulation\\PS2\\pcsx2-qt.exe";
            pcsx2.Name = "PCSX2";
            pcsx2.Icon = "C:\\Emulation\\PS2\\pcsx2.png";
            emulators.Add(pcsx2);
            var rpcs3 = new Emulator();
            rpcs3.Path = "C:\\Emulation\\RPCS3\\rpcs3.exe";
            rpcs3.Name = "RPCS3";
            rpcs3.Icon = "C:\\Emulation\\RPCS3\\rpcs3.png";
            emulators.Add(rpcs3);
            var ryujinx = new Emulator();
            ryujinx.Path = "C:\\Emulation\\Switch\\Ryujinx\\Ryujinx.exe";
            ryujinx.Name = "Ryujinx";
            ryujinx.Icon = "C:\\Emulation\\Switch\\Ryujinx\\ryujinx.png";
            emulators.Add(ryujinx);
            var yuzu = new Emulator();
            yuzu.Path = "C:\\Emulation\\Switch\\Yuzu\\yuzu.exe";
            yuzu.Name = "Yuzu";
            yuzu.Icon = "C:\\Emulation\\Switch\\Yuzu\\yuzu.png";
            emulators.Add(yuzu);
            var dolphin = new Emulator();
            dolphin.Path = "C:\\Emulation\\Dolphin-x64\\Dolphin.exe";
            dolphin.Name = "Dolphin";
            dolphin.Icon = "C:\\Emulation\\Dolphin-x64\\dolphin.png";
            emulators.Add(dolphin);       
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
