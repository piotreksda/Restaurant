using System;
using Restaurant.Domain.Common;
using Restaurant.Domain.Entites;

namespace Restaurant.Domain.Events
{
	public class TestEntityReservedEvent: BaseEvent
	{
		public TestEntityReservedEvent(TestEntity item)
		{
			Item = item;
		}
		public TestEntity Item { get; }
	}
}

