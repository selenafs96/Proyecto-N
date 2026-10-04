namespace ProyectoNApi.Validators.Utils
{
    public static class ValidatorsUtils
    {
        /// <summary>
        /// Validates a spanish DNI using the official algorithm.
        /// </summary>
        /// <param name="dni">Text string containing the DNI to be validated (8 digits and 1 letter).</param>
        /// <returns>true if the format is correct, false if it's not.</returns>
        public static bool BeAValidDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;

            dni = dni.ToUpper().Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d{8}[A-Z]$")) return false;

            string letterSet = "TRWAGMYFPDXBNJZSQVHLCKE";
            int number = int.Parse(dni.Substring(0,8));
            char calculatedLetter = letterSet[number % 23];

            return calculatedLetter == dni[8];
        }
    }
}