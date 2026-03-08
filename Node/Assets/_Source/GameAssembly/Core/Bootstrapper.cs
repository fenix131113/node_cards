using GameAssembly.Cards;
using GameAssembly.StatsSystem;
using GameAssembly.StatsSystem.View;
using UnityEngine;

namespace GameAssembly.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CardsManager cardsManager;
        [SerializeField] private StatView[] statViews;
        
        private readonly Stats _stats = new();
        
        private void Awake()
        {
            cardsManager.Construct(_stats);
            foreach (var statView in statViews)
                statView.Construct(_stats);
        }
    }
}
