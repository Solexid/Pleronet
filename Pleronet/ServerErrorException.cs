using Pleronet.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pleronet
{
    public class ServerErrorException : Exception
    {
        public ServerErrorException(Error error)
            :base(error.Description)
        {
        }
    }
}
