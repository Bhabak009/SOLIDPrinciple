//SOLID Principle
// S -- Single Responsibility
public class Employee
{
    public int CalculateSalary()
    {
        return 10000;
    }
    public string GetDepartment()
    {
        return "IT";
    }

    public void AddEmployee()  //This method should be in Add,Edit class..Not for Employee Class
    {
        Console.WriteLine("This employee has been added");
    }
}

//O - Open Closed Principle
public class Account
{
    public string Name { get; set; }
    public double Balance { get; set; }

    //public double CalculateInterest(string accouuntType) // It is violating OCP because if another new account is coming tomorrow then we have to add new else if condition here
    //{
    //    if (accouuntType == "Saving")
    //    {
    //        return Balance * 0.7;
    //    }
    //    else
    //    {
    //        return Balance * 0.5;
    //    }
    //}
}
public interface IAccount //Create the interface to open the extension and use it bu extending anywhere you want
{
    double CalculateInterest(Account account);
}
public class SavingAccount : IAccount
{
    public double CalculateInterest(Account account)
    {
        return account.Balance * 0.7;
    }
}
public class DematAccount: IAccount
{
    public double CalculateInterest(Account account)
    {
        return account.Balance * 0.5;
    }
}

//L- Liskov Substitution
public class Teacher
{
    public virtual int CalculateSalary()
    {
        return 20000;
    }
    public virtual int CalculateBonus()
    {
        return 10000;
    }
}
public class PermanentTeacher : Teacher  
{
    public override int CalculateSalary()
    {
        return 40000;
    }
    public override int CalculateBonus()  //Permanent teacher can get the bonus
    {
        return 20000;
    }
}
public class ParaTecher : Teacher
{
    public override int CalculateSalary()
    {
        return 14000;
    }
    public override int CalculateBonus()  //Not given to Para Teachers
    {
        throw new NotImplementedException();
    }
}
class Test
{
    static void Main(string[] args)
    {
        Teacher t = new Teacher();
        PermanentTeacher t2 = new PermanentTeacher();
        ParaTecher t3 = new ParaTecher();
        Console.WriteLine(t.CalculateSalary());
        Console.WriteLine(t.CalculateBonus());
        Console.WriteLine(t2.CalculateSalary());
        Console.WriteLine(t2.CalculateBonus());
        Console.WriteLine(t3.CalculateSalary());
        //Console.WriteLine(t3.CalculateBonus()); //Not implemented exception
        Console.ReadLine();
    }
}

//I - Interface Segregation Principle
public interface IVehicle
{
    void Fly();
    void Run();
}

public class Aeroplane : IVehicle
{
    public void Fly()
    {
        Console.WriteLine("It Flies");
    }

    public void Run()  //If it can not be implemented then it should not be used here
    {
        throw new NotImplementedException();
    }

}
public class FlyingCar : IVehicle //Here We can use for both methods
{
    public void Fly()
    {
        Console.WriteLine("It Flies");
    }

    public void Run()
    {
        Console.WriteLine("It runs Too");
    }
}
public interface IFly  //Segregating the interfaces into small parts to be used specific needs
{
    void Fly();
}
public interface IDrive  //Segregating the interfaces into small parts to be used specific needs
{
    void Run();
}


//D - Dependency Inversion
public interface ILogger
{
    void Log(string message);
}
public class DataAccesslayer //if I implement this Interface directly then this Higher level class will become dependent on Lower level class...that violates the Dependency Inversion principle
{
    private ILogger logger;
    public DataAccesslayer(ILogger logger)
    {
        this.logger = logger;
    }
    public void AddCustomer(string name)
    {
        logger.Log("Customer Added " + name);
    }
}
