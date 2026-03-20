using System;
using System.Collections.Generic;

namespace KeywordDetector
{
    public class Detector
    {
        private List<string> keywords;

        public Detector(List<string> keywords)
        {
            this.keywords = keywords;
        }

        public bool ContainsKeyword(string input)
        {
            foreach (var keyword in keywords)
            {
                if (input.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}