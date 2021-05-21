using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherReportProject.Models
{
    public class Weather
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public int HighTemp { get; set; }
        public int LowTemp => 32 + (int)(HighTemp / 0.5556);
        public string Forcast { get; set; }
    }
}
