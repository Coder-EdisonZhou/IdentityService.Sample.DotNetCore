using System;
using System.Collections.Generic;
using System.Text;

namespace Manulife.DNC.MSAD.Common.Logging
{
    public interface ILogger
    {
        void Trace(string message, params string[] args);
        void Debug(string message, params string[] args);
        void Info(string message, params string[] args);
        void Warn(string message, params string[] args);
        void Error(string message, params string[] args);
    }
}
