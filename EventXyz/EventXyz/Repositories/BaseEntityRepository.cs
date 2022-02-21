using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Repositories {

    public delegate void DataChangeObserver();

    public abstract class BaseEntityRepository<T> {

        private delegate Task AsyncAction();

        public event DataChangeObserver DataChange;

        public abstract Task<List<T>> GetItemsAsync();
        public abstract Task<T> GetItemAsync(int id);

        protected abstract Task AddItemInternalAsync(T item);
        protected abstract Task UpdateItemInternalAsync(T item);
        protected abstract Task DeleteItemInternalAsync(int id);

        public async Task AddItemAsync(T item) {
            await PerformAndNotifyAsync(() => AddItemInternalAsync(item));
        }

        public async Task UpdateItemAsync(T item) {
            await PerformAndNotifyAsync(() => UpdateItemInternalAsync(item));
        }

        public async Task DeleteItemAsync(int id) {
            await PerformAndNotifyAsync(() => DeleteItemInternalAsync(id));
        }

        private async Task PerformAndNotifyAsync(AsyncAction action) {
            await action.Invoke();
            DataChange?.Invoke();
        }
    }
}
