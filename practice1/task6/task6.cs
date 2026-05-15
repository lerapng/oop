class Program
{
    delegate bool Validator(string input);
 
    static Validator GetValidator(int minLength)
    {
        return text => text.Length >= minLength;
    }
 
    static void Main()
    {
        Validator passwordValidator = GetValidator(8);
        Validator loginValidator = GetValidator(3);
 
        string[] testInputs = { "ab", "usr", "pass", "mypassword", "x1", "admin123" };
 
        foreach (string input in testInputs)
        {
            bool loginOk = loginValidator(input);
            bool passOk = passwordValidator(input);
            Console.WriteLine($"\"{input}\" -> логін: {(loginOk ? "OK" : "FAIL")}, пароль: {(passOk ? "OK" : "FAIL")}");
        }
    }
}