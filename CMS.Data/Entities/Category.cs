using System.Collections.Generic;

namespace CMS.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }
    }
}