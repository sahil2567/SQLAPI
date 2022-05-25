using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration.Entities
{
	public class CareCoordinator
	{
		public int Id { get; set; }
		public string SK { get; set; }
		public string ActiveStatus { get; set; }
		public string ContactNo { get; set; }
		public string CreatedDate { get; set; }
		public string Email { get; set; }
		public string GSI1PK { get; set; }
		public string GSI1SK { get; set; }
		public string UserId { get; set; }
		public string UserName { get; set; }
		public string UserType { get; set; }


	}
}
