using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.ConfigurationProviders.EFProvider
{
    public class EFConfigProvider : ConfigurationProvider
    {
        //public EFConfigProvider(Action<DbContextOptionsBuilder> optionsAction)
        //{
        //    OptionsAction = optionsAction;
        //}

        //Action<DbContextOptionsBuilder> OptionsAction { get; }

        //// Load config data from EF DB.
        //public override void Load()
        //{
        //    var builder = new DbContextOptionsBuilder<ConfigurationContext>();
        //    OptionsAction(builder);

        //    using (var dbContext = new ConfigurationContext(builder.Options))
        //    {
        //        dbContext.Database.EnsureCreated();
        //        Data = !dbContext.Parameters.Any()
        //            ? CreateAndSaveDefaultValues(dbContext)
        //            : dbContext.Parameters.ToDictionary(c => c.Code, c => c.Value);
        //    }

        //    //string coreBackendUrl = Configuration["CORE_URL"]+ "api/Parameter/GetListParameters?pageSize=1000";

        //}

        //private static IDictionary<string, string> CreateAndSaveDefaultValues(
        //    ConfigurationContext dbContext)
        //{
        //    var configValues = new Dictionary<string, string>
        //        {
        //            { "key1", "Loaded from EFConfigProvider.cs" }
        //        };

        //    // No es necesario persistir la data cargada en este metodo

        //    //dbContext.Parameters.AddRange(configValues
        //    //    .Select(kvp => new ConfigurationValue { Id = kvp.Key, Value = kvp.Value })
        //    //    .ToArray());
        //    //dbContext.SaveChanges();

        //    return configValues;
        //}
    }
}
