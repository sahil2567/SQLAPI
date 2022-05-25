using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration.Entities
{
    public class Patient
    {
		public int Id { get; set; }
		public string SK { get; set; }
		public string ActiveStatus { get; set; }
		public string CarecoordinatorId { get; set; }
		public string CarecoordinatorName { get; set; }
		public string City { get; set; }
		public string Coach { get; set; }
		public string CoachId { get; set; }
		public string ConnectionId { get; set; }
		public string ContactNo { get; set; }
		public string CreatedDate { get; set; }
		public string diagnosisId { get; set; }
		public string diastolic { get; set; }
		public string DOB { get; set; }
		public string DoctorId { get; set; }
		public string DoctorName { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string Gender { get; set; }
		public string GSI1PK { get; set; }
		public string GSI1SK { get; set; }
		public string Height { get; set; }
		public string Lang { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string MobilePhone { get; set; }
		public string Notes { get; set; }
		public string OTP { get; set; }
		public string ProfileImage { get; set; }
		public string reading { get; set; }
		public string St { get; set; }
		public string Street { get; set; }
		public string systolic { get; set; }
		public string UserId { get; set; }
		public string UserName { get; set; }
		public string UserTimeZone { get; set; }
		public string UserType { get; set; }
		public string Weight { get; set; }
		public string WorkPhone { get; set; }
		public string Zip { get; set; }
		public string DeviceId { get; set; }
		public string DeviceStatus { get; set; }
		public string DeviceType { get; set; }

	}
}
