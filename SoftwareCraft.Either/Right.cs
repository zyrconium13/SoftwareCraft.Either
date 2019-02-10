using System;
using System.Linq;

namespace SoftwareCraft.Either
{
	public class Right<TLeft, TRight> : Either<TLeft, TRight>
	{
		public Right(TRight right) : base(right) { }

		public override void Match(Action<TLeft> onLeft, Action<TRight> onRight)
		{
			onRight(Right);
		}

		public override TOut Match<TOut>(Func<TLeft, TOut> onLeft, Func<TRight, TOut> onRight) => onRight(Right);

		public override Either<ULeft, URight> Select<ULeft, URight>(
			Func<TLeft, ULeft> mapLeft,
			Func<TRight, URight> mapRight) =>
			Either.Right<ULeft, URight>(mapRight(Right));

		public override Either<ULeft, URight> SelectMany<ULeft, URight>(
			Func<TLeft, Either<ULeft, URight>> mapLeft,
			Func<TRight, Either<ULeft, URight>> mapRight) =>
			mapRight(Right);
	}
}