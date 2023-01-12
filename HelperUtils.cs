using JetBrains.Annotations;

namespace Library
{
	public class HelperUtils
	{
		public static void AssertIsNotNull([NotNull] object? nullableReference) {
			if(nullableReference == null) {
				throw new ArgumentNullException();
			}
		}
	}
}