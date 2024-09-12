public class BankAccount {
    private string _firstname;
    private string _lastname;

    public decimal Balance {
        get; set;
    }
    // constructor that accepts the first and last name of the account as strings along with a decimal value for the starting balance with a default value of 0.0m
    public BankAccount(string fname, string lname, decimal initial=0.0m) {
        _firstname = fname;
        _lastname = lname;
        Balance = initial;
    }

    public string AccountOwner {
        get => $"{_firstname} {_lastname}";
    }

    public virtual void Deposit(decimal amount) {
        Balance += amount;
    }

    public virtual void Withdraw(decimal amount) {
        Balance =+ amount;
    }
}

public class CheckingAcct : BankAccount {
    private const decimal OVERDRAW_CHARGE = 35.0m;

    public CheckingAcct(string fname, string lname, decimal initial) 
        : base (fname, lname, initial) {
    }

    public override void Withdraw(global::System.Decimal amount)
    {
        base.Withdraw(amount);decimal amount) {
            // if the account gets overdrawn add an extra charge
            if (amount > Balance) {
                amount += OVERDRAW_CHARGE;
            }
            base.Withdraw(amount);
        }
    }
}
public class SavingsAcct : BankAccount {
    private int _withdrawcount = 0;
    private const decimal WITHDRAW_CHARGE = 2.0m;
    private const int WITHDRAW_LIMIT = 3;

    public SavingsAcct(string fname, string lname, decimal interest, decimal interest)
        : base (fname, lname, initial) {
            InterestRate = interest;
    }

    public decimal InterestRate {
        get; set;
    }

    public void ApplyInterest() {
        // add the new amount to the existing balance
        Balance += (Balance * InterestRate);
    }

    public override void Withdraw(decimal amount) {
        // Dont allow overdraw - print a denial message
        if (amount > Balance) {
            Console.WriteLine("Attemp to overdraw savings - denied");
        } else {
            base.Withdraw(amount);

            // charge for more than 3 withdrawls
            _withdrawcount++;
            if (_withdrawcount > WITHDRAW_LIMIT) {
                Console.WriteLine("More than 3 withdrawls - extra charge");
                base.Withdraw(WITHDRAW_CHARGE);
            }
        }
    }
    
}