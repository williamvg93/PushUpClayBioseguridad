using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public partial class ApiClayBioSecurutyContext : DbContext
{
    public ApiClayBioSecurutyContext()
    {
    }

    public ApiClayBioSecurutyContext(DbContextOptions<ApiClayBioSecurutyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Addresstype> Addresstypes { get; set; }

    public virtual DbSet<Contacttype> Contacttypes { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Contractstatus> Contractstatuses { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Personcategory> Personcategories { get; set; }

    public virtual DbSet<Personcontact> Personcontacts { get; set; }

    public virtual DbSet<Persontype> Persontypes { get; set; }

    public virtual DbSet<Shiftscheduling> Shiftschedulings { get; set; }

    public virtual DbSet<Town> Towns { get; set; }

    public virtual DbSet<Workshift> Workshifts { get; set; }

    /*     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseMySql("server=localhost;user=root;password=campus2024;database=claybiosecurity", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql")); */

    /*     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            OnModelCreatingPartial(modelBuilder);
        }
     */
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*modelBuilder.Entity<Cliente>()
       .HasOne(a => a.ClienteDireccion)
       .WithOne(b => b.Clientes)
       .HasForeignKey<ClienteDireccion>(b => b.IdCliente);*/

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
