using System;
using System.Linq;

namespace SoftwareCraft.Either
{
	public class Left<TLeft, TRight> : Either<TLeft, TRight>
	{
		public Left(TLeft left) : base(left) { }

		public override void Match(Action<TLeft> onLeft, Action<TRight> onRight)
		{
			onLeft(Left);
		}

		public override TOut Match<TOut>(Func<TLeft, TOut> onLeft, Func<TRight, TOut> onRight) => onLeft(Left);

		public override Either<ULeft, URight> Select<ULeft, URight>(
			Func<TLeft, ULeft> mapLeft,
			Func<TRight, URight> mapRight) =>
			Either.Left<ULeft, URight>(mapLeft(Left));

		public override Either<ULeft, URight> SelectMany<ULeft, URight>(
			Func<TLeft, Either<ULeft, URight>> mapLeft,
			Func<TRight, Either<ULeft, URight>> mapRight) =>
			mapLeft(Left);
	}
}