using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UseIt.Models
{
    public class UITask
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string alias { get; set; }
        public Boolean status { get; set; }
        [Required(ErrorMessage = "Final Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Initial Date")]
        public DateTime initialDate { get; set; }
        [Required(ErrorMessage = "Final Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Final Date")]
        public DateTime finalDate { get; set; }
        public int? UserID { get; set; }
        public virtual User User { get; set; }
        public int time { get; set; }
        public int progress { get; set; }
    }
}