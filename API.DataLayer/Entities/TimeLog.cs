using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration.Entities
{
	public class TimeLog
	{
		public int Id { get; set; }
		public int UserType { get; set; }
		public string SK { get; set; }
		public string ActiveStatus { get; set; }
		public string CreatedDate { get; set; }
		public string EndDT { get; set; }
		public string GSI1PK { get; set; }
		public string GSI1SK { get; set; }
		public string PerformedBy { get; set; }
		public string PerformedOn { get; set; }
		public string StartDT { get; set; }
		public string TaskType { get; set; }
		public string TimeAmount { get; set; }
		public string UserName { get; set; }


	}
}
