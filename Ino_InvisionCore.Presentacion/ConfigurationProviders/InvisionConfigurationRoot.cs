using Ino_InvisionCore.Presentacion.Bases;
using Ino_InvisionCore.Presentacion.ConfigurationProviders.CoreServiceProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.ConfigurationProviders
{
    public class InvisionConfigurationRoot : ConfigurationRoot
    {
        private readonly IList<IConfigurationProvider> _configurationProviders;
        //_providers es private, por eso se almacena copia

        public InvisionConfigurationRoot(IList<IConfigurationProvider> providers) : base(providers)
        {
            this._configurationProviders = new List<IConfigurationProvider>(providers);
        }

        /// <summary>
        /// Gets or sets the value corresponding to a configuration key.
        /// </summary>
        /// <param name="key">The configuration key.</param>
        /// <returns>The configuration value.</returns>
        public new string this[string key]
        {
            get { return GetInfoInternal(key, false, null); }
            set
            {
                Log.Warning("Configuration[{0}] <==(new val){1}", key, value);
                base[key] = value;
            }
        }

        public string GetInfoLog(string key, InvisionConfigurationOfuscator ofuscator = null)
        {
            return GetInfoInternal(key, true, ofuscator);
        }

        public string GetInfoNoLog(string key)
        {
            return GetInfoInternal(key, false, null);
        }


        private string GetInfoInternal(string key, bool showLog, InvisionConfigurationOfuscator ofuscator)
        {
            foreach (IConfigurationProvider configurationProvider in _configurationProviders.Reverse())
            {
                if (configurationProvider.TryGet(key, out string str))
                {
                    bool standard = IsStandarConfigurationProvider(configurationProvider);
                    string strForLog = ofuscator == null ? str : ofuscator.Encode(str);
                    if (!standard)
                    {
                        string configName = ConfigurationProviderName(configurationProvider);
                        Log.Warning("   Configuration[{0}, {1}]:{2}", key, configName, strForLog);
                    }
                    else
                    {
                        string configName = ConfigurationProviderName(configurationProvider);
                        Log.Debug("   Configuration[{0}, {1}]:{2}", key, configName, strForLog);
                    }
                    return str;
                }
            }
            Log.Warning("   Configuration[{0}]:Not found", key);
            return (string)null;
        }

        private string ConfigurationProviderName(IConfigurationProvider configurationProvider)
        {
            if (configurationProvider is CoreServiceConfigProvider)
                return "CORE-BE";

            if (configurationProvider is JsonConfigurationProvider jsonConfigurationProvider)
                return jsonConfigurationProvider.Source.Path;
            if (configurationProvider is EnvironmentVariablesConfigurationProvider)
                return "EnvVar";

            return configurationProvider.GetType().Name;
        }

        private bool IsStandarConfigurationProvider(IConfigurationProvider configurationProvider)
        {
            if (configurationProvider is CoreServiceConfigProvider)
                return true;

            if (configurationProvider is JsonConfigurationProvider jsonConfigurationProvider &&
                jsonConfigurationProvider.Source.Path.EndsWith(StartUpConfig.K_APP_SETTINGS_JSON))
                return true;
            return false;
        }
    }
}
