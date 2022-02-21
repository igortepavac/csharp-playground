using EventXyz.Models;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public abstract class BaseEntityDetailsPresenter<T> : IEntityDetailsPresenter {

        public delegate RowItem RowItemMapper(T item);

        private readonly IEntityDetailsView view;
        private readonly BaseEntityRepository<T> repository;
        private readonly RowItemMapper mapper;

        protected BaseEntityDetailsPresenter(IEntityDetailsView view, BaseEntityRepository<T> repository, RowItemMapper mapper) {
            this.view = view;
            this.repository = repository;
            this.mapper = mapper;
            repository.DataChange += () => ShowItems();
        }

        protected abstract List<HeaderItem> GetHeaders();

        public abstract void OnAddNewItem();
        public abstract void OnEditItem(int itemId);

        public void Initialize() {
            InitializeHeaders();
            ShowItems();
        }

        private void InitializeHeaders() {
            view.ShowHeaders(GetHeaders());
        }

        private void ShowItems() {
            var rows = repository.GetItems()
                .Select(item => mapper.Invoke(item))
                .ToList();
            view.ShowRows(rows);
        }

        public void OnDeleteItem(int itemId) {
            repository.DeleteItem(itemId);
        }
    }
}
