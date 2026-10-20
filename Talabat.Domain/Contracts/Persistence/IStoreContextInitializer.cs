using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Domain.Contracts.Persistence
{
    public interface IStoreContextInitializer
    {
        Task InitializeAsync();
        Task SeedAsync();

    }
}
