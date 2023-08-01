using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace NerdDinner.Dtos
{
    public class DinnerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public string Description { get; set; }

        public string Address { get; set; }

        public int? CountryId { get; set; }

        [Phone]
        [StringLength(16)]
        public string Phone { get; set; }

        public string Guests { get; set; }
    }
}