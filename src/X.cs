namespace Xes;

public class X
{
    public static class StringIsNullOrWhitespace
    {
        /// <summary>
        /// Throw ArgumentException if strings are null or whitespace
        /// </summary>
        /// <param name="args">arg name and value</param>
        /// <exception cref="ArgumentException"></exception>
        public static void ThrowArgumentException(params (string, string)[] args)
        {
            var errMsg = args.Where(x => string.IsNullOrWhiteSpace(x.Item2))
                .Select(x => $"{x.Item1} is required.")
                .ToList();
            throw new ArgumentException(string.Join(" ", errMsg));
        }
    }
}