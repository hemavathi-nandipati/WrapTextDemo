using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AssignmentDemo.WrapText
{
    public static class WrapText
    {
        /// <summary>
        /// Wrap method is used to wrap the given text to fit within the specified width.
        /// </summary>
        /// <param name="text">Text to be wrapped</param>
        /// <param name="width">Width in characters to which the text should be wrapped</param>
        /// <returns>The modified text as per the given width</returns>
        public static string Wrap(string text, int width)
        {
            
            if (width <= 0)
            {
                throw new InvalidOperationException();
            }
            
            //Regular expression to get an output that contains only alpha-numeric text and also to trim multiple spaces
            text = Regex.Replace(text, @"[^0-9a-zA-Z&\\S//]+", " ");
            
            StringBuilder sb = new StringBuilder();
            
            //Breaking the text into smaller lines as needed
            do
            {
                //Regular expression to trim & and white spaces at the start of a line.
                text = Regex.Replace(text, @"^[&|\s]*", "");
                int maxChars = LineBreak(text, width);
                if (maxChars == 0)
                    break;
                //To find the index of / character from
                int idx = text.Substring(0, maxChars).IndexOf('/');

                if (idx >= 0)
                {
                    //Get the text until / 
                    sb.Append(text, 0, idx);
                    sb.Append(Environment.NewLine);

                    //Empty the text 
                    text = "";
                }
                else
                {   sb.Append(text, 0, maxChars);
                    sb.Append(Environment.NewLine);
                    text = text.Substring(maxChars, text.Length - maxChars);
                }
                
            } while (text.Length > 0);
            return sb.ToString();

        }
        /// <summary>
        /// Locates position to break the given line so as to avoid breaking the words
        /// </summary>
        /// <param name="text">String that contains line of text</param>
        /// <param name="max">Maximum line length</param>
        /// <returns></returns>
        private static int LineBreak(string text, int max)
        {
            int i = max;

            if (text.Length > max)
            {
                //To find if & is present then return the index to break the line 
                int idx = text.Substring(0, max).IndexOf('&');
                if (idx > 0)
                {
                    return idx;
                }

                //Find the last white space
                while (i >= 0 && (!Char.IsWhiteSpace(text[i])))
                {
                    i--;
                }
                // If no whitespace found, break at maximum length
                if (i < 0)
                    return max;
            }
            else
            {
                return text.Length;
            }
            //Return length of the text before till the last whitespace
            return i + 1;
        }
    }
}
