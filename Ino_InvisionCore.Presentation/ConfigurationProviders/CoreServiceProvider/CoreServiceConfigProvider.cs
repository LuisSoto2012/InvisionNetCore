using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.ConfigurationProviders.CoreServiceProvider
{
    public class CoreServiceConfigProvider : ConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CoreServiceConfigProvider"/> class.
        /// </summary>
        /// <param name="coreBackendUrl">The core backend URL.</param>
        /// <param name="moduleName"></param>
        /// <param name="parameterPwdMode"></param>
        public CoreServiceConfigProvider(string coreBackendUrl, string moduleName = null, string parameterPwdMode = null)
        {
            CoreBackendUrl = coreBackendUrl;
            ModuleName = moduleName;
            ParameterPwdMode = parameterPwdMode;
        }

        private string CoreBackendUrl { get; }
        private string ModuleName { get; }
        private string ParameterPwdMode { get; set; }


        private bool IsHttps(string url)
        {
            url = url ?? string.Empty;
            return url.StartsWith("https");
        }

        /// <summary>
        /// Loads (or reloads) the data for this provider.
        /// </summary>
        public override void Load()
        {
            ConcurrentDictionary<string, string> dictionary = new ConcurrentDictionary<string, string>();

            Data = dictionary;
        }

        private static IDictionary<string, string> CreateAndSaveDefaultValues()
        {
            var configValues = new Dictionary<string, string>
            {
                {"key1", "Loaded from CoreServiceConfigProvider.cs"}
            };

            return configValues;
        }
    }
}
