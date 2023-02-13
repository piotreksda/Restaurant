using System;
using Restaurant.Domain.Common;
using Restaurant.Domain.Events;

namespace Restaurant.Domain.Entites
{
	public class Table : BaseAuditableEntity
	{
		public Guid Id { get; set; }
		public int? SeatsCount {get;set;}
        private bool _reserved;
		public bool Reserved
		{
			get => _reserved;
			set
			{
                if (value == true && _reserved == false)
                {
                    AddDomainEvent(new TableReservedEvent(this));
                }

                _reserved = value;
            }
		}
	}
}

