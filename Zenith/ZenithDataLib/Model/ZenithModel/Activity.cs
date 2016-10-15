using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Model.ZenithModel
{
    [Table("Activity")]
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        public string ActivityDec { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }


    }
}
