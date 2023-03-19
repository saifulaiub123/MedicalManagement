﻿
namespace MH.Domain.ViewModel
{
    public class ServerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? IpAddress { get; set; }
        public string? MachineName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
