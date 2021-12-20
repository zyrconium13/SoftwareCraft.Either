using System;
using System.Linq;

namespace SoftwareCraft.Functional;

using System.Collections.Generic;
using System.Threading.Tasks;

public class Right<TLeft, TRight> : Either<TLeft, TRight>
{
	public Right(TRight right) : base(right)
	{
	}

	public override void Match(Action<TLeft> onLeft, Action<TRight> onRight)
	{
		if (onLeft == null) throw new ArgumentNullException(nameof(onLeft));
		if (onRight == null) throw new ArgumentNullException(nameof(onRight));

		onRight(Right);
	}

	public override async Task MatchAsync(Func<TLeft, Task> onLeft, Func<TRight, Task> onRight)
	{
		if (onLeft == null) throw new ArgumentNullException(nameof(onLeft));
		if (onRight == null) throw new ArgumentNullException(nameof(onRight));

		await onRight(Right);
	}

	public override TOut Match<TOut>(Func<TLeft, TOut> onLeft, Func<TRight, TOut> onRight)
	{
		if (onLeft == null) throw new ArgumentNullException(nameof(onLeft));
		if (onRight == null) throw new ArgumentNullException(nameof(onRight));

		return onRight(Right);
	}

	public override async Task<TOut> MatchAsync<TOut>(Func<TLeft, Task<TOut>> onLeft, Func<TRight, Task<TOut>> onRight)
	{
		if (onLeft == null) throw new ArgumentNullException(nameof(onLeft));
		if (onRight == null) throw new ArgumentNullException(nameof(onRight));

		return await onRight(Right);
	}

	public override Either<ULeft, URight> Select<ULeft, URight>(
		Func<TLeft, ULeft>   mapLeft,
		Func<TRight, URight> mapRight)
	{
		if (mapLeft == null) throw new ArgumentNullException(nameof(mapLeft));
		if (mapRight == null) throw new ArgumentNullException(nameof(mapRight));

		return Either.Right<ULeft, URight>(mapRight(Right));
	}

	public override Either<ULeft, URight> SelectMany<ULeft, URight>(
		Func<TLeft, Either<ULeft, URight>>  mapLeft,
		Func<TRight, Either<ULeft, URight>> mapRight)
	{
		if (mapLeft == null) throw new ArgumentNullException(nameof(mapLeft));
		if (mapRight == null) throw new ArgumentNullException(nameof(mapRight));

		return mapRight(Right);
	}
}