﻿using Application.Requests.Enums;

namespace Application.Requests
{
    public class UserRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public UserType Type { get; set; }
    }
}
