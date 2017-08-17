using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UseIt.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public virtual User User { get; set; }
        public string title { get; set; }
        public string ourcomment { get; set; }
        public string tags { get; set; }

    }
}