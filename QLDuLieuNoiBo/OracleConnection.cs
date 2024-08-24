using System;

namespace QLDuLieuNoiBo
{
    internal class OracleConnection
    {
        private string connectString;

        public OracleConnection(string connectString)
        {
            this.connectString = connectString;
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}