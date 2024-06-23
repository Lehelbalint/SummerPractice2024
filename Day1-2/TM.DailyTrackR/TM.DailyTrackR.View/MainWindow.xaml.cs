namespace TM.DailyTrackR.View
{
	using System.IO;
	using System.Text;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Documents;
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
		private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
		{
			if (calendar.SelectedDates.Count > 0)
			{
				var startDate = calendar.SelectedDates.Min();
				var endDate = calendar.SelectedDates.Max();
				textBlock.Text = $"{startDate.ToShortDateString()} - {endDate.ToShortDateString()}";
			}
			else
			{
				textBlock.Text = "No selected range.";
			}
		}
		private void ToggleButton_Click(object sender, RoutedEventArgs e)
		{
			if (calendar.Visibility == Visibility.Visible)
			{
				calendar.Visibility = Visibility.Collapsed;
			}
			else
			{
				calendar.Visibility = Visibility.Visible;
			}
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

