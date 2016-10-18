using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Model
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Display(Name = "From")]
        public TimeSpan FromDate { get; set; }

        [Display(Name = "To")]
        public TimeSpan ToDate { get; set; }

        [ForeignKey("Activity")]
        [Display(Name = "Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        [Display(Name = "Creator")]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser ApplicationUser { get; set; }


        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        [ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Active")]
        public int IsActive { get; set; }
    }
}

