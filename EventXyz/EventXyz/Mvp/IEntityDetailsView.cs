using EventXyz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventXyz.Mvp {
    public interface IEntityDetailsView {

        public void ShowHeaders(List<HeaderItem> headers);
        
        public void ShowRows(List<RowItem> rows);
    }
}
