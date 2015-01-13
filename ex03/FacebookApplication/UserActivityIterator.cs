using System;
using System.Collections.Generic;

namespace FacebookApplication
{
    using FacebookWrapper.ObjectModel;

    public class UserActivityIterator : IEnumerable<PostedItem>
    {
        private readonly IEnumerator<PostedItem> r_InternalIterator;

        public UserActivityIterator(IEnumerable<IEnumerable<PostedItem>> i_AllActivityStreams)
        {
            this.r_InternalIterator = new UserActivityInternalIterator(i_AllActivityStreams);
        }

        public IEnumerator<PostedItem> GetEnumerator()
        {
            return this.r_InternalIterator;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.r_InternalIterator;
        }

        private class UserActivityInternalIterator : IEnumerator<PostedItem>
        {
            private readonly IEnumerator<IEnumerable<PostedItem>> r_AllActivityStreams;

            private IEnumerator<PostedItem> m_CurrentStream;

            public UserActivityInternalIterator(IEnumerable<IEnumerable<PostedItem>> i_AllActivityStreams)
            {
                this.r_AllActivityStreams = i_AllActivityStreams.GetEnumerator();
            }

            public PostedItem Current
            {
                get
                {
                    return this.m_CurrentStream.Current;
                }
            }

            public void Dispose()
            {
                this.m_CurrentStream.Dispose();
                r_AllActivityStreams.Dispose();
            }

            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return this.m_CurrentStream.Current;
                }
            }

            public bool MoveNext()
            {
                if (r_AllActivityStreams.Current == null && !r_AllActivityStreams.MoveNext())
                {
                    return false;
                }

                do
                {
                    if (this.m_CurrentStream != null && this.m_CurrentStream.MoveNext())
                    {
                        return true;
                    }

                    this.m_CurrentStream = r_AllActivityStreams.Current.GetEnumerator();
                }
                while (r_AllActivityStreams.MoveNext());

                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
