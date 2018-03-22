using Microsoft.EntityFrameworkCore;

namespace MSK.Core.Module.Domain
{
    public interface ICustomModelBuilder
    {
        void Build(ModelBuilder modelBuilder);
    }
}
