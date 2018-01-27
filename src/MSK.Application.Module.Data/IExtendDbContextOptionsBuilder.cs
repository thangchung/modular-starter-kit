using Microsoft.EntityFrameworkCore;

namespace MSK.Application.Module.Data
{
    public interface IExtendDbContextOptionsBuilder
    {
        DbContextOptionsBuilder Extend(
            DbContextOptionsBuilder optionsBuilder,
            IDatabaseConnectionStringFactory connectionStringFactory, 
            string assemblyName);
    }
}
