using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperWebApp.Data
{
    public class AppState
    {
        public event Action OnChange;

        public void ReloadGrid(Shared.TeamScoreDataGrid dataGrid)
        {
            dataGrid.Reload();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
