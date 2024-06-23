using System;
using System.Collections.Generic;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using TM.DailyTrackR.Common;
using TM.DailyTrackR.DataType.Enums;

namespace TM.DailyTrackR.View
{
	/// <summary>
	/// Interaction logic for InsertTask.xaml
	/// </summary>
	public partial class InsertTask : Window
	{
		public InsertTask()
		{
			InitializeComponent();
			FillComboboxes();
		}
		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			bool isAnyFieldFilled = false;

			// Ellenőrizzük mindegyik mezőt
			if (!string.IsNullOrEmpty(DescriptionTextBox.Text))
			{
				isAnyFieldFilled = true;
			}
			else if (ProjectTypeCB.SelectedItem != null)
			{
				isAnyFieldFilled = true;
			}
			else if (TaskTypeCB.SelectedItem != null)
			{
				isAnyFieldFilled = true;
			}
			else if (StatusCB.SelectedItem != null)
			{
				isAnyFieldFilled = true;
			}
			else if (DatePicker.SelectedDate.HasValue)
			{
				isAnyFieldFilled = true;
			}
			if (isAnyFieldFilled)
			{
				LogicHelper.Instance.ExampleController.InsertActivity(ProjectTypeCB.SelectedIndex + 1, TaskTypeCB.SelectedIndex + 1, DescriptionTextBox.Text, "User A", StatusCB.SelectedIndex + 1, DatePicker.SelectedDate);
			
			}
			else
			{
				MessageBox.Show("Fill at least one field, please!");
			}
		}
		public void FillComboboxes()
		{
			TaskTypeCB.ItemsSource = Enum.GetValues(typeof(TaskTypeEnum)).Cast<TaskTypeEnum>();
			StatusCB.ItemsSource = Enum.GetValues(typeof(StatusEnum)).Cast<StatusEnum>();
			ProjectTypeCB.ItemsSource = Enum.GetValues(typeof(ProjectType)).Cast<ProjectType>();

		}
	}


}
