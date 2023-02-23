using System;
using Restaurant.Domain.Common;
using Restaurant.Domain.Events;

namespace Restaurant.Domain.Entites
{
	public class TestEntity : BaseAuditableEntity
	{
		public int? SeatsCount {get;set;}
        private bool _reserved;
		public bool Reserved
		{
			get => _reserved;
			set
			{
                if (value == true && _reserved == false)
                {
                    AddDomainEvent(new TestEntityReservedEvent(this));
                }

                _reserved = value;
            }
		}
	}
}

