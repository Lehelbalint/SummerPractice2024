using Prism.Mvvm;
using System.Collections.ObjectModel;
using TM.DailyTrackR.Common;
using TM.DailyTrackR.Logic;
using TM.DailyTrackR.DataType;

namespace TM.DailyTrackR.ViewModel
{

  public sealed class MainWindowViewModel: BindableBase
  {
	private ObservableCollection<Activity> activities = new();
	public ObservableCollection<Activity> activitiesForAll = new();
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
		public MainWindowViewModel()
	{
		Activities = new ObservableCollection<Activity>();
		ActivitiesForAll = new ObservableCollection<Activity>();
		LoadDataForUser();
			LoadDataForAllUser();
			//LogicHelper.Instance.ExampleController.GetDailyTasks();
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
