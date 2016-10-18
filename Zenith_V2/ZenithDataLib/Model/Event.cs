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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime FromDate { get; set; }

        [Display(Name = "To")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime ToDate { get; set; }

        [ForeignKey("Activity")]
        [Display(Name = "Activity")]
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        [Display(Name = "Creator")]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser ApplicationUser { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date Created")]
        [ScaffoldColumn(false)]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Active")]
        public int IsActive { get; set; }
    }
}

