// Base class BankAccount
public class BankAccount {
    private string _firstname;
    private string _lastname;
    // A decimal read and write property that contains the account balance
    public decimal Balance {
        get; set;
    }
    // constructor that accepts the first and last name of the account as strings along with a decimal value for the starting balance with a default value of 0.0m
    public BankAccount(string fname, string lname, decimal initial=0.0m) {
        _firstname = fname;
        _lastname = lname;
        Balance = initial;
    }

    // a get-only string that returns the full name of the account owner, i.e "John Doe"
    public string AccountOwner {
        get => $"{_firstname} {_lastname}";
    }

    // a function that accepts a decimal argument, the amount to deposit
    // virtual = allowed to provide its own implementation of the method
    public virtual void Deposit(decimal amount) {
        Balance += amount;
    }

    // a function that accepts the decimal argument, the amount to withdraw
    public virtual void Withdraw(decimal amount) {
        Balance -= amount;
    }
}

public class CheckingAcct : BankAccount {
    // declaring a constant decimal for the overall charge of $35 fee
    private const decimal OVERDRAW_CHARGE = 35.0m;

    // constructor that accepts the same arguments as the base account class
    public CheckingAcct(string fname, string lname, decimal initial) 
        : base (fname, lname, initial) {
    }

    // override of Withdraw, which checks to see if the amount being withdraw exceeds the current balance; if so, the account is charged a $35 fee and the withdrawl is allowed
    public override void Withdraw(decimal amount){
            // if the account gets overdrawn add an extra charge
            if (amount > Balance) {
                amount += OVERDRAW_CHARGE;
            }
            base.Withdraw(amount);
        }
}
public class SavingsAcct : BankAccount {
    private int _withdrawcount = 0;
    private const decimal WITHDRAW_CHARGE = 2.0m;
    private const int WITHDRAW_LIMIT = 3;

    // constructor that grabs the same arguments as the base account class + the constructor for interest rate
    public SavingsAcct(string fname, string lname, decimal interest, decimal interest)
        : base (fname, lname, initial) {
            InterestRate = interest;
    }

    // read/write decimal property that contains the interest rate
    public decimal InterestRate {
        get; set;
    }

    // function that applies to the interest rate to the current balance
    public void ApplyInterest() {
        // add the new amount to the existing balance
        Balance += (Balance * InterestRate);
    }

    // Override of the Withdraw function that checks to see if the withdrawal amount exceeds the balance and prevents the withdrawal
    public override void Withdraw(decimal amount) {
        // Dont allow overdraw - print a denial message
        // if the amount being withdrawed is over the balance, hit them with that error
        if (amount > Balance) {
            Console.WriteLine("Attemp to overdraw savings - denied");
        } else {
            base.Withdraw(amount);

            // charge for more than 3 withdrawls
            // if there are more than 3 withdrawals, then the account is charged a withdrawal charge of $2
            _withdrawcount++;
            if (_withdrawcount > WITHDRAW_LIMIT) {
                Console.WriteLine("More than 3 withdrawls - extra charge");
                base.Withdraw(WITHDRAW_CHARGE);
            }
        }
    }
    
}