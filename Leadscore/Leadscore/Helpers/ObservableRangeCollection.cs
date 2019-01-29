// https://gist.github.com/weitzhandler/65ac9113e31d12e697cb58cd92601091

using System.Collections.Generic;
using System.Collections.Specialized;

namespace System.Collections.ObjectModel
{
    public class ObservableRangeCollection<T> : ObservableCollection<T>
    {
        public ObservableRangeCollection()
        {

        }

        public ObservableRangeCollection(IEnumerable<T> collection) : base(collection)
        {

        }

        public virtual void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (collection is ICollection<T> countable)
            {
                if (countable.Count == 0)
                {
                    return;
                }
            }
            else if (!ContainsAny(collection))
            {
                return;
            }

            foreach (var item in collection)
            {
                this.Items.Add(item);
            }

            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, collection));
        }

        static bool ContainsAny(IEnumerable<T> collection)
        {
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                return enumerator.MoveNext();
            }
        }
    }
}