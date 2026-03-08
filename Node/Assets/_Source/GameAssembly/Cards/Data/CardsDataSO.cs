using System.Collections.Generic;
using GameAssembly.StatsSystem.Data;
using UnityEngine;

namespace GameAssembly.Cards.Data
{
    [CreateAssetMenu(fileName = "new CardDataSO", menuName = "SO/New Card Data")]
    public class CardsDataSO : ScriptableObject
    {
        [field: SerializeField] public string CardName { get; private set; }
        [field: SerializeField] public string CardDescription { get; private set; }
        [field: SerializeField] public List<CardStatUnit> StatsChanges { get; private set; }
    }

    [System.Serializable]
    public class CardStatUnit
    {
        public StatType statType;
        public int value;
    }
}