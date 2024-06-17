namespace TM.DailyTrackR.ViewModel
{
  using Prism.Mvvm;
	using System.Windows;
	using TM.DailyTrackR.Common;

	public sealed class MainWindowViewModel: BindableBase
  {
    public MainWindowViewModel()
    {
            LogicHelper.Instance.ExampleController.GetDataExample();
    }
  }
}
