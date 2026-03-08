using GameAssembly.Cards.Data;
using XNode;

namespace GameAssembly.Graphs
{
	[CreateNodeMenu("Cards")]
	public class BaseCard : Node
	{
		[Input] public BaseCard card;
		[Input] public CardsDataSO cardData;
		
		[Output] public BaseCard yes;
		[Output] public BaseCard no;

		public override object GetValue(NodePort port)
		{
			return port.fieldName switch
			{
				nameof(cardData) => GetInputValue<BaseCard>(nameof(cardData)),
				_ => null
			};
		}
	}
}