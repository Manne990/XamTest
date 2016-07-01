namespace Infrastructure
{
    public static class NumericExtensions
    {
        public static bool IsInteger(this string arg)
        {
            int value;
            return int.TryParse(arg, out value);
        }

        public static bool IsGreaterThan(this string arg, int minimum)
        {
            var value = int.Parse(arg);
            return minimum < value;
        }

        public static bool IsGreaterThanOrEqualTo(this string arg, int minimum)
        {
            var value = int.Parse(arg);
            return minimum <= value;
        }

        public static bool IsLessThan(this string arg, int maximum)
        {
            var value = int.Parse(arg);
            return value < maximum;
        }

        public static bool IsLessThanOrEqualTo(this string arg, int maximum)
        {
            var value = int.Parse(arg);
            return value <= maximum;
        }

        public static bool IsWithinRange(this string arg, int minimum, int maximum)
        {
            var value = int.Parse(arg);
            return minimum <= value && value <= maximum;
        }

        public static bool IsDouble(this string arg)
        {
            double value;
            return double.TryParse(arg, out value);
        }

        public static bool IsGreaterThan(this string arg, double minimum)
        {
            var value = double.Parse(arg);
            return minimum < value;
        }

        public static bool IsGreaterThanOrEqualTo(this string arg, double minimum)
        {
            var value = double.Parse(arg);
            return minimum <= value;
        }

        public static bool IsLessThan(this string arg, double maximum)
        {
            var value = double.Parse(arg);
            return value < maximum;
        }

        public static bool IsLessThanOrEqualTo(this string arg, double maximum)
        {
            var value = double.Parse(arg);
            return value <= maximum;
        }

        public static bool IsWithinRange(this string arg, double minimum, double maximum)
        {
            var value = double.Parse(arg);
            return minimum <= value && value <= maximum;
        }
    }
}