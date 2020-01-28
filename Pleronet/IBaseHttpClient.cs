using Pleronet.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pleronet
{
    public interface IBaseHttpClient
    {
        string Instance { get; }
        AppRegistration? AppRegistration { get; }
        Auth? AuthToken { get; }
    }
}
