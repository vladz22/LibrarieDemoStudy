﻿using LibrarieDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarieDemo.Data
{
    public class DbContextObiectConex:DbContext
    {
        public DbContextObiectConex(DbContextOptions<DbContextObiectConex> optiuni):base(optiuni)//primesc in constructor optiunile si le dau mai departe la DbContext de baza
        {
        }
        public DbSet<Categorie> Categoriile { get; set; }//crearea tabelelor din baza de date
    }
}
