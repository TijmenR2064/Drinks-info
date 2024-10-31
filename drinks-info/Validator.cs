namespace drinks_info
{
    public class Validator
    {
        internal static bool isStringValid(string input)
        {
            if(String.IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != '/' && c!= ' ')
                    return false;
            }

            return true;
        }

        public static bool isIdValid(string input)
        {
            if(String.IsNullOrEmpty(input))
            {
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }
    }
}