using System;

namespace ValueUncertaintyGame
{
	public class DiceResultHelpers
	{
		public static int GetDiceResultValue( DiceResult diceResult )
		{
			switch ( diceResult )
			{
				case DiceResult.One:
					return 1;
				case DiceResult.Two:
					return 2;
				case DiceResult.Three:
					return 3;
				case DiceResult.Four:
					return 4;
				case DiceResult.Five:
					return 5;
				case DiceResult.Six:
					return 6;
				default:
					throw new ArgumentOutOfRangeException( nameof( diceResult ), diceResult, null );
			}
		}
	}
}