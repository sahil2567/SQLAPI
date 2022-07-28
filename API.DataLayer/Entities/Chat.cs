using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_ApiSQLMigration.Entities
{
	public class Chat
	{
		public int ChatId { get; set; }
		public string SenderId { get; set; }
		public string ReceiverId { get; set; }
		public string ChatLink { get; set; }
		
	}
}
