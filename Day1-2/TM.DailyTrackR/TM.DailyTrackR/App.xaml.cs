namespace TM.DailyTrackR
{
  using System.Windows;
	using TM.DailyTrackR.Common;
	using TM.DailyTrackR.View;
  using TM.DailyTrackR.ViewModel;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Register View

            //MainWindow window = new();
            //window.DataContext = new MainWindowViewModel();
            //window.ShowDialog();
            ViewService.Instance.RegisterView(typeof(LoginViewModel), typeof(LoginWindow));
            ViewService.Instance.RegisterView(typeof(MainWindowViewModel), typeof(MainWindow));
            ViewService.Instance.RegisterView(typeof(InsertTaskViewModel), typeof(InsertTask));
            ViewService.Instance.RegisterView(typeof(PlotDataViewModel), typeof(PlotData));
            ViewService.Instance.ShowDialog(new LoginViewModel());
        }
    }
}
