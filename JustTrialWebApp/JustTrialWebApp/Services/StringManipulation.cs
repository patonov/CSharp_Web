namespace JustTrialWebApp.Services
{
    public class StringManipulation : IStringManipulation
    {

        public string MakeFirstAndSecondLetterUpper(string input)
        {
            if (input == null)
            {
                return "You are not right!";
            }

            if (input.Length <= 2)
            {
                return input.ToUpper();
            }

            return input.Substring(0, 2).ToUpper() + input.Substring(2);
        }
    }
}
