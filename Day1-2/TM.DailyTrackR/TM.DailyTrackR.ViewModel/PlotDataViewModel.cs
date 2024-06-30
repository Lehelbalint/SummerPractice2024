using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TM.DailyTrackR.Common;

namespace TM.DailyTrackR.ViewModel
{
	public class PlotDataViewModel : BindableBase
	{
		private PlotModel plotModel;
		public PlotModel PlotModel
		{
			get { return plotModel; }
			set { SetProperty(ref plotModel, value); }
		}
		public PlotDataViewModel(DateTime startDate, DateTime endDate) {
			UpdatePlotModel(startDate, endDate);
		}

		private void UpdatePlotModel(DateTime startDate,DateTime endDate)
		{
			var model = new PlotModel { Title = "Activities Over Time" };
			var series = new LineSeries { Title = "Number of Activities"};

			var activitiesPerDate = LogicHelper.Instance.PlotController.GetActivitesPerDay(startDate,endDate);

			foreach (var data in activitiesPerDate)
			{
				series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.Date), data.ActivityCount));
			}

			model.Axes.Add(new DateTimeAxis { Position = AxisPosition.Bottom, StringFormat = "dd/MM/yyyy" });
			model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Activity Count" });

			model.Series.Add(series);
			PlotModel = model;
		}



	}
}
