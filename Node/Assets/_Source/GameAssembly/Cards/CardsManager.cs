using System;
using GameAssembly.Graphs;
using GameAssembly.StatsSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameAssembly.Cards
{
    public class CardsManager : MonoBehaviour
    {
        [SerializeField] private CardsGraph cardsGraph;
        [SerializeField] private TMP_Text cardNameLabel;
        [SerializeField] private TMP_Text cardDescriptionLabel;
        [SerializeField] private Button acceptButton;
        [SerializeField] private Button rejectButton;
        [SerializeField] private Button backButton;

        private Stats _stats;

        public void Construct(Stats stats) => _stats = stats;

        private void Awake()
        {
            cardsGraph.Reset();
        }

        private void Start()
        {
            Bind();
            DrawCurrentCard();
        }

        private void OnDestroy() => Expose();

        private void AcceptCard()
        {
            cardsGraph.MoveNext(true);
            ApplyCurrentStats();
            DrawCurrentCard();
        }

        private void RejectCard()
        {
            cardsGraph.MoveNext(false);
            ApplyCurrentStats();
            DrawCurrentCard();
        }

        private void BackButtonClicked()
        {
            RevertCurrentStats();
            cardsGraph.MoveBack();
            DrawCurrentCard();
        }

        private void ApplyCurrentStats()
        {
            foreach (var unit in cardsGraph.GetCurrentCardData().StatsChanges)
                _stats.ChangeValue(unit.statType, unit.value);
        }

        private void RevertCurrentStats()
        {
            foreach (var unit in cardsGraph.GetCurrentCardData().StatsChanges)
                _stats.ChangeValue(unit.statType, -unit.value);
        }

        private void DrawCurrentCard()
        {
            var currentData = cardsGraph.GetCurrentCardData();

            cardNameLabel.text = currentData.CardName;
            cardDescriptionLabel.text = currentData.CardDescription;

            acceptButton.gameObject.SetActive(!cardsGraph.IsEnded());
            rejectButton.gameObject.SetActive(!cardsGraph.IsEnded());
        }

        private void Bind()
        {
            acceptButton.onClick.AddListener(AcceptCard);
            rejectButton.onClick.AddListener(RejectCard);
            backButton.onClick.AddListener(BackButtonClicked);
        }

        private void Expose()
        {
            acceptButton.onClick.RemoveAllListeners();
            rejectButton.onClick.RemoveAllListeners();
            backButton.onClick.RemoveAllListeners();
        }
    }
}