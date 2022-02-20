using EventXyz.Controllers;
using EventXyz.Models;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public class ArtistsDetailsPresenter : EntityDetailsPresenter {

        private readonly IEntityDetailsView view;
        private readonly ArtistsRepository repository;
        private readonly ArtistDetailsNavigationController navigationController;

        public ArtistsDetailsPresenter(IEntityDetailsView view, ArtistsRepository repository, ArtistDetailsNavigationController navigationController) {
            this.view = view;
            this.repository = repository;
            this.navigationController = navigationController;
        }

        public override void Initialize() {
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

        public override void OnAddNewItem() {
            navigationController.NavigateToArtistEditor();
        }

        public override void OnDeleteItem(int itemId) {
            throw new NotImplementedException();
        }

        public override void OnEditItem(int itemId) {
            navigationController.NavigateToArtistEditor(new Artist(1, "Alica", "Genre"));
        }
    }
}
