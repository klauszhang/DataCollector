using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.Entities
{
    public class NewDeviceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Device Name")]
        [Required]
        [StringLength(100, ErrorMessage = "Device name must be more than 4 characters", MinimumLength = 4)]
        public string DeviceName { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}
