namespace Warehousing.Common.Utilities.Generator
{
    public static class NameGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
