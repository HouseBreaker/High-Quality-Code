using System.Windows;

namespace SolarSystem
{
	using System;
	using System.Threading;

	using SolarSystem.Classes;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrbitsCalculator _data = new OrbitsCalculator();
        public MainWindow()
        {
            DataContext = _data;
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _data.StartTimer();

			// Profiling: closes the application after 10 seconds.
			var profilingTimer = new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
				
				const int msToSleep = 20000;
				Thread.Sleep(msToSleep);
				Environment.Exit(0);
			});

			profilingTimer.Start();
		}

        private void Pause_Checked(object sender, RoutedEventArgs e)
        {
            _data.Pause(true);
        }

        private void Pause_Unchecked(object sender, RoutedEventArgs e)
        {
            _data.Pause(false);
        }
    }
}
