using Microsoft.EntityFrameworkCore;

namespace MSK.Core.Module.Entity
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
