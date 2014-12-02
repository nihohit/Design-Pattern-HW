using System;
using FacebookApplication.Interfaces;

namespace FacebookApplication
{
    public class FetchEventArgs : EventArgs
    {
        public readonly eFetchOption r_FetchOption;
        public readonly int r_CollectionLimit;

        public FetchEventArgs(eFetchOption i_FetchOption, int i_CollectionLimit)
        {
            r_FetchOption = i_FetchOption;
            r_CollectionLimit = i_CollectionLimit;
        }
    }
}