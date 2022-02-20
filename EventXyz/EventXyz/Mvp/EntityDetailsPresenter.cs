using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public abstract class EntityDetailsPresenter {
        
        public abstract void Initialize();

        public abstract void OnAddNewItem();

        public abstract void OnEditItem(int itemId);

        public abstract void OnDeleteItem(int itemId);

    }
}
