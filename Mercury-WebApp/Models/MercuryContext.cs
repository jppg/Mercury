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

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Maritalstatus> Maritalstatus { get; set; }
        public virtual DbSet<Salaryitem> Salaryitem { get; set; }
        public virtual DbSet<Salarypackage> Salarypackage { get; set; }
        public virtual DbSet<Simulation> Simulation { get; set; }
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

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

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

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("employee_client_fkey");

                entity.HasOne(d => d.Maritalstatus)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.MaritalstatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employee_maritalstatus_fkey");
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

                entity.Property(e => e.Defaultvalue)
                    .HasColumnName("defaultvalue")
                    .HasColumnType("numeric");

                entity.Property(e => e.Employeecostrate)
                    .HasColumnName("employeecostrate")
                    .HasColumnType("numeric");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Firmcostrate)
                    .HasColumnName("firmcostrate")
                    .HasColumnType("numeric");

                entity.Property(e => e.Istaxed).HasColumnName("istaxed");

                entity.Property(e => e.SalaryitemName)
                    .IsRequired()
                    .HasColumnName("salaryitem_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Salarypackage>(entity =>
            {
                entity.HasKey(e => new { e.SimulationId, e.SalaryitemId })
                    .HasName("salarypackage_pkey");

                entity.ToTable("salarypackage");

                entity.Property(e => e.SimulationId).HasColumnName("simulation_id");

                entity.Property(e => e.SalaryitemId).HasColumnName("salaryitem_id");

                entity.Property(e => e.Itemvalue)
                    .HasColumnName("itemvalue")
                    .HasColumnType("numeric");

                entity.HasOne(d => d.Salaryitem)
                    .WithMany(p => p.Salarypackage)
                    .HasForeignKey(d => d.SalaryitemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("salarypackage_salaryitem_fkey");

                entity.HasOne(d => d.Simulation)
                    .WithMany(p => p.Salarypackage)
                    .HasForeignKey(d => d.SimulationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("salarypackage_simulation_fkey");
            });

            modelBuilder.Entity<Simulation>(entity =>
            {
                entity.ToTable("simulation");

                entity.Property(e => e.SimulationId).HasColumnName("simulation_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Enddate)
                    .HasColumnName("enddate")
                    .HasColumnType("date");

                entity.Property(e => e.Startdate)
                    .HasColumnName("startdate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Simulation)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("simulation_employee_fkey");
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
