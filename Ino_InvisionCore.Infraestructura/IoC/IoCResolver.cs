using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.IoC
{
    public static class IoCResolver
    {
        private static IContainer _container;

        public static void Initialize(IContainer aContainer)
        {
            _container = aContainer;
        }

        public static T Resolve<T>()
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
