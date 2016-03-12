using System;
using System.Collections.Generic;

namespace ValueUncertaintyGame
{
	public class DiceRoller
	{
		public static DiceResult Roll()
		{
			var rng = new ThreadSafeRandom();
			var num = rng.Next( 1, 7 );

			foreach ( DiceResult result in Enum.GetValues( typeof( DiceResult ) ) )
			{
				if( DiceResultHelpers.GetDiceResultValue( result ) == num )
					return result;
			}
			throw new InvalidOperationException();
		}

		public static IEnumerable<DiceResult> RollMultiple( int count )
		{
			var rolls = new List<DiceResult>();
			for ( var i = 0; i < count; i++ )
			{
				rolls.Add( Roll() );
			}
			return rolls;
		}

		// Taken from http://stackoverflow.com/questions/3049467/is-c-sharp-random-number-generator-thread-safe
		public class ThreadSafeRandom
		{
			private static readonly Random Global = new Random();
			[ThreadStatic]
			private static Random _local;

			public ThreadSafeRandom()
			{
				if (_local == null)
				{
					int seed;
					lock (Global)
					{
						seed = Global.Next();
					}
					_local = new Random( seed );
				}
			}
			public int Next( int minValue, int maxValue )
			{
				return _local.Next( minValue, maxValue );
			}
		}
	}
}