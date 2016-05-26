using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using QNA.Models;

namespace QNA.DataSet
{
    class QNADataContext : DbContext
    {
        

        DbSet<AppUser> Users { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }

        DbSet<QuestionOption> QuestionOptions { get; set; }


        public QNADataContext(string connectionString) : base(connectionString)
        {

        }
        

    }
}
