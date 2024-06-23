namespace TM.DailyTrackR.View
{
  using System.Windows;
	using System.Windows.Controls;
	using TM.DailyTrackR.Common;
	using TM.DailyTrackR.DataType;
	using TM.DailyTrackR.ViewModel;

	public partial class MainWindow : Window
  {
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainWindowViewModel();
		}
		private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
		{
			calendarPopup.IsOpen = true;
		}

		private void Calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
		{
			if (calendar.DisplayMode == CalendarMode.Year)
			{
				calendar.DisplayMode = CalendarMode.Month;
			}
		}

		private void OnSelectIntervalClick(object sender, RoutedEventArgs e)
		{
			var selectedDates = calendar.SelectedDates;
			if (selectedDates.Count == 0)
			{
				MessageBox.Show("Please selec t a date range.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			DateTime startDate = selectedDates.Min();
			DateTime endDate = selectedDates.Max();

			MessageBox.Show($"Selected interval:\nStart Date: {startDate.ToShortDateString()}\nEnd Date: {endDate.ToShortDateString()}", "Date Interval", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void DataGridDaily_CurrentCellChanged(object sender, EventArgs e )
		{
			var dataGrid = sender as DataGrid;
			if (dataGrid != null && dataGrid.SelectedItem != null)
			{
				var viewModel = DataContext as MainWindowViewModel;
				if (viewModel != null)
				{
					var editedItem = dataGrid.SelectedItem as Activity;
					if (editedItem != null)
					{
						LogicHelper.Instance.ExampleController.UpdateActivity(editedItem);
					}
				}
			}
		}
	}
}

