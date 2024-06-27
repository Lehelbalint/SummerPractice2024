using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.DailyTrackR.DataType.Enums;

namespace TM.DailyTrackR.DataType
{
	public class User
	{
		public string username { get; set; }
		public RoleEnum role { get; set; }
	}
}
