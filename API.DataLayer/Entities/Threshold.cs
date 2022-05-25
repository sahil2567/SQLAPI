using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration.Entities
{
	public class Threshold
	{
		public int Id { get; set; }
		public string SK { get; set; }
		public string High { get; set; }
		public string Low { get; set; }
		public string TElements { get; set; }


	}
}
