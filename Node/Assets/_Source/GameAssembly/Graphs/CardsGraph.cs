using System.Linq;
using GameAssembly.Cards.Data;
using UnityEngine;
using XNode;

namespace GameAssembly.Graphs
{
    [CreateAssetMenu(fileName = "New Cards Graph", menuName = "SO/New Cards Graph")]
    public class CardsGraph : NodeGraph
    {
        private BaseCard _currentNode;

        public void MoveNext(bool yes)
        {
            switch (yes)
            {
                case true when _currentNode.Outputs.ElementAt(0).Connection != null:
                    _currentNode = _currentNode.Outputs.ElementAt(0).Connection.node as BaseCard;
                    return;
                case false when _currentNode.Outputs.ElementAt(1).Connection != null:
                    _currentNode = _currentNode.Outputs.ElementAt(1).Connection.node as BaseCard;
                    return;
                default:
                    Debug.LogError("Can't move next card. Yes or No is null!");
                    break;
            }
        }

        public void MoveBack()
        {
            if (_currentNode.Inputs.ElementAt(0)?.Connection == null)
                return;

            _currentNode = _currentNode.Inputs.ElementAt(0).Connection.node as BaseCard;
        }

        public bool IsEnded() =>
            _currentNode.Outputs.ElementAt(0).Connection == null ||
            _currentNode.Outputs.ElementAt(1).Connection == null;

        public CardsDataSO GetCurrentCardData()
        {
            if (_currentNode)
                return _currentNode.cardData;

            Debug.LogError("Can't get current card data, it's null!");
            return null;
        }

        public void Reset()
        {
            _currentNode = nodes[0] as BaseCard;
        }
    }
}