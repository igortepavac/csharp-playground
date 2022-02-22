using EventXyz.NavigationControllers;
using EventXyz.Models;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public class ArtistsDetailsPresenter : BaseEntityDetailsPresenter<Artist>, IEntityDetailsPresenter {
        
        private static readonly List<HeaderItem> headers = new List<HeaderItem> {
                new HeaderItem("ID", 100),
                new HeaderItem("Naziv", 300),
                new HeaderItem("Žanr", 200)
        };

        private static readonly RowItemMapper mapper = (item) => new RowItem(item.Id, new List<string>() { item.Name, item.Genre });

        private readonly IEntityDetailsView view;
        private readonly ArtistsRepository repository;
        private readonly ArtistDetailsNavigationController navigationController;

        public ArtistsDetailsPresenter(IEntityDetailsView view, ArtistsRepository repository, ArtistDetailsNavigationController navigationController) : base(view, repository, mapper) {
            this.view = view;
            this.repository = repository;
            this.navigationController = navigationController;
        }

        protected override List<HeaderItem> GetHeaders() {
            return headers;
        }

        public override void OnAddNewItem() {
            navigationController.NavigateToArtistEditor();
        }

        public override async void OnEditItem(int itemId) {
            navigationController.NavigateToArtistEditor((await repository.GetItemAsync(itemId)));
        }
    }
}
