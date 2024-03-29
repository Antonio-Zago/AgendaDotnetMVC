﻿using AgendaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaMVC.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Alerta> Alertas { get; set; }

        public DbSet<TipoEvento> TipoEventos { get; set; }
    }
}
