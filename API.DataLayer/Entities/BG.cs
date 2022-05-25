using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration.Entities
{
	public class BG
	{
		public int Id { get; set; }
		public string SK { get; set; }
		public string ActionTaken { get; set; }
		public string ActiveStatus { get; set; }
		public string Battery { get; set; }
		public string BatteryVoltage { get; set; }
		public string Before_Meal { get; set; }
		public string BloodGlucosemgdl { get; set; }
		public string BloodGlucosemmol { get; set; }
		public string CreatedDate { get; set; }
		public string Date_Received { get; set; }
		public string Date_Recorded { get; set; }
		public string Device_Model { get; set; }
		public string DeviceId { get; set; }
		public string Event_Flag { get; set; }
		public string GSI1PK { get; set; }
		public string GSI1SK { get; set; }
		public string MeasurementDateTime { get; set; }
		public string Meter_Id { get; set; }
		public string Reading { get; set; }
		public string Reading_Id { get; set; }
		public string Reading_Type { get; set; }
		public string SignalStrength { get; set; }
		public string Time_Zone_Offset { get; set; }
		public string TimeSlots { get; set; }
		public string UpdateDate { get; set; }
		public string UserName { get; set; }


	}
}
