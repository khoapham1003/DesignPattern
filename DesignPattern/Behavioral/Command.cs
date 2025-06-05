

//Receiver: Xử lý nghiệp vụ
public class Account
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public Account(string owner, decimal initial)
    {
        Owner = owner;
        Balance = initial;
    }
    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"{Owner} gửi vào tk {amount}k. Số dư mới: {Balance}k");
    }
    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine($"{Owner} không đủ để rút {amount}k. Số dư: {Balance}k");
            return;
        }
        else
        {
            Balance -= amount;
            Console.WriteLine($"{Owner} rút {amount}k. Số dư mới: {Balance}k");
        }
    }
    public void TransferTo(Account to, decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine($"Không thể chuyển {amount}k đến {to.Owner}. Số dư {Owner}: {Balance}k");
            return;
        }
        else
        {
            this.Withdraw(amount);
            to.Deposit(amount);
            Console.WriteLine($"Chuyển thành công {amount}k từ {Owner} đến {to.Owner}");
        }
    }
}

// Interface Command
public interface ITransaction
{
    void Execute();
}

//Concrete Commands: Nạp tiền
public class DepositCommand : ITransaction
{
    private readonly Account _receiver;
    private readonly decimal _amount;

    public DepositCommand(Account receiver, decimal amount)
    {
        _receiver = receiver;
        _amount = amount;
    }

    public void Execute()
    {
        _receiver.Deposit(_amount);
    }
}


//Concrete Commands: Rút tiền
public class WithdrawCommand : ITransaction
{
    private readonly Account _receiver;
    private readonly decimal _amount;

    public WithdrawCommand(Account receiver, decimal amount)
    {
        _receiver = receiver;
        _amount = amount;
    }

    public void Execute()
    {
        _receiver.Withdraw(_amount);
    }
}

//Concrete Commands: Chuyển tiền
public class TransferCommand : ITransaction
{
    private readonly Account _from;
    private readonly Account _to;
    private readonly decimal _amount;

    public TransferCommand(Account from, Account to, decimal amount)
    {
        _from = from;
        _to = to;
        _amount = amount;
    }

    public void Execute()
    {
        _from.TransferTo(_to, _amount);
    }
}



// Invoker
public class BankSystem
{
    private ITransaction _command;

    public void SetCommand(ITransaction command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}
