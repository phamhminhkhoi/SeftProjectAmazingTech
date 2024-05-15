using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.DTO.Request
{
    public class UserUpdateRequestDTO
    {
        public string username {  get; set; }
        public string? FullName {  get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

    }
}
