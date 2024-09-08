using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Reflection.Metadata;
using TechnicalQuestionAPI.Models;
using TechnicalQuestionAPI.Models.EntityConfiguration;

namespace TechnicalQuestionAPI.Context
{
    public class TechnicalQuestionDbContext : DbContext
    {
        public TechnicalQuestionDbContext(DbContextOptions<TechnicalQuestionDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //adding constraint on models 
            modelBuilder.Entity<Question>().Property(x => x.Link).
                HasColumnName("QuestionOutSourceLink").HasDefaultValue("NoLink")
                .HasMaxLength(120).IsRequired(false);
            modelBuilder.Entity<Question>().Property(x=>x.Description).IsRequired(false);
            modelBuilder.Entity<Assignment>().Property(x => x.Mark).HasAnnotation("CheckConstraint", "CHECK (Mark >= 0 and MARK <=100)");
            modelBuilder.Entity<UserSkill>().HasKey(x=> x.UserSkillId);
            modelBuilder.Entity<UserSkill>().Property(x=>x.UserSkillId).UseIdentityColumn();
            modelBuilder.Entity<EducationHistory>().HasKey(x => x.EducationHistoryId);
            modelBuilder.Entity<EducationHistory>().Property(x => x.EducationHistoryId).UseIdentityColumn();
            modelBuilder.Entity<JobTitleQuestion>().HasKey(x => x.JobTitleQuestionId);
            modelBuilder.Entity<JobTitleQuestion>().Property(x => x.JobTitleQuestionId).UseIdentityColumn();
            modelBuilder.Entity<UserAssignment>().HasKey(x => x.UserAssignmentId);
            modelBuilder.Entity<UserAssignment>().Property(x => x.UserAssignmentId).UseIdentityColumn();
            modelBuilder.Entity<EducationHistory>().HasKey(x => x.EducationHistoryId);
            modelBuilder.Entity<EducationHistory>().Property(x => x.EducationHistoryId).UseIdentityColumn();
            //adding constraint on single class to handle configuration 
            modelBuilder.ApplyConfiguration(new ExperienceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ExamEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SkillsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AssignmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EducationHistoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrganizationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionBenefitsEntityConfiguration());

        }
        //**
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<JobTitle> JobTitles { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<EducationHistory> EducationsHistories { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<UserAssignment> UserAssignment { get; set; }
        public virtual DbSet<SubscriptionBenefits> SubscriptionBenefits {  get; set; }
    }
}
