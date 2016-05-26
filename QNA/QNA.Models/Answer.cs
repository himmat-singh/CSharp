using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QNA.Models
{
    /// <summary>
    /// Holds the answers of the asked questions
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Answer identifier
        /// </summary>
        [Key]
        public int AnswerId { get; set; }

        /// <summary>
        /// Question Identifier
        /// </summary>
        public int QuestionId { get; set; }

        /// <summary>
        /// Answer details of the asked question
        /// </summary>
        public string AnswerDetails { get; set; }

        /// <summary>
        /// Holds the information about that how many user like this answer 
        /// </summary>
        public int LikeCount { get; set; }
    }
}
