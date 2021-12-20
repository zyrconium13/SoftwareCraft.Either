using System;
using System.Linq;

namespace SoftwareCraft.Functional;

using System.Collections.Generic;
using System.Threading.Tasks;

public class Left<TLeft, TRight> : Either<TLeft, TRight>
{
	public Left(TLeft left) : base(left)
	{
	}

	public override void Match(Action<TLeft> onLeft, Action<TRight> onRight)
	{
		if (onLeft == null) throw new ArgumentNullException(nameof(onLeft));
		if (onRight == null) throw new ArgumentNullException(nameof(onRight));

		onLeft(Left);
	}

	public override async Task MatchAsync(Func<TLeft, Task> onLeft, Func<TRight, Task> onRight)
	{
		if (onLeft == null) throw new ArgumentNullException(nameof(onLeft));
		if (onRight == null) throw new ArgumentNullException(nameof(onRight));

		await onLeft(Left);
	}

	public override TOut Match<TOut>(Func<TLeft, TOut> onLeft, Func<TRight, TOut> onRight)
	{
		if (onLeft == null) throw new ArgumentNullException(nameof(onLeft));
		if (onRight == null) throw new ArgumentNullException(nameof(onRight));

		return onLeft(Left);
	}

	public override async Task<TOut> MatchAsync<TOut>(Func<TLeft, Task<TOut>> onLeft, Func<TRight, Task<TOut>> onRight)
	{
		if (onLeft == null) throw new ArgumentNullException(nameof(onLeft));
		if (onRight == null) throw new ArgumentNullException(nameof(onRight));

		return await onLeft(Left);
	}

	public override Either<ULeft, URight> Select<ULeft, URight>(
		Func<TLeft, ULeft>   mapLeft,
		Func<TRight, URight> mapRight)
	{
		if (mapLeft == null) throw new ArgumentNullException(nameof(mapLeft));
		if (mapRight == null) throw new ArgumentNullException(nameof(mapRight));

		return Either.Left<ULeft, URight>(mapLeft(Left));
	}

	public override Either<ULeft, URight> SelectMany<ULeft, URight>(
		Func<TLeft, Either<ULeft, URight>>  mapLeft,
		Func<TRight, Either<ULeft, URight>> mapRight)
	{
		if (mapLeft == null) throw new ArgumentNullException(nameof(mapLeft));
		if (mapRight == null) throw new ArgumentNullException(nameof(mapRight));

		return mapLeft(Left);
	}
}