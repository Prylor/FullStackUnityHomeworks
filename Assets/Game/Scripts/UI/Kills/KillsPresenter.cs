using Atomic.Elements;
using Atomic.Presenters;
using Gameplay.Context.Game;
using SampleGame;
using TMPro;
using UnityEngine;

namespace UI.Kills
{
    public class KillsPresenter: Presenter
    {
        [SerializeField]
        private TMP_Text killsText;


        private IReactiveValue<int> _kills;

        protected override void OnInit()
        {
            var gameContext = GameContext.Instance;
            _kills = gameContext.GetKills();
        }

        protected override void OnShow()
        {
            _kills.Subscribe(OnKillsChanged);
            OnKillsChanged(_kills.Value);
        }

        protected override void OnHide()
        {
            _kills.Unsubscribe(OnKillsChanged);
        }

        private void OnKillsChanged(int kills)
        {
            killsText.text = kills.ToString();
        }
    }
}