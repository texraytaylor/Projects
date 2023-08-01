using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner.Models;

namespace NerdDinner.ViewModels
{
    public class DinnerFormViewModel
    {
        public Dinner Dinner { get; set; }

        public IEnumerable<Country> Countries { get; set; }

        public string PageTitle
        {
            get
            {
                if (Dinner != null && Dinner.Id != 0)
                    return "Edit Dinner";

                return "New Dinner";
            }
        }
    }
}