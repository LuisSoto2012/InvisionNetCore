using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.ConfigurationProviders
{
    public class InvisionConfigurationBuilder :  ConfigurationBuilder
    {
        /// <summary>
        /// Metodo Copy Paste de Build() para que retorne InvisionConfigurationRoot
        /// Builds an <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> with keys and values from the set of providers registered in
        /// <see cref="P:Microsoft.Extensions.Configuration.ConfigurationBuilder.Sources" />.
        /// </summary>
        /// <returns>An <see cref="T:Microsoft.Extensions.Configuration.IConfigurationRoot" /> with keys and values from the registered providers.</returns>
        public virtual InvisionConfigurationRoot BuildInvision(string componentName = null)
        {
            List<IConfigurationProvider> configurationProviderList = new List<IConfigurationProvider>();
            Log.Information("** configurationProviders (se busca en orden inverso)");
            foreach (IConfigurationSource source in (IEnumerable<IConfigurationSource>)this.Sources)
            {
                IConfigurationProvider configurationProvider = source.Build((IConfigurationBuilder)this);
                Log.Information("**   configurationProvider:" + configurationProvider);
                configurationProviderList.Add(configurationProvider);
            }
            return new InvisionConfigurationRoot((IList<IConfigurationProvider>)configurationProviderList);
        }
    }
}
