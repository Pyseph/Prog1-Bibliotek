using JetBrains.Annotations;

namespace Library
{
	public class HelperUtils
	{
		public static T AssertIsNotNull<T>([NotNull] T? nullableReference) where T : class {
			if(nullableReference == null) {
				throw new ArgumentNullException();
			}
			return nullableReference;
		}
	}
}