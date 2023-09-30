using System.Text.RegularExpressions;

namespace SitecoreAssignment {
    public class Task2 {
        public Task2() { }

        public bool checkPalindrome(String input) => Regex.Replace(input, "[^0-9A-Za-z _-]", "").Equals(reverse(Regex.Replace(input, "[^0-9A-Za-z _-]", "")));
            /**
            //removes trash characters
            input = Regex.Replace(input, "[^0-9A-Za-z _-]", "");
            Char[] reversedChar = input.ToCharArray();
            Array.Reverse(reversedChar);
            //created new string
            String reversedString = new string(reversedChar);
            Console.WriteLine(input + ", " + reversedString);
            return input.Equals(reversedString);
            **/
        

        public String reverse(String input) {
            char[] charArray = input.ToCharArray();

            String reversedString = "";

            for (int i = charArray.Length - 1; i > -1; i--) {
                reversedString += charArray[i];
            }

            return reversedString;
        }
    }
}
