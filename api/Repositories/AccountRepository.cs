namespace api.Repositories;

public class AccountRepository : IAccountRepository
{
    public void Create(int age, string name)
    {
        Console.WriteLine(Convert.ToString(age), name); // implementation
    }

    public int CalcTotalAges(int age1, int age2)
    {
        return age1 + age2; // implementation
    }

    public bool IsAlive()
    {
        return false;
    }
}