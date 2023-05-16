using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.Common
{
    public class BaseEntiity
    {
        [Key]
        public int Id { get; set; }
    }
}
