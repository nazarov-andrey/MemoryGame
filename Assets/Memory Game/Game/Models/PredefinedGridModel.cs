using System.Collections.Generic;

namespace MemoryGame.Game.Models {
	public class PredefinedGridModel : GridModel
	{
		public PredefinedGridModel ()
			: base (
				new string[] { "orange", "banana", "grape", "kiwi", "banana",
					"tomato", "peach", "", "peach", "pineapple",
					"kiwi", "lemon", "pineapple", "chile", "tomato",
					"watermelon", "coconut", "chile", "grape", "pear",
					"lemon", "orange", "pear", "coconut", "watermelon" })
		{
		}
	}
}