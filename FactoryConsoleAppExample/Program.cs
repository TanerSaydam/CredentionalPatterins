
BankCreator bankCreator = new BankCreator();
GarantiBank? garantiBank = bankCreator.Create(BankType.Garanti) as GarantiBank;
GarantiBank? garantiBank1 = bankCreator.Create(BankType.Garanti) as GarantiBank;
GarantiBank? garantiBank2 = bankCreator.Create(BankType.Garanti) as GarantiBank;

#region Abstract Product
interface IBank
{

}
#endregion

#region Concrete Products
class GarantiBank : IBank
{
    string _userCode, _password;
    GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} nesnesi oluşturuldu");
        _userCode = userCode;
        _password = password;
    }

    static GarantiBank()
    => garantiBank = new("abc","123");

    static GarantiBank garantiBank;
    public static GarantiBank GetInstance => garantiBank;

    public void ConnectGaranti()
        => Console.WriteLine($"{nameof(GarantiBank)} - Connected.");

    public void SendMoney(int amount)
        => Console.WriteLine($"{amount} money sent.");
}

class HalkBank : IBank
{
    string _userCode, _password;
    HalkBank(string userCode)
    {
        Console.WriteLine($"{nameof(HalkBank)} nesnesi oluşturuldu");
        _userCode = userCode;
    }

    static HalkBank() => halkBank = new("abc");
    static HalkBank halkBank;
    public static HalkBank GetInstance => halkBank;
    public string Password { set => _password = value; }

    public void Send(int amount, string accountNumber)
        => Console.WriteLine($"{amount} money sent");
}

class CredentialVakifBank : IBank
{
    public string UserCode { get; set; }
    public string Mail { get; set; }
}

class VakifBank : IBank
{
    string _userCode, _email, _password;
    public bool isAuthentication { get; set; } = false;
    VakifBank(CredentialVakifBank credential, string password)
    {
        Console.WriteLine($"{nameof(VakifBank)} nesnesi oluşturuldu");
        _userCode = credential.UserCode;
        _email = credential.Mail;
        _password = password;
    }

    static VakifBank() => vakifBank = new(new() { Mail = "abc", UserCode = "abc" }, "abc");

    static VakifBank vakifBank;
    public static VakifBank GetInstance => vakifBank;

    public void ValidateCredential()
    {
        if (true)
            isAuthentication = true;        
    }

    public void SendMoneyToAccountNumber(int amount, string recipientName, string accountNumber)
        => Console.WriteLine($"{amount} money sent");
}
#endregion

#region Abstract Factory
interface IBankFactory
{
    IBank CreateInstance();
}
#endregion

#region ConcreteFactories
class GarantiFactory : IBankFactory
{
    GarantiFactory() {}
    static GarantiFactory() => _garantiFactory = new();
    static GarantiFactory _garantiFactory;
    static public GarantiFactory GetInstance => _garantiFactory;

    public IBank CreateInstance()
    {
        GarantiBank garantiBank = GarantiBank.GetInstance;
        garantiBank.ConnectGaranti();
        return garantiBank;
    }
}

class HalkBankFactory : IBankFactory
{
    HalkBankFactory() { }
    static HalkBankFactory() => _halkFactory = new();
    static HalkBankFactory _halkFactory;
    static public HalkBankFactory GetInstance => _halkFactory;
    public IBank CreateInstance()
    {
        HalkBank bank = HalkBank.GetInstance;
        bank.Password = "123";
        return bank;
    }
}

class VakifBankFactory : IBankFactory
{
    VakifBankFactory() { }
    static VakifBankFactory() => _vakifFactory = new();
    static VakifBankFactory _vakifFactory;
    static public VakifBankFactory GetInstance => _vakifFactory;
    public IBank CreateInstance()
    {
        VakifBank vakifBank = VakifBank.GetInstance;
        vakifBank.ValidateCredential();
        return vakifBank;
    }
}
#endregion

#region Creator

enum BankType
{
    Garanti, Halkbank, Vakifbank
}

class BankCreator
{
    public IBank Create(BankType bankType)
    {
        IBankFactory _bankFactory = bankType switch
        {
            BankType.Vakifbank => VakifBankFactory.GetInstance,
            BankType.Halkbank => HalkBankFactory.GetInstance,
            BankType.Garanti => GarantiFactory.GetInstance
        };

        return _bankFactory.CreateInstance();
    }
}
#endregion