﻿using System.Text.Json.Serialization;

namespace Clients_BE.Application.Features.Client.Requests
{
    public class UpdateClientRequestDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
