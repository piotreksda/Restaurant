using System;
using Restaurant.Domain.Common;
using Restaurant.Domain.Entites;

namespace Restaurant.Domain.Events
{
	public class TableReservedEvent: BaseEvent
	{
		public TableReservedEvent(Table item)
		{
			Item = item;
		}
		public Table Item { get; }
	}
}

