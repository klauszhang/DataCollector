using DataCollector.DomainModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataCollector.Entities
{
    public class KeyValueDataViewModel
    {
        [Required]
        [StringLength(40, ErrorMessage = "The length of key must between 1 and 40 characters", MinimumLength = 1)]
        public string Key { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "The length of value cannot be shorter than 1")]
        public string Value { get; set; }

        [Required]
        public int DeviceId { get; set; }
    }
}
