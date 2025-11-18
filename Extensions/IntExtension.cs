namespace Sys.Extensions
{
    public static class IntExtension
    {
        public static int IsGreaterThan(this int value, int comparisonValue)
            => value > comparisonValue
                ? value
                : throw new ArgumentException($"{value} is not greater than {comparisonValue}.");

        public static int IsGreaterThanOrEqual(this int value, int comparisonValue)
            => value >= comparisonValue
                ? value
                : throw new ArgumentException($"{value} is not greater than or equal to  {comparisonValue}.");

        public static int IsLessThan(this int value, int comparisonValue)
            => value < comparisonValue
                ? value
                : throw new ArgumentException($"{value} is not less than  {comparisonValue}.");

        public static int IsLessThanOrEqual(this int value, int comparisonValue)
            => value <= comparisonValue
                ? value
                : throw new ArgumentException($"{value} is not less than or equal to  {comparisonValue}.");

        public static int IsEqual(this int value, int comparisonValue)
            => value == comparisonValue
                ? value
                : throw new ArgumentException($"{value} is not equal to  {comparisonValue}.");

        public static int IsNotEqual(this int value, int comparisonValue)
            => value != comparisonValue
                ? value
                : throw new ArgumentException($"{value} is equal to {comparisonValue}.");
    }
}