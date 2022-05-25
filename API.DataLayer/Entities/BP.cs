using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration.Entities
{
	public class BP
	{
		public int Id { get; set; }
		public string SK { get; set; }
		public string ActionTaken { get; set; }
		public string BatteryVoltage { get; set; }
		public string CreatedDate { get; set; }
		public string Date_Received { get; set; }
		public string Date_Recorded { get; set; }
		public string DeviceId { get; set; }
		public string Diastolic { get; set; }
		public string GSI1PK { get; set; }
		public string GSI1SK { get; set; }
		public string IMEI { get; set; }
		public string Irregular { get; set; }
		public string MeasurementDateTime { get; set; }
		public string MeasurementTimestamp { get; set; }
		public string Pulse { get; set; }
		public string SignalStrength { get; set; }
		public string Systolic { get; set; }
		public string TimeSlots { get; set; }
		public string Unit { get; set; }
		public string UserName { get; set; }
		
	}
}
