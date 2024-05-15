using Company.DAL.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.DTO.Request
{
    public class UserCreateRequestDTO 
    {
        public string username {  get; set; }
        public string password { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public Role Role { get; set; }
        public string? Address { get; set; }
        public string? FullName { get; set; }
    }
}
