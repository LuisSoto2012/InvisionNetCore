using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Exceptions
{
    public class BusinessException : Exception
    {
        public string ErrorCode { get; set; }
        public bool IsForceCommit { get; set; }
        public bool IsLogPrinted { get; set; }
        public Exception SourceException { get; set; }

        public BusinessException(string codigo, string messageFormat, params object[] messageParams)
            : base(string.Format(messageFormat, messageParams))
        {
            ErrorCode = codigo;
            IsForceCommit = false;
        }

        public static Exception FindRootException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return FindRootException(ex.InnerException);
            }

            return ex;
        }

        public BusinessException ForceCommit()
        {
            IsForceCommit = true;
            return this;
        }

        public static bool LogPrinted(Exception ex)
        {
            BusinessException ex2 = ex as BusinessException;
            bool yaImpreso = false;
            if (ex2 != null)
            {
                yaImpreso = ex2.IsLogPrinted;
                ex2.IsLogPrinted = true;
            }
            return yaImpreso;
        }

        public BusinessException InitSourceEx(Exception exception)
        {
            SourceException = exception;
            return this;
        }
    }
}
