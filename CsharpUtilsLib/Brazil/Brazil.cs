namespace CsharpUtilsLib.Validations.Brazil;

public static class Brazil
{
    public static string FormatPIS(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        input = input.Trim();
        input = input.PadLeft(11, '0');
        return input.Substring(0, 3) + "." + input.Substring(3, 5) + "." + input.Substring(8, 2) + "-" + input.Substring(10, 1);
    }

    public static string FormatCPF(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        input = input.Trim();
        input = input.PadLeft(11, '0');
        return input.Substring(0, 3) + "." + input.Substring(3, 3) + "." + input.Substring(6, 3) + "-" + input.Substring(9, 2);
    }

    public static string FormatCNPJ(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        input = input.Trim();
        input = input.PadLeft(14, '0');
        return input.Substring(0, 2) + "." + input.Substring(2, 3) + "." + input.Substring(5, 3) + "/" + input.Substring(8, 4) + "-" + input.Substring(12, 2);
    }

    public static string FormatPhoneNumber(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        return string.Format("({0}) {1}-{2}",
            input.Substring(0, 2),
            input.Substring(2, 4),
            input.Substring(6));
    }

    public static string FormatCEP(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        return string.Format("{0}-{1}", input[..5],
                                        input.Substring(5, 3));
    }

    public static string FormatNCM(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        string ncmWithoutSpace = Texts.RemoveDocumentMask(input);

        if (ncmWithoutSpace.Length != 8)
        {
            return null!;
        }

        string ncm = ncmWithoutSpace.Insert(4, ".").Insert(7, ".");

        return ncm;
    }

    public static string FormatFIPECode(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null!;
        }

        string fipeCodeWithoutMask = Texts.RemoveDocumentMask(input);

        if (fipeCodeWithoutMask.Length != 7)
        {
            return null!;
        }

        string codeWithoutDigit = fipeCodeWithoutMask[..6];
        string digit = fipeCodeWithoutMask.Substring(6, 1);

        return $"{codeWithoutDigit}-{digit}";
    }

    public static bool IsValidCep(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        input = input.OnlyNumbers();

        // Verifica se o CEP tem 8 dígitos
        if (input.Length != 8)
        {
            return false;
        }

        if (!Regex.IsMatch(input[..1], "[0-3]", RegexOptions.Compiled))
        {
            return false;
        }

        if (!Regex.IsMatch(input.Substring(1, 1), "[0-1]", RegexOptions.Compiled))
        {
            return false;
        }

        return true;
    }

    public static bool IsValidCNPJ(string cnpj)
    {
        try
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            if (cnpj.IsSequentialRepetition())
                return false;

            int[] multiple1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiple2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj[..12];
            int sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiple1[i];

            int rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            string digit = rest.ToString();
            tempCnpj += digit;
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempCnpj[i].ToString()) * multiple2[i];

            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit += rest.ToString();

            return cnpj.EndsWith(digit);
        }
        catch
        {
            return false;
        }
    }

    public static bool IsValidCPF(string cpf)
    {
        try
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            if (cpf.IsSequentialRepetition())
                return false;

            int[] multiple1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiple2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf[..9];
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiple1[i];

            int rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            string digit = rest.ToString();
            tempCpf += digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiple2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit += rest.ToString();

            return cpf.EndsWith(digit);
        }
        catch
        {
            return false;
        }
    }

    public static bool IsValidPis(string input)
    {
        int sum = 0, checkDigit, multiple = 2, informedDigit;

        if (string.IsNullOrEmpty(input) || input.Length != 11)
        {
            return false;
        }

        checkDigit = int.Parse(input[10].ToString());

        for (int digit = 9; digit >= 0; digit--)
        {
            sum += (multiple * int.Parse(input[digit].ToString()));
            if (multiple < 9)
            {
                multiple++;
            }
            else
            {
                multiple = 2;
            }
        }

        informedDigit = 11 - (sum % 11);

        if (informedDigit > 9)
        {
            informedDigit = 0;
        }

        return (checkDigit == informedDigit);
    }

    public static bool IsValidVoterIDCard(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length == 0)
        {
            return false;
        }

        short[] multipliers = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 4, 3 };
        int finalDigit, calculateDigit = 0, informedDigit, iDigito = 0;

        input = new String('0', 13 - input.Length) + input;
        finalDigit = int.Parse(input.Substring(9, 2));

        informedDigit = int.Parse(input.Substring(11, 2));

        for (int digit = 0; digit < 11; digit++)
        {
            iDigito += (int.Parse(input[digit].ToString()) * multipliers[digit]);
            if (digit == 8 || digit == 10)
            {
                iDigito %= 11;
                if (iDigito > 1)
                    iDigito = 11 - iDigito;
                else
                {
                    if (finalDigit <= 2)
                        iDigito = 1 - iDigito;
                    else
                        iDigito = 0;
                }
                if (digit == 8)
                    calculateDigit = iDigito * 10;
                else
                    calculateDigit += iDigito;
                iDigito *= 2;
            }
        }

        return calculateDigit == informedDigit;
    }
}