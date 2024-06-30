namespace TM.DailyTrackR.Common
{
  using TM.DailyTrackR.Logic;

  public sealed class LogicHelper
  {
    private static readonly Lazy<LogicHelper> Lazy = new Lazy<LogicHelper>(() => new LogicHelper(), isThreadSafe: true);
    private LogicHelper()
    {
      DailyTaskController = new DailyTaskController();
      InsertTaskController = new InsertTaskController();
      LoginController = new LoginController();
      OverviewTaskController = new OverviewTaskController();
      PlotController = new PlotController();
    }

    public static LogicHelper Instance { get { return Lazy.Value; } }

    public DailyTaskController DailyTaskController { get; }
    public InsertTaskController InsertTaskController { get; }
    public LoginController LoginController { get; }
    public OverviewTaskController OverviewTaskController { get; }
    public PlotController PlotController { get; }
  }
}
