using Prism.Mvvm;
using System.Collections.ObjectModel;
using TM.DailyTrackR.Common;
using TM.DailyTrackR.Logic;
using TM.DailyTrackR.DataType;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace TM.DailyTrackR.ViewModel
{

  public sealed class MainWindowViewModel: BindableBase
  {
		private ObservableCollection<Activity> activities = new();
		public ObservableCollection<Activity> activitiesForAll = new();

		private Activity selectedActivity;
		public Activity SelectedActivity
		{
			get { return selectedActivity; }
			set { SetProperty(ref selectedActivity, value); }
		}
		public ObservableCollection<Activity> Activities
		{
			get { return activities; }
			set { SetProperty(ref activities, value); }
		}
	
		public ObservableCollection<Activity> ActivitiesForAll
		{
			get { return activitiesForAll; }
			set { SetProperty(ref activitiesForAll, value); }
		}
		public DelegateCommand NewWindowCommand { get; }
		public DelegateCommand DeleteCommand { get; private set; }
		public MainWindowViewModel()
		{
			DeleteCommand = new DelegateCommand(DeleteExecute);

			NewWindowCommand = new DelegateCommand(NewWindowExecute);

			Activities = new ObservableCollection<Activity>();
			ActivitiesForAll = new ObservableCollection<Activity>();
			LoadDataForUser();
			LoadDataForAllUser();
			//LogicHelper.Instance.ExampleController.GetDailyTasks();
		}
		private void DeleteExecute()
		{
			Activity selectedActivity = SelectedActivity; // Get selected activity
			var result = MessageBox.Show("Are you sure you want to delete this item?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				Activities.Remove(selectedActivity);
				LogicHelper.Instance.ExampleController.DeleteActivity(selectedActivity.Id); // Or call your delete method
				//MessageBox.Show("Item deleted successfully.", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void NewWindowExecute()
		{
			ViewService.Instance.ShowWindow(new InsertTaskViewModel());
		}

		private void LoadDataForAllUser()
		{
			List<Activity> data = LogicHelper.Instance.ExampleController.GetDailyTasksForAll();
			ActivitiesForAll.Clear();
			foreach (var item in data)
			{
				ActivitiesForAll.Add(item);
			}
		}

		private void LoadDataForUser()
		{
			List<Activity> data = LogicHelper.Instance.ExampleController.GetDailyTasks();
			Activities.Clear();
			foreach (var item in data)
			{
				Activities.Add(item);
			}
		}
	}
}
