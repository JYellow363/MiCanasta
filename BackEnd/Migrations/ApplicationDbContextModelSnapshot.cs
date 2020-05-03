﻿// <auto-generated />
using System;
using MiCanasta.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MiCanasta.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TipoUnidad")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Familia", b =>
                {
                    b.Property<int>("FamiliaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AceptaSolicitudes")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<bool>("CrearGrupoFamiliar")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Dni")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("FamiliaId");

                    b.ToTable("Familias");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Historial", b =>
                {
                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.Property<int>("TiendaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime(6)");

                    b.HasKey("FamiliaId", "TiendaId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.HasIndex("TiendaId");

                    b.ToTable("Historiales");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Limite", b =>
                {
                    b.Property<int>("LimiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadPersona")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.HasKey("LimiteId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Limites");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Perfil", b =>
                {
                    b.Property<int>("PerfilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("PerfilId");

                    b.ToTable("Perfiles");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadUnit")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ProductoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.RolPerfil", b =>
                {
                    b.Property<int>("RolPerfilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.HasKey("RolPerfilId");

                    b.HasIndex("PerfilId");

                    b.ToTable("RolPerfiles");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.RolUsuario", b =>
                {
                    b.Property<string>("Dni")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("RolPerfilId")
                        .HasColumnType("int");

                    b.HasKey("Dni", "RolPerfilId");

                    b.HasIndex("RolPerfilId");

                    b.ToTable("RolUsuarios");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Solicitud", b =>
                {
                    b.Property<string>("Dni")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.HasKey("Dni", "FamiliaId");

                    b.HasIndex("FamiliaId");

                    b.ToTable("Solicitudes");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Stock", b =>
                {
                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("TiendaId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.HasKey("ProductoId", "TiendaId");

                    b.HasIndex("TiendaId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Tienda", b =>
                {
                    b.Property<int>("TiendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Horario")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Latitud")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Longitud")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("TiendaId");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Usuario", b =>
                {
                    b.Property<string>("Dni")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("ApellidoMaterno")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ApellidoPaterno")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Contrasena")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Correo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Dni");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.UsuarioFamilia", b =>
                {
                    b.Property<string>("Dni")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("FamiliaId")
                        .HasColumnType("int");

                    b.HasKey("Dni", "FamiliaId");

                    b.HasIndex("FamiliaId");

                    b.ToTable("UsuarioFamilias");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.UsuarioTienda", b =>
                {
                    b.Property<string>("Dni")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("TiendaId")
                        .HasColumnType("int");

                    b.HasKey("Dni", "TiendaId");

                    b.HasIndex("TiendaId");

                    b.ToTable("UsuarioTiendas");
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Historial", b =>
                {
                    b.HasOne("MiCanasta.MiCanasta.Model.Familia", "Familia")
                        .WithMany("Historiales")
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiCanasta.MiCanasta.Model.Producto", "Producto")
                        .WithMany("Historiales")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiCanasta.MiCanasta.Model.Tienda", "Tienda")
                        .WithMany("Historiales")
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Limite", b =>
                {
                    b.HasOne("MiCanasta.MiCanasta.Model.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Producto", b =>
                {
                    b.HasOne("MiCanasta.MiCanasta.Model.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.RolPerfil", b =>
                {
                    b.HasOne("MiCanasta.MiCanasta.Model.Perfil", "Perfil")
                        .WithMany("RolPerfiles")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.RolUsuario", b =>
                {
                    b.HasOne("MiCanasta.MiCanasta.Model.Usuario", "Usuario")
                        .WithMany("RolUsuarios")
                        .HasForeignKey("Dni")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiCanasta.MiCanasta.Model.RolPerfil", "RolPerfil")
                        .WithMany("RolUsuarios")
                        .HasForeignKey("RolPerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Solicitud", b =>
                {
                    b.HasOne("MiCanasta.MiCanasta.Model.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Dni")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiCanasta.MiCanasta.Model.Familia", "Familia")
                        .WithMany("Solicitudes")
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.Stock", b =>
                {
                    b.HasOne("MiCanasta.MiCanasta.Model.Producto", "Producto")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiCanasta.MiCanasta.Model.Tienda", "Tienda")
                        .WithMany("Stocks")
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.UsuarioFamilia", b =>
                {
                    b.HasOne("MiCanasta.MiCanasta.Model.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Dni")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiCanasta.MiCanasta.Model.Familia", "Familia")
                        .WithMany("UsuarioFamilias")
                        .HasForeignKey("FamiliaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MiCanasta.MiCanasta.Model.UsuarioTienda", b =>
                {
                    b.HasOne("MiCanasta.MiCanasta.Model.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Dni")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MiCanasta.MiCanasta.Model.Tienda", "Tienda")
                        .WithMany("UsuarioTiendas")
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
