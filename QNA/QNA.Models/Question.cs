using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QNA.Models
{
    /// <summary>
    /// Possible values of the type of the asked questions
    /// </summary>
    public enum QuestionType
    {
        MultipleChoiceWithSingleAnswer=0,
        MultipleChoiceWithMultipleAnswer=1,
        DescriptiveAnswer=2
    }

    /// <summary>
    /// Holds the Question information
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Question identifier
        /// </summary>
        [Key]
        public int QuestionId { get; set; }

        /// <summary>
        /// Holds the asked question details
        /// </summary>
        public string QuestionDetail { get; set; }
        
        /// <summary>
        /// Holds the information about that how many users visited to this question
        /// </summary>
        public int VisitCount { get; set; }

        /// <summary>
        /// Holds the type information of the asked question
        /// </summary>
        public QuestionType QType { get; set; }

        /// <summary>
        /// Holds the information about that how many answers options can be display 
        /// </summary>
        public int MultiChoiceAnswerDisplayLimit { get; set; }

        /// <summary>
        /// Holds the option details of the question
        /// </summary>
        public virtual ICollection<QuestionOption> QOptions { get; set; }

    }

    /// <summary>
    /// Class to hold information related to the options of the question
    /// </summary>
    public class QuestionOption
    {
        /// <summary>
        /// Option Identifier
        /// </summary>
        [Key]
        public int OptionId { get; set; }

        /// <summary>
        /// Question identifier
        /// </summary>        
        public int QuestionId { get; set; }

        /// <summary>
        /// Holds the details of an option
        /// </summary>
        public string OptionDetail { get; set; }        

    }
}
