using EventXyz.Controllers;
using EventXyz.Models;
using EventXyz.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public class EventsDetailsPresenter : BaseEntityDetailsPresenter<MusicEvent>, IEntityDetailsPresenter {

        private static readonly List<HeaderItem> headers = new List<HeaderItem> {
                new HeaderItem("ID", 100),
                new HeaderItem("Opis", 300)
        };

        private static readonly RowItemMapper mapper = (item) => new RowItem(item.Id, new List<string>() { item.Description });

        private readonly IEntityDetailsView view;
        private readonly EventsRepository repository;
        private readonly EventDetailsNavigationController navigationController;

        public EventsDetailsPresenter(IEntityDetailsView view, EventsRepository repository, EventDetailsNavigationController navigationController) : base(view, repository, mapper) {
            this.view = view;
            this.repository = repository;
            this.navigationController = navigationController;
        }
        protected override List<HeaderItem> GetHeaders() {
            return headers;
        }

        public override void OnAddNewItem() {
            navigationController.NavigateToEventEditor();
        }

        public override async void OnEditItem(int itemId) {
            navigationController.NavigateToEventEditor((await repository.GetItemAsync(itemId)));
        }
    }
}
