using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[Key] ifadesini kullanabilmek için bu kütüphaneyi ekliyoruz
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
   public class Comment
    {
        [Key]

        public int CommentID { get; set; }
        public string CommentUser { get; set; }
        public DateTime CommentDate { get; set; }
        public string CommentContent { get; set; }
        public bool CommentState { get; set; }

        public int DestinationID { get; set; }
        public Destination Destination { get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
