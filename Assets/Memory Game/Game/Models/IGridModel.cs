using System.Collections.ObjectModel;

namespace MemoryGame.Game.Models {
	public interface IGridModel
	{
		ReadOnlyCollection<CardModel> Cards { get; }
	}
}