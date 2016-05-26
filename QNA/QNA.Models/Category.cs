using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QNA.Models
{
    /// <summary>
    /// Holds the question category information
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Category Identifier
        /// </summary>
        [Key]
        public int CategoryId { get; set; }

        /// <summary>
        /// Name of the category
        /// </summary>
        public string CategoryName { get; set; }
        
    }
}
