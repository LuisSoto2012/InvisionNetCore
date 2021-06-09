using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.ConfigurationProviders
{
    public abstract class InvisionConfigurationOfuscator
    {
        public abstract string Encode(string str);

        public class DbConnectionPwdOfuscator : InvisionConfigurationOfuscator
        {
            //Server=10.51.12.113;Database=N4BLC; User Id=usr_custom_interfazFE; password=pwd_custom_1nterfazF3;Connect Timeout=3000;
            public override string Encode(string str)
            {
                try
                {
                    if (string.IsNullOrEmpty(str))
                        return str;
                    int idxStart = str.IndexOf("password", StringComparison.CurrentCultureIgnoreCase);
                    if (idxStart < 0) return str;
                    idxStart += "password".Length + 1;
                    int idxEnd = str.IndexOf(";", idxStart, StringComparison.CurrentCultureIgnoreCase);
                    if (idxEnd < 0) idxEnd = str.Length;
                    string str2 = idxEnd < 0 ? str.Substring(0, idxStart) + "*****" : str.Substring(0, idxStart) + "*****" + str.Substring(idxEnd);
                    return str2;
                }
                catch (Exception)
                {
                    return str;
                }
            }
        }
    }
}
