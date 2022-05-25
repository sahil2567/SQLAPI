using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration.Entities
{
	public class Device
	{
		public int Id { get; set; }
		public string SK { get; set; }
		public string GSI1PK { get; set; }
		public string DeviceId { get; set; }
		public string DeviceType { get; set; }


	}
}
