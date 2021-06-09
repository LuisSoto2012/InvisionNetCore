using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.ConfigurationProviders.CoreServiceProvider
{
    public class CoreServiceConfigSource : IConfigurationSource
    {
        private readonly string _coreBackendUrl;
        private readonly string _componentName;
        private readonly string _coreParamPwdMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreServiceConfigSource"/> class.
        /// </summary>
        /// <param name="coreBackendUrl">The core backend URL.</param>
        /// <param name="componentName"></param>
        /// <param name="paramPwdMode"></param>
        public CoreServiceConfigSource(string coreBackendUrl, string componentName = null, string paramPwdMode = null)
        {
            _coreBackendUrl = coreBackendUrl;
            _componentName = componentName;
            _coreParamPwdMode = paramPwdMode;
        }

        /// <summary>
        /// Builds the <see cref="T:Microsoft.Extensions.Configuration.IConfigurationProvider" /> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.Extensions.Configuration.IConfigurationProvider" />
        /// </returns>
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new CoreServiceConfigProvider(_coreBackendUrl, _componentName, _coreParamPwdMode);
        }
    }
}
