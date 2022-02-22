using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public interface IEntityDetailsPresenter {
        
        public void Initialize();

        public void OnAddNewItem();

        public void OnEditItem(int itemId);

        public void OnDeleteItem(int itemId);

        public virtual void OnImport() { }
        public virtual void OnExport() { }

    }
}
