using UnityEngine;
using UnityEngine.UI;
using Zenject;
using MemoryGame.Game.Models;
using System.Collections.Generic;

namespace MemoryGame {
	public class CardView
	{
		private Image face;
		private CardModel model;
		private List<Sprite> sprites;

		private CardView (
			Image face,
			List<Sprite> sprites)
		{
			this.face = face;
			this.sprites = sprites;
		}

		private void Refresh ()
		{
			Sprite sprite = sprites.Find (x => x.name == model.Kind);
			face.sprite = sprite;
		}

		public void SetModel (CardModel model)
		{
			this.model = model;
			Refresh ();
		}
	}
}