using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreKeeperWebApp.Data
{
    public class AppState
    {
        public List<Score> Scores { get; private set; }

        public event Action OnChange;

        public void ReloadGrid(List<Score> scores)
        {
            Scores = scores;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
