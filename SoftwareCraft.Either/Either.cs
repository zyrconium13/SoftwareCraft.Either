using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public static class Either
	{
		public static Either<TLeft, TRight> Left<TLeft, TRight>(TLeft left) => new Left<TLeft, TRight>(left);

		public static Either<TLeft, TRight> Right<TLeft, TRight>(TRight right) => new Right<TLeft, TRight>(right);
	}
}