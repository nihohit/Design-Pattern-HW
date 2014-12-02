using System;
using FacebookApplication.Interfaces;

namespace FacebookApplication
{
    public class FetchEventArgs : EventArgs
    {
        public eFetchOption FetchOption { get; private set; }

        public int CollectionLimit { get; private set; }

        public FetchEventArgs(eFetchOption i_FetchOption, int i_CollectionLimit)
        {
            this.FetchOption = i_FetchOption;
            this.CollectionLimit = i_CollectionLimit;
        }
    }
}