namespace TM.DailyTrackR.View
{
	using System.IO;
	using System.Text;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Documents;
	using TM.DailyTrackR.Common;
	using TM.DailyTrackR.DataType;
	using TM.DailyTrackR.DataType.Enums;
	using TM.DailyTrackR.ViewModel;

	public partial class MainWindow : Window
  {
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new MainWindowViewModel();
			
		}
		private void ExportToFile(object sender, RoutedEventArgs e)
		{
			if (textBlock.Text != "")

			{
				var startDate = calendar.SelectedDates.Min();
				var endDate = calendar.SelectedDates.Max();
				var activitiesRange = LogicHelper.Instance.ExampleController.GetActivitiesByDate(startDate, endDate);
				var filename = $"TeamWeekActivity_{startDate.ToString("dd.MM.yyyy")}_{endDate.ToString("dd.MM.yyyy")}.txt";
				string filePath = $"D:\\SummerPractice2024-BalintLehel\\SummerPractice2024\\Day1-2\\TM.DailyTrackR\\{filename}"; // Add meg a fájl elérési útját
				ExportActivitiesToTxt(activitiesRange, filePath, startDate, endDate);
				MessageBox.Show("Data Exported");
			}
			else {
				MessageBox.Show("Select the period");
			}
		}
		public void ExportActivitiesToTxt(List<Activity> activities, string filePath, DateTime startDate, DateTime endDate)
		{
			var groupedActivities = activities
				.GroupBy(a => a.ProjectTypeDescription)
				.OrderBy(g => g.Key);

			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine($"Team Activity in the period {startDate.ToString("dd.MM.yyyy")} – {endDate.ToString("dd.MM.yyyy")}");
				writer.WriteLine();

				foreach (var group in groupedActivities)
				{
					writer.WriteLine($"{group.Key}:");

					var newTasks = group.Where(a => a.ActivityType_Id == TaskTypeEnum.New).OrderBy(a => a.ActivityDescription);
					var fixTasks = group.Where(a => a.ActivityType_Id == TaskTypeEnum.Fix).OrderBy(a => a.ActivityDescription);

					if (newTasks.Any())
					{
						writer.WriteLine();
						foreach (var activity in newTasks)
						{
							if (activity.Status_Id == StatusEnum.InProgress || activity.Status_Id == StatusEnum.OnHold)
							{
								writer.WriteLine($"- {activity.ActivityDescription} – {activity.Status_Id}");
							}
							else
							{
								writer.WriteLine($"- {activity.ActivityDescription}");
							}
						}
						writer.WriteLine();
					}

					if (fixTasks.Any())
					{
						writer.WriteLine("Fixes:");
						foreach (var activity in fixTasks)
						{
							if (activity.Status_Id == StatusEnum.InProgress || activity.Status_Id == StatusEnum.OnHold)
							{
								writer.WriteLine($"- {activity.ActivityDescription} – {activity.Status_Id}");
							}
							else
							{
								writer.WriteLine($"- {activity.ActivityDescription}");
							}
						}
						writer.WriteLine();
					}
				}
			}
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

