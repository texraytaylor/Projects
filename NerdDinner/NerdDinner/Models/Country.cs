using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace NerdDinner.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}