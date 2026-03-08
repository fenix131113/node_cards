using System;
using System.Collections.Generic;
using GameAssembly.StatsSystem.Data;
using UnityEngine;

namespace GameAssembly.StatsSystem
{
    public class Stats
    {
        public const int MAX_STAT_VALUE = 100;

        private readonly Dictionary<StatType, int> _stats = new();

        public event Action<StatType> OnStatsUpdated;

        public Stats()
        {
            var names = Enum.GetNames(typeof(StatType));

            foreach (var n in names)
                _stats.Add(Enum.Parse<StatType>(n), MAX_STAT_VALUE);
        }

        public int GetValue(StatType statType) => _stats[statType];

        public void ChangeValue(StatType statType, int value)
        {
            var temp = _stats[statType];
            _stats[statType] = Mathf.Clamp(_stats[statType] + value, 0, MAX_STAT_VALUE);

            if (_stats[statType] != temp)
                OnStatsUpdated?.Invoke(statType);
        }
    }
}