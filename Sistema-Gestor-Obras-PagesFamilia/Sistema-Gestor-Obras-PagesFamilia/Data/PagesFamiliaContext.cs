using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Data;

public partial class PagesFamiliaContext : DbContext
{
    public PagesFamiliaContext()
    {
    }

    public PagesFamiliaContext(DbContextOptions<PagesFamiliaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignacion> Asignacions { get; set; }

    public virtual DbSet<CategoriaMov> CategoriaMovs { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstadoObra> EstadoObras { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MovimientoFin> MovimientoFins { get; set; }

    public virtual DbSet<Obra> Obras { get; set; }

    public virtual DbSet<ObraMaterial> ObraMaterials { get; set; }

    public virtual DbSet<Oficio> Oficios { get; set; }

    public virtual DbSet<RegistroHora> RegistroHoras { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=pages_familia;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.7.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Asignacion>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PRIMARY");

            entity.ToTable("asignacion");

            entity.HasIndex(e => e.CreadoPor, "creado_por");

            entity.HasIndex(e => e.IdEmpleado, "id_empleado");

            entity.HasIndex(e => e.IdObra, "id_obra");

            entity.Property(e => e.IdAsignacion).HasColumnName("id_asignacion");
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFin).HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.IdObra).HasColumnName("id_obra");
            entity.Property(e => e.Tarea)
                .HasMaxLength(150)
                .HasColumnName("tarea");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.CreadoPor)
                .HasConstraintName("asignacion_ibfk_3");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("asignacion_ibfk_1");

            entity.HasOne(d => d.IdObraNavigation).WithMany(p => p.Asignacions)
                .HasForeignKey(d => d.IdObra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("asignacion_ibfk_2");
        });

        modelBuilder.Entity<CategoriaMov>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PRIMARY");

            entity.ToTable("categoria_mov");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.HasIndex(e => e.Tipo, "tipo").IsUnique();

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(10)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PRIMARY");

            entity.ToTable("compra");

            entity.HasIndex(e => e.CreadoPor, "creado_por");

            entity.HasIndex(e => e.IdMovimiento, "id_movimiento").IsUnique();

