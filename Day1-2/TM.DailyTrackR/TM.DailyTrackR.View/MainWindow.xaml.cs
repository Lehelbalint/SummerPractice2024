namespace TM.DailyTrackR.View
{
	using System.Globalization;
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
			CloseLoginWindow();
			

		}
		private void CloseLoginWindow()
		{
			foreach (Window window in Application.Current.Windows)
			{
				if (window.Title == "LoginWindow")
				{
					window.Close();
				}
			}
		}
		private void ShowDiagramm(object sender, RoutedEventArgs e)
		{
			if (textBlock.Text != "")
			{
				ViewService.Instance.ShowWindow(new PlotDataViewModel(startDate: calendar.SelectedDates.Min(), endDate: calendar.SelectedDates.Max()));
			}
			else
			{
				MessageBox.Show("Select the period","Error");
			}
		}
		private void ExportToFile(object sender, RoutedEventArgs e)
		{
			if (textBlock.Text != "")

			{
				var startDate = calendar.SelectedDates.Min();
				var endDate = calendar.SelectedDates.Max();
				var activitiesRange = LogicHelper.Instance.OverviewTaskController.GetActivitiesByDate(startDate, endDate);
				var filename = $"TeamWeekActivity_{startDate.ToString("dd.MM.yyyy")}_{endDate.ToString("dd.MM.yyyy")}";
				string filePath = $"D:\\SummerPractice2024-BalintLehel\\SummerPractice2024\\Day1-2\\TM.DailyTrackR\\{filename}.txt"; // Add meg a fájl elérési útját
				string csvFilePath = $"D:\\SummerPractice2024-BalintLehel\\SummerPractice2024\\Day1-2\\TM.DailyTrackR\\{filename}.csv";
				ExportActivitiesToTxt(activitiesRange, filePath, startDate, endDate, csvFilePath);
			
				MessageBox.Show("Data Exported","Succes");


			}
			else {
				MessageBox.Show("Select the period","Error");
			}
		}
		public void ExportActivitiesToTxt(List<Activity> activities, string filePath, DateTime startDate, DateTime endDate,string csvFilePath)
		{
			var groupedActivities = activities
				.GroupBy(a => a.ProjectTypeDescription)
				.OrderBy(g => g.Key);

			ExportToCsv(activities, csvFilePath);

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

		private void ExportToCsv(IEnumerable<Activity> activities, string filePath)
		{
			var csv = new StringBuilder();
			csv.AppendLine("ProjectTypeDescription,ActivityType,ActivityDescription,Status");

			foreach (var activity in activities)
			{

				var newLine = $"{activity.ProjectTypeDescription},{(activity.ActivityType_Id)}," +
					$"{activity.ActivityDescription},{(activity.Status_Id)}";
				csv.AppendLine(newLine);
			}

			File.WriteAllText(filePath, csv.ToString());
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
						LogicHelper.Instance.DailyTaskController.UpdateActivity(editedItem);
					}
				}
			}
		}
	}
}

