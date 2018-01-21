using Microsoft.EntityFrameworkCore;

namespace MSK.Application.Module.Data
{
    public interface IExtendDbContextOptionsBuilder
    {
        DbContextOptionsBuilder Extend(DbContextOptionsBuilder optionsBuilder, string connectionString, string assemblyName);
    }
}
