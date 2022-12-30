using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace WebApiApps.EFConfigurationProvider
{
    public class EFConfigurationSource : IConfigurationSource
    {
        private readonly Action<DbContextOptionsBuilder> _optionsAction;

        public EFConfigurationSource(Action<DbContextOptionsBuilder> optionsAction) =>
            _optionsAction = optionsAction;

        public IConfigurationProvider Build(IConfigurationBuilder builder) =>
            new EFConfigurationProvider(_optionsAction);
    }
}
