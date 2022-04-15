using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quizzer.Models;

namespace QuizInASPNETCoreAndEFCore.Models
{
    public partial class QuizDataContext : DbContext
    {
        private static DbContextOptions options;

        public QuizDataContext()
    {

    }
    public QuizDataContext(DbContextOptions<QuizDataContext> DbContextOptions)
    : base(options)
    {

    }
    public virtual DbSet<Answer> Answer { get; set; }
    public virtual DbSet<Question> Questions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder
                    
                    .UseSqlServer(configuration["ConfigurationStirngs:DefaultConnection"]);
            
            
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");
    }
    }
}