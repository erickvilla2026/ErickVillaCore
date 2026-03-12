using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class PruebaConexionContext : DbContext
{
    public PruebaConexionContext()
    {
    }

    public PruebaConexionContext(DbContextOptions<PruebaConexionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Colonium> Colonia { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Departamentos1> Departamentos1s { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Producto1> Productos1 { get; set; }

    public virtual DbSet<ProductoDepto> ProductoDeptos { get; set; }

    public virtual DbSet<ProductoDepto1> ProductoDepto1s { get; set; }

    public virtual DbSet<Productos1> Productos1s { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<T102Beneficiario> T102Beneficiarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<DTOs> DireccionDTO { get; set; } 

    public virtual DbSet<VwUsuarioGetAll> VwUsuarioGetAlls { get; set; }

    public virtual DbSet<UsuarioGetAll> UsuarioGetAllDTO { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=PRUEBA_CONEXION; TrustServerCertificate=True; Trusted_Connection=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Colonium>(entity =>
        {
            entity.HasKey(e => e.IdColonia).HasName("PK__Colonia__A1580F6695577296");

            entity.Property(e => e.IdColonia).ValueGeneratedNever();
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Colonia)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("fk_municipio");
        });

        modelBuilder.Entity<DTOs>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<UsuarioGetAll>(entity =>
        {
            entity.HasNoKey();

        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepto).HasName("PK__Departam__7AEC424E248F6E7A");

            entity.ToTable("Departamento");

            entity.Property(e => e.DescDepto)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Departamentos1>(entity =>
        {
            entity.HasKey(e => e.IdDepto).HasName("PK__Departam__7AEC424EE5DB96E6");

            entity.ToTable("Departamentos_1");

            entity.Property(e => e.DescDepto)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__1F8E0C767C51B75F");

            entity.ToTable("Direccion");

            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExterior)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdColoniaNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdColonia)
                .HasConstraintName("fk_colonia");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_IdUsuario");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC14FDA2ADA");

            entity.ToTable("Estado");

            entity.Property(e => e.IdEstado).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__61005978911AF955");

            entity.ToTable("Municipio");

            entity.Property(e => e.IdMunicipio).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("fk_estado");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__0988921083F20C67");

            entity.ToTable("Producto");

            entity.Property(e => e.Costo).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto1>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__09889210DB93CC90");

            entity.ToTable("Productos");

            entity.Property(e => e.DescProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("money");
        });

        modelBuilder.Entity<ProductoDepto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProductoDepto");

            entity.HasOne(d => d.IdDeptoNavigation).WithMany()
                .HasForeignKey(d => d.IdDepto)
                .HasConstraintName("fk_IdDepto");

            entity.HasOne(d => d.IdProductoNavigation).WithMany()
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("fk_idProducto");
        });

        modelBuilder.Entity<ProductoDepto1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProductoDepto_1");

            entity.HasOne(d => d.IdDeptoNavigation).WithMany()
                .HasForeignKey(d => d.IdDepto)
                .HasConstraintName("fk_iddepto_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany()
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("fk_idproducto_1");
        });

        modelBuilder.Entity<Productos1>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__0988921095589AEA");

            entity.ToTable("Productos_1");

            entity.Property(e => e.DescProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdDeptoNavigation).WithMany(p => p.Productos1s)
                .HasForeignKey(d => d.IdDepto)
                .HasConstraintName("fk_IdDeptp");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584CF9F5AEAC");

            entity.ToTable("Rol");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<T102Beneficiario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("T102_BENEFICIARIOS");

            entity.Property(e => e.Edad).HasColumnName("EDAD");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Maternos)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MATERNOS");
            entity.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Paterno)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PATERNO");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__3214EC2778811120");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.Email, "UQ__USUARIO__A9D10534B561B783").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__USUARIO__C9F2845645A795BD").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__USUARIO__C9F28456C2AC6F36").IsUnique();

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Curp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fk_IdRol");
        });

        modelBuilder.Entity<VwUsuarioGetAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_UsuarioGetAll");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Curp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExterior)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