            entity.HasIndex(e => e.IdObraMaterial, "id_obra_material");

            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.Cantidad)
                .HasPrecision(12, 2)
                .HasColumnName("cantidad");
            entity.Property(e => e.CostoUnitario)
                .HasPrecision(14, 2)
                .HasColumnName("costo_unitario");
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdMovimiento).HasColumnName("id_movimiento");
            entity.Property(e => e.IdObraMaterial).HasColumnName("id_obra_material");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.CreadoPor)
                .HasConstraintName("compra_ibfk_3");

            entity.HasOne(d => d.IdMovimientoNavigation).WithOne(p => p.Compra)
                .HasForeignKey<Compra>(d => d.IdMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compra_ibfk_2");

            entity.HasOne(d => d.IdObraMaterialNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdObraMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("compra_ibfk_1");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PRIMARY");

            entity.ToTable("empleado");

            entity.HasIndex(e => e.Documento, "documento").IsUnique();

            entity.HasIndex(e => e.IdOficio, "id_oficio");

            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Documento)
                .HasMaxLength(20)
                .HasColumnName("documento");
            entity.Property(e => e.FechaBaja).HasColumnName("fecha_baja");
            entity.Property(e => e.IdOficio).HasColumnName("id_oficio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .HasColumnName("telefono");
            entity.Property(e => e.Tipo)
                .HasMaxLength(15)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdOficioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdOficio)
                .HasConstraintName("empleado_ibfk_1");
        });

        modelBuilder.Entity<EstadoObra>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PRIMARY");

            entity.ToTable("estado_obra");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasColumnName("nombre");
            entity.Property(e => e.Orden).HasColumnName("orden");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("PRIMARY");

            entity.ToTable("material");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.IdMaterial).HasColumnName("id_material");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .HasColumnName("nombre");
            entity.Property(e => e.Unidad)
                .HasMaxLength(20)
                .HasColumnName("unidad");
        });

        modelBuilder.Entity<MovimientoFin>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento).HasName("PRIMARY");

            entity.ToTable("movimiento_fin");

            entity.HasIndex(e => e.CreadoPor, "creado_por");

            entity.HasIndex(e => e.IdCategoria, "id_categoria");

            entity.HasIndex(e => e.IdObra, "id_obra");

            entity.Property(e => e.IdMovimiento).HasColumnName("id_movimiento");
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdObra).HasColumnName("id_obra");
            entity.Property(e => e.Monto)
                .HasPrecision(14, 2)
                .HasColumnName("monto");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.MovimientoFins)
                .HasForeignKey(d => d.CreadoPor)
                .HasConstraintName("movimiento_fin_ibfk_3");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.MovimientoFins)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimiento_fin_ibfk_2");

            entity.HasOne(d => d.IdObraNavigation).WithMany(p => p.MovimientoFins)
                .HasForeignKey(d => d.IdObra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movimiento_fin_ibfk_1");
        });

        modelBuilder.Entity<Obra>(entity =>
        {
            entity.HasKey(e => e.IdObra).HasName("PRIMARY");

            entity.ToTable("obra");

            entity.HasIndex(e => e.CreadoPor, "creado_por");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.HasIndex(e => e.IdEstado, "id_estado");

            entity.Property(e => e.IdObra).HasColumnName("id_obra");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.CreadoPor).HasColumnName("creado_por");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .HasColumnName("descripcion");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaBaja).HasColumnName("fecha_baja");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.FechaFinEstimada).HasColumnName("fecha_fin_estimada");
            entity.Property(e => e.FechaInicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");

            entity.HasOne(d => d.CreadoPorNavigation).WithMany(p => p.Obras)
                .HasForeignKey(d => d.CreadoPor)
                .HasConstraintName("obra_ibfk_3");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Obras)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("obra_ibfk_1");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Obras)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("obra_ibfk_2");
        });

        modelBuilder.Entity<ObraMaterial>(entity =>
        {
            entity.HasKey(e => e.IdObraMaterial).HasName("PRIMARY");

            entity.ToTable("obra_material");

            entity.HasIndex(e => e.IdMaterial, "id_material");

            entity.HasIndex(e => new { e.IdObra, e.IdMaterial }, "id_obra").IsUnique();

            entity.Property(e => e.IdObraMaterial).HasColumnName("id_obra_material");
            entity.Property(e => e.CantRequerida)
                .HasPrecision(12, 2)
                .HasColumnName("cant_requerida");
            entity.Property(e => e.IdMaterial).HasColumnName("id_material");
            entity.Property(e => e.IdObra).HasColumnName("id_obra");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany(p => p.ObraMaterials)
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("obra_material_ibfk_2");

            entity.HasOne(d => d.IdObraNavigation).WithMany(p => p.ObraMaterials)
                .HasForeignKey(d => d.IdObra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("obra_material_ibfk_1");
        });

        modelBuilder.Entity<Oficio>(entity =>
        {
            entity.HasKey(e => e.IdOficio).HasName("PRIMARY");

            entity.ToTable("oficio");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.IdOficio).HasColumnName("id_oficio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<RegistroHora>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PRIMARY");

            entity.ToTable("registro_horas");

            entity.HasIndex(e => e.IdAsignacion, "id_asignacion");

            entity.Property(e => e.IdRegistro).HasColumnName("id_registro");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Horas)
                .HasPrecision(5, 2)
                .HasColumnName("horas");
            entity.Property(e => e.IdAsignacion).HasColumnName("id_asignacion");

            entity.HasOne(d => d.IdAsignacionNavigation).WithMany(p => p.RegistroHoras)
                .HasForeignKey(d => d.IdAsignacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("registro_horas_ibfk_1");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.ToTable("rol");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.IdEmpleado, "id_empleado").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(255)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Email)
                .HasMaxLength(120)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdEmpleado).HasColumnName("id_empleado");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.IdEmpleado)
                .HasConstraintName("usuario_ibfk_1");

            entity.HasMany(d => d.IdRols).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRol",
                    r => r.HasOne<Rol>().WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("usuario_rol_ibfk_2"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("usuario_rol_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdRol")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("usuario_rol");
                        j.HasIndex(new[] { "IdRol" }, "id_rol");
                        j.IndexerProperty<int>("IdUsuario").HasColumnName("id_usuario");
                        j.IndexerProperty<int>("IdRol").HasColumnName("id_rol");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
