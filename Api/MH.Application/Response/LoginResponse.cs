﻿namespace MH.Application.Response
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public List<string> Role { get; set; }
    }
}
