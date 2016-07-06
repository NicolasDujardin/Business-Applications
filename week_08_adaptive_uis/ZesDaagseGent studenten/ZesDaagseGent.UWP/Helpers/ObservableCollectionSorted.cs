using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZesDaagseGent.UWP.Helpers
{
    public class ObservableCollectionSorted<T> : ObservableCollection<T>
    {        
        private Boolean _isBusySorting = false;

        public ObservableCollectionSorted(IEnumerable<T> collection) : base(collection) { }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (_isBusySorting) return;
            base.OnCollectionChanged(e);
        }

        public void Sort()
        {
            List<T> l = this.ToList<T>();
            l.Sort();
            _isBusySorting = true;
            this.Clear();
            foreach (T item in l)
                this.Add(item);
            _isBusySorting = false;
            base.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
