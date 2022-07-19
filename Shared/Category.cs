using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorMiamiPizza.Shared
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public bool isVisible { get; set; } = true;
        public bool isDeleted { get; set; } = false;
        [NotMapped]
        public bool isEditing { get; set; } = false;
        [NotMapped]
        public bool isNew { get; set; } = false;
    }
}
