using System;
using UnityEngine;


namespace RoomUtils {

	public static class MapProps {
		public const int center = 50;
		public const int roomSize = 10;

		public static int PosToMapCoord(float gamePos) {
			return Mathf.RoundToInt(gamePos / roomSize) + center;
		}
	}

	public static class OTextension {

		private const OpeningType vertical = OpeningType.top | OpeningType.bottom;
		private const OpeningType horizontal = OpeningType.left | OpeningType.right;

		public static OpeningType Opposite(this OpeningType direction) {
			if (horizontal.HasFlag(direction)) return direction ^ horizontal;
			else if (vertical.HasFlag(direction)) return direction ^ vertical;
			else return OpeningType.none;  // error			
		}
	}   

	[Flags]
	public enum OpeningType {
		none = 0b0000,
		bottom = 0b0001,
		top = 0b0010,
		left = 0b0100,
		right = 0b1000,
		all = bottom | top | left | right,
	}

}


