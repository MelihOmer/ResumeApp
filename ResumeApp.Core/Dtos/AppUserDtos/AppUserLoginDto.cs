﻿namespace ResumeApp.Core.Dtos.AppUserDtos
{
    public class AppUserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
