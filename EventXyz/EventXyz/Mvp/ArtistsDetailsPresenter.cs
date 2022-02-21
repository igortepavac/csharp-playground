using EventXyz.Controllers;
using EventXyz.Models;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public class ArtistsDetailsPresenter : IEntityDetailsPresenter {

        private readonly IEntityDetailsView view;
        private readonly ArtistsRepository repository;
        private readonly ArtistDetailsNavigationController navigationController;

        public ArtistsDetailsPresenter(IEntityDetailsView view, ArtistsRepository repository, ArtistDetailsNavigationController navigationController) {
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
                new HeaderItem("Naziv", 300),
                new HeaderItem("Žanr", 200)
            };
            view.ShowHeaders(headers);
        }

        private void ShowItems() {
            var rows = repository.GetItems()
                .Select(item => new RowItem(item.Id, new List<string>() { item.Name, item.Genre }))
                .ToList();
            view.ShowRows(rows);
        }

        public void OnAddNewItem() {
            navigationController.NavigateToArtistEditor();
        }

        public void OnDeleteItem(int itemId) {
            repository.DeleteItem(itemId);
        }

        public void OnEditItem(int itemId) {
            navigationController.NavigateToArtistEditor(repository.GetItem(itemId));
        }
    }
}
