using System;
using System.Collections.Generic;
using DayanaCore.Infrastructure.Domain;

namespace Event.Integration.Contacts
{
    public class CreateContactEvent : IIntegrationEvent
    {
        public CreateContactEvent()
        {
            Roles = new List<Guid>();
            PhoneNumbers = new String[] { };
            FaxNumbers = new string[] { };
            CellphoneNumbers = new string[] { };
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public int ContactType { get;  set; }
        public string Address { get;  set; }
        public Guid? CityId { get;  set; }
        public string[] PhoneNumbers { get;  set; }
        public string[] FaxNumbers { get;  set; }
        public string[] CellphoneNumbers { get;  set; }
        public string POBox { get;  set; }
        public string Website { get;  set; }
        public string Email { get;  set; }
        public string Description { get;  set; }
        public List<Guid> Roles { get;  set; }
        public int RoleBitwise { get;  set; }

        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }

    }
}