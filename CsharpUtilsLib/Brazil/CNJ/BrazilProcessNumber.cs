namespace CsharpUtilsLib.Brazil.CNJ;

public sealed class BrazilProcessNumber
{
    public string NumeroSequencial { get; private set; }
    public string DigitoVerificador { get; private set; }
    public string AnoDeInicio { get; private set; }
    public string Ramo { get; private set; }
    public string Tribunal { get; private set; }
    public string Vara { get; private set; }

    private BrazilProcessNumber(string numeroSequencial, string digitoVerificador, string anoDeInicio, string ramo, string tribunal, string vara)
    {
        NumeroSequencial = numeroSequencial;
        DigitoVerificador = digitoVerificador;
        AnoDeInicio = anoDeInicio;
        Ramo = ramo;
        Tribunal = tribunal;
        Vara = vara;
    }

    private static string CalculateMod(string processWithoutDigit, string digit)
    {
        const int take = 5;
        string mod = string.Empty;

        do
        {
            int a = int.Parse(mod + processWithoutDigit[..take]);
            processWithoutDigit = processWithoutDigit[take..];
            mod = (a % int.Parse(digit)).ToString();
        }
        while (processWithoutDigit.Length > 0);

        return mod;
    }

    public static bool IsValidProcessNumber(string processNumber, out BrazilProcessNumber brazilProcessNumber)
    {
        brazilProcessNumber = null!;

        if (string.IsNullOrEmpty(processNumber))
        {
            return false;
        }

        string clearProcessNumber = processNumber.Replace(".", "").Replace("-", "");

        if (clearProcessNumber.Length < 14 || !double.TryParse(clearProcessNumber, out _))
        {
            return false;
        }

        int extractedDigit = int.Parse(clearProcessNumber.Substring(clearProcessNumber.Length - 13, 2));
        string vara = clearProcessNumber.Substring(clearProcessNumber.Length - 4, 4);
        string tribunal = clearProcessNumber.Substring(clearProcessNumber.Length - 6, 2);
        string ramo = clearProcessNumber.Substring(clearProcessNumber.Length - 7, 1);
        string anoDeInicio = clearProcessNumber.Substring(clearProcessNumber.Length - 11, 4);
        int length = clearProcessNumber.Length - 13;
        string numeroSequencial = clearProcessNumber.Substring(0, length).PadLeft(7, '0');
        int calculatedDigit = 98 - int.Parse(CalculateMod(numeroSequencial + anoDeInicio + ramo + tribunal + vara + "00", "97"));
        var result = extractedDigit == calculatedDigit;

        if (result)
        {
            brazilProcessNumber = new BrazilProcessNumber(numeroSequencial, calculatedDigit.ToString(), anoDeInicio, ramo, tribunal, vara);
        }

        return result;
    }

    public override int GetHashCode()
    {
        return NumeroSequencial.GetHashCode() +
               DigitoVerificador.GetHashCode() +
               AnoDeInicio.GetHashCode() +
               Ramo.GetHashCode() +
               Tribunal.GetHashCode() +
               Vara.GetHashCode();
    }

    public override string ToString()
    {
        return $"{NumeroSequencial}-{DigitoVerificador}.{AnoDeInicio}.{Ramo}.{Tribunal}.{Vara}";
    }
}