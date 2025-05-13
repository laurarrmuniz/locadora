namespace CRUD_aplication.Util;

    public class Utils
    {
        public static string GetEnvironmentVariable(string variable)
        {
            var result = Environment.GetEnvironmentVariable(variable);
            if (string.IsNullOrEmpty(result))
                throw new Exception($" A variavel de ambiente {variable} não foi encontrada");

            return result;
        }
    }

