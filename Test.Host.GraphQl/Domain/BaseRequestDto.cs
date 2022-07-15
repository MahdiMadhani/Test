using System;

namespace Domain
{
    public class BaseRequestDto
    {
        public Guid Id { get; set; }
        public string SessionKey { get; set; }
    }
}
