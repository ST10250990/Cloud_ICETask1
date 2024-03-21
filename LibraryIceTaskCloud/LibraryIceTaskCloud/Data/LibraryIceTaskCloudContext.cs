using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryIceTaskCloud.Models;

namespace LibraryIceTaskCloud.Data
{
    public class LibraryIceTaskCloudContext : DbContext
    {
        public LibraryIceTaskCloudContext (DbContextOptions<LibraryIceTaskCloudContext> options)
            : base(options)
        {
        }

        public DbSet<LibraryIceTaskCloud.Models.Library> Library { get; set; } = default!;
    }
}
