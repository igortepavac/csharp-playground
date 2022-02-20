using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Repositories {

    public delegate void DataChangeObserver();

    public abstract class BaseEntityRepository<T> {

        public event DataChangeObserver DataChange;

        public abstract List<T> GetItems();
        public abstract T GetItem(int id);

        protected abstract void AddItemInternal(T item);
        protected abstract void UpdateItemInternal(T item);
        protected abstract void DeleteItemInternal(int id);

        public void AddItem(T item) {
            PerformAndNotify(() => AddItemInternal(item));
        }

        public void UpdateItem(T item) {
            PerformAndNotify(() => UpdateItemInternal(item));
        }

        public void DeleteItem(int id) {
            PerformAndNotify(() => DeleteItemInternal(id));
        }

        private void PerformAndNotify(Action action) {
            action.Invoke();
            DataChange.Invoke();
        }
    }
}
