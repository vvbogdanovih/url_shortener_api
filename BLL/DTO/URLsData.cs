using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class URLsData
    {
        public int? Id { get; set; }
        public string? LongUrl { get; set; }
        public string? ShortUrl { get; set; }
        public string? Creator { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
