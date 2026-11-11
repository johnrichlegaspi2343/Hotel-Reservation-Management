namespace BusinessLogic
{
    public static class CodeHelper
    {
        // Ginagawang number ang code. Hal: "RES-0005" -> 5, "GST-012" -> 12, "7" -> 7
        public static int ToId(string code, string prefix)
        {
            code = code.Trim().ToUpper();

            if (code.StartsWith(prefix))
            {
                code = code.Substring(prefix.Length);
            }

            int id;
            if (!int.TryParse(code, out id) || id <= 0)
            {
                throw new Exception("Invalid ID. Example: " + prefix + "0001");
            }
            return id;
        }
    }
}