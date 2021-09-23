using Microsoft.EntityFrameworkCore;
using QuizPlatform.Core.Domain.QuestionManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            //Database.EnsureDeleted(); - Please uncommit this line to re-create DB with default values
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

           

            base.OnModelCreating(modelBuilder);
        }
    }
}
