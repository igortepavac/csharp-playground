using EventXyz.Controllers;
using EventXyz.Models;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public class EventsDetailsPresenter : IEntityDetailsPresenter {

        private readonly IEntityDetailsView view;
        private readonly EventsRepository repository;
        private readonly EventDetailsNavigationController navigationController;

        public EventsDetailsPresenter(IEntityDetailsView view, EventsRepository repository, EventDetailsNavigationController navigationController) {
            this.view = view;
            this.repository = repository;
            this.navigationController = navigationController;
            repository.DataChange += () => ShowItems();
        }

        public void Initialize() {
            InitializeHeaders();
            ShowItems();
        }

        private void InitializeHeaders() {
            var headers = new List<HeaderItem> {
                new HeaderItem("ID", 100),
                new HeaderItem("Opis", 300)
            };
            view.ShowHeaders(headers);
        }

        private void ShowItems() {
            var rows = repository.GetItems()
                .Select(item => new RowItem(item.Id, new List<string>() { item.Description }))
                .ToList();
            view.ShowRows(rows);
        }

        public void OnAddNewItem() {
            navigationController.NavigateToEventEditor();
        }

        public void OnDeleteItem(int itemId) {
            repository.DeleteItem(itemId);
        }

        public void OnEditItem(int itemId) {
            navigationController.NavigateToEventEditor(repository.GetItem(itemId));
        }
    }
}
