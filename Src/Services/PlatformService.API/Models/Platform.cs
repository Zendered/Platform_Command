﻿using System.ComponentModel.DataAnnotations;

namespace PlatformService.API.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Cost { get; set; }
    }
}
