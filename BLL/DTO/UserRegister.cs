using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserRegister
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public int? Role { get; set; }
    }
}
