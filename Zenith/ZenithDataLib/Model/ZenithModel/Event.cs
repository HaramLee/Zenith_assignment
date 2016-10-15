using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZenithWebSite.Models;

namespace ZenithDataLib.Model.ZenithModel
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public TimeSpan FromDate { get; set; }

        public TimeSpan ToDate { get; set; }

        public string EnteredUsername { get; set; }

        [ForeignKey("Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        public int IsActive { get; set; }
    }
}

