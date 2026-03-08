using GameAssembly.StatsSystem.Data;
using TMPro;
using UnityEngine;

namespace GameAssembly.StatsSystem.View
{
    public class StatView : MonoBehaviour
    {
        [SerializeField] private StatType statType;
        [SerializeField] private TMP_Text statValueLabel;
        
        private Stats _stats;

        public void Construct(Stats stats) => _stats = stats;

        private void Start() => Bind();

        private void OnDestroy() => Expose();

        private void OnStatsUpdated(StatType type)
        {
            if(statType != type)
                return;
            
            statValueLabel.text = _stats.GetValue(statType).ToString();
        }
        
        private void Bind() => _stats.OnStatsUpdated += OnStatsUpdated;

        private void Expose() => _stats.OnStatsUpdated -= OnStatsUpdated;
    }
}