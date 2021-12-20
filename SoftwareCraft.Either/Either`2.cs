using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	using System.Threading.Tasks;

	public abstract class Either<TLeft, TRight>
	{
		protected readonly TLeft Left;

		protected readonly TRight Right;

		protected Either(TLeft left) => Left = left;

		protected Either(TRight right) => Right = right;

		public abstract void Match(Action<TLeft> onLeft, Action<TRight> onRight);

		public abstract Task MatchAsync(Func<TLeft, Task> onLeft, Func<TRight, Task> onRight);

		public abstract TOut Match<TOut>(Func<TLeft, TOut> onLeft, Func<TRight, TOut> onRight);

		public abstract Task<TOut> MatchAsync<TOut>(Func<TLeft, Task<TOut>> onLeft, Func<TRight, Task<TOut>> onRight);

		public abstract Either<ULeft, URight> Select<ULeft, URight>(
			Func<TLeft, ULeft> mapLeft,
			Func<TRight, URight> mapRight);

		public abstract Either<ULeft, URight> SelectMany<ULeft, URight>(
			Func<TLeft, Either<ULeft, URight>> mapLeft,
			Func<TRight, Either<ULeft, URight>> mapRight);
	}
}