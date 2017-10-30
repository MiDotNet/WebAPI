using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clients.Models
{
    public class SomeDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<string> MoreInfo { get; set; }
    }
}