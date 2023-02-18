namespace CsharpUtilsLib.Global;

public static class Global
{
    public static bool IsValidEAN(string input)
    {
        if (string.IsNullOrEmpty(input) || input.Length != 13 && input.Length != 14)
        {
            return false;
        }

        int sum = 0;
        for (int i = 0; i < input.Length - 1; i += 2)
        {
            sum += int.Parse(input[i].ToString());
        }
        for (int i = 1; i < input.Length - 1; i += 2)
        {
            sum += 3 * int.Parse(input[i].ToString());
        }

        int checksum = 10 - (sum % 10);
        if (checksum == 10)
        {
            checksum = 0;
        }

        return checksum == int.Parse(input[^1].ToString());
    }

    public static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }


    public static bool IsValidIpAddress(string ipAddress)
    {
        if (string.IsNullOrEmpty(ipAddress))
        {
            return false;
        }

        string[] octets = ipAddress.Split('.');

        if (octets.Length != 4)
        {
            return false;
        }

        foreach (string octet in octets)
        {
            if (!int.TryParse(octet, out int result) || result < 0 || result > 255)
            {
                return false;
            }
        }

        return true;
    }
}