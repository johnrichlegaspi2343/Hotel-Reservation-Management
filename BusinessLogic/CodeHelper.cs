namespace BusinessLogic
{
    public static class CodeHelper
    {
        // Ginagawang number ang code. Mas maluwag na ngayon:
        // "RES-0005", "res-5", "RES 5", "res5" at "5" ay lahat 5
        public static int ToId(string code, string prefix)
        {
            // Tanggalin ang space at gitling, at gawing malaking letra
            code = code.Trim().ToUpper().Replace(" ", "").Replace("-", "");
            string cleanPrefix = prefix.ToUpper().Replace("-", "");

            if (code.StartsWith(cleanPrefix))
            {
                code = code.Substring(cleanPrefix.Length);
            }

            int id;
            if (!int.TryParse(code, out id) || id <= 0)
            {
                throw new Exception("Invalid ID. Example: " + cleanPrefix + "-0001");
            }
            return id;
        }

        // TRUE kung nagsisimula sa prefix, hal. "res-1" ay nagsisimula sa "RES"
        public static bool StartsWithPrefix(string text, string prefix)
        {
            string cleanPrefix = prefix.ToUpper().Replace("-", "");
            return text.Trim().ToUpper().StartsWith(cleanPrefix);
        }

        // TRUE kung numero lang ang laman
        public static bool IsDigits(string text)
        {
            text = text.Trim();
            if (text == "") return false;

            foreach (char c in text)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }
    }
}