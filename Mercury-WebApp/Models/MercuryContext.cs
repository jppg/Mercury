using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mercury_WebApp.Models
{
    public partial class MercuryContext : DbContext
    {
        public MercuryContext()
        {
        }

        public MercuryContext(DbContextOptions<MercuryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allocation> Allocation { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Finantialcondition> Finantialcondition { get; set; }
        public virtual DbSet<Maritalstatus> Maritalstatus { get; set; }
        public virtual DbSet<Salaryitem> Salaryitem { get; set; }
        public virtual DbSet<Salarypackage> Salarypackage { get; set; }
        public virtual DbSet<Taxrate> Taxrate { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Mercury;Username=postgres;Password=postgres");
            }
        }
        */
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allocation>(entity =>
            {
                entity.ToTable("allocation");

                entity.Property(e => e.AllocationId).HasColumnName("allocation_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Dayrate)
                    .HasColumnName("dayrate")
                    .HasColumnType("numeric");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Allocation)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("allocation_client_fkey");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Allocation)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("allocation_employee_fkey");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("client_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("config");

                entity.Property(e => e.ConfigId).HasColumnName("config_id");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Keyname)
                    .IsRequired()
                    .HasColumnName("keyname")
                    .HasMaxLength(20);

                entity.Property(e => e.Keyvalue)
                    .HasColumnName("keyvalue")
                    .HasColumnType("numeric");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasColumnName("employee_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.MaritalstatusId).HasColumnName("maritalstatus_id");

                entity.Property(e => e.Nchildren).HasColumnName("nchildren");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Maritalstatus)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.MaritalstatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employee_maritalstatus_fkey");
            });

            modelBuilder.Entity<Finantialcondition>(entity =>
            {
                entity.ToTable("finantialcondition");

                entity.Property(e => e.FinantialconditionId).HasColumnName("finantialcondition_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Finantialcondition)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("finantialcondition_employee_fkey");
            });

            modelBuilder.Entity<Maritalstatus>(entity =>
            {
                entity.ToTable("maritalstatus");

                entity.Property(e => e.MaritalstatusId).HasColumnName("maritalstatus_id");

                entity.Property(e => e.MaritalstatusName)
                    .IsRequired()
                    .HasColumnName("maritalstatus_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Salaryitem>(entity =>
            {
                entity.ToTable("salaryitem");

                entity.Property(e => e.SalaryitemId).HasColumnName("salaryitem_id");

                entity.Property(e => e.Apr).HasColumnName("apr");

                entity.Property(e => e.Aug).HasColumnName("aug");

                entity.Property(e => e.Dec).HasColumnName("dec");

                entity.Property(e => e.Defaultvalue)
                    .HasColumnName("defaultvalue")
                    .HasColumnType("numeric");

                entity.Property(e => e.Employeecostrate)
                    .HasColumnName("employeecostrate")
                    .HasColumnType("numeric");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Feb).HasColumnName("feb");

                entity.Property(e => e.Firmcostrate)
                    .HasColumnName("firmcostrate")
                    .HasColumnType("numeric");

                entity.Property(e => e.Incauto).HasColumnName("incauto");

                entity.Property(e => e.Istaxed).HasColumnName("istaxed");

                entity.Property(e => e.Jan).HasColumnName("jan");

                entity.Property(e => e.Jul).HasColumnName("jul");

                entity.Property(e => e.Jun).HasColumnName("jun");

                entity.Property(e => e.Mar).HasColumnName("mar");

                entity.Property(e => e.May).HasColumnName("may");

                entity.Property(e => e.Nov).HasColumnName("nov");

                entity.Property(e => e.Oct).HasColumnName("oct");

                entity.Property(e => e.Percentvalue)
                    .HasColumnName("percentvalue")
                    .HasColumnType("numeric");

                entity.Property(e => e.SalaryitemName)
                    .IsRequired()
                    .HasColumnName("salaryitem_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Sep).HasColumnName("sep");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Salarypackage>(entity =>
            {
                entity.HasKey(e => new { e.FinantialconditionId, e.SalaryitemId })
                    .HasName("salarypackage_pkey");

                entity.ToTable("salarypackage");

                entity.Property(e => e.FinantialconditionId).HasColumnName("finantialcondition_id");

                entity.Property(e => e.SalaryitemId).HasColumnName("salaryitem_id");

                entity.Property(e => e.Apr).HasColumnName("apr");

                entity.Property(e => e.Aug).HasColumnName("aug");

                entity.Property(e => e.Dec).HasColumnName("dec");

                entity.Property(e => e.Feb).HasColumnName("feb");

                entity.Property(e => e.Itemvalue)
                    .HasColumnName("itemvalue")
                    .HasColumnType("numeric");

                entity.Property(e => e.Jan).HasColumnName("jan");

                entity.Property(e => e.Jul).HasColumnName("jul");

                entity.Property(e => e.Jun).HasColumnName("jun");

                entity.Property(e => e.Mar).HasColumnName("mar");

                entity.Property(e => e.May).HasColumnName("may");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(100);

                entity.Property(e => e.Nov).HasColumnName("nov");

                entity.Property(e => e.Oct).HasColumnName("oct");

                entity.Property(e => e.Percentvalue)
                    .HasColumnName("percentvalue")
                    .HasColumnType("numeric");

                entity.Property(e => e.Sep).HasColumnName("sep");

                entity.HasOne(d => d.Finantialcondition)
                    .WithMany(p => p.Salarypackage)
                    .HasForeignKey(d => d.FinantialconditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("salarypackage_finantialcondition_fkey");

                entity.HasOne(d => d.Salaryitem)
                    .WithMany(p => p.Salarypackage)
                    .HasForeignKey(d => d.SalaryitemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("salarypackage_salaryitem_fkey");
            });

            modelBuilder.Entity<Taxrate>(entity =>
            {
                entity.ToTable("taxrate");

                entity.Property(e => e.TaxrateId).HasColumnName("taxrate_id");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Maritalstatus).HasColumnName("maritalstatus");

                entity.Property(e => e.Nchildrenmax).HasColumnName("nchildrenmax");

                entity.Property(e => e.Nchildrenmin).HasColumnName("nchildrenmin");

                entity.Property(e => e.Salarymax)
                    .HasColumnName("salarymax")
                    .HasColumnType("numeric");

                entity.Property(e => e.Salarymin)
                    .HasColumnName("salarymin")
                    .HasColumnType("numeric");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.Property(e => e.Taxvalue)
                    .HasColumnName("taxvalue")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.MaritalstatusNavigation)
                    .WithMany(p => p.Taxrate)
                    .HasForeignKey(d => d.Maritalstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("taxrate_maritalstatus_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
