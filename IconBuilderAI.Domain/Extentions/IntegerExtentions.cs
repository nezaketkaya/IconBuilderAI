namespace IconBuilderAI.Domain.Extentions
{
    public static class IntegerExtentions
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}
