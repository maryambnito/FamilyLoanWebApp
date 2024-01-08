namespace FamilyLoan.Utilities.ExtensionMethods
{
    public static class Ternaryseparatornumbers
    {
        public static string SeparatorNum(this long value)
        {
            var result= value.ToString("N0");
            return result;
        }
    }
}
