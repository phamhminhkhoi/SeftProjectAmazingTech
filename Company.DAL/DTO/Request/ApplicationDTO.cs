using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.DTO.Request
{
    public class ApplicationDTO
    {
        public int ApplicationId { get; set; }

        public string ApplicationType { get; set; } = null!;

        public string ApplicationName { get; set; } = null!;

        public string? ApplicationDescription { get; set; }
        public string ApplicationImageUrl { get; set; }
        public string UserId { get; set; }
    }
}
