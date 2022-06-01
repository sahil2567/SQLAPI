using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration.Entities
{
	public class UserTable
	{
		public int Id { get; set; }
		public string Email { get; set; }

		public string UserId { get; set; }
		public string UserName { get; set; }
		
		public string UserType { get; set; }
		
	}
}
