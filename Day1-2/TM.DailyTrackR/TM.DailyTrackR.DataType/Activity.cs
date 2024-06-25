using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TM.DailyTrackR.DataType.Enums;

namespace TM.DailyTrackR.DataType
{
	public class Activity
	{
        public int No {  get; set; }
        public int Id { get; set; }
		public string ProjectTypeDescription { get; set; }
		public  TaskTypeEnum ActivityType_Id { get; set; }
        public string ActivityDescription { get; set; }
        public StatusEnum Status_Id { get; set; }
        public string UserName { get; set; }


    }
}
