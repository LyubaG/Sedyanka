using MvcTemplate.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcTemplate.Data.Models
{
    public class Complaint : BaseModel<int>
    {
        //private ICollection<Comment> comments;

        public Complaint()
        {
            //this.comments = new HashSet<Comment>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string IpAddress { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        //public virtual ICollection<Comment> Comments
        //{
        //    get { return this.comments; }
        //    set { this.comments = value; }
        //}
    }
}
