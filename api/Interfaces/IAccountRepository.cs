namespace api.Interfaces;

public interface IAccountRepository
{
    public void Create(int age, string name); // method signature 

    public int CalcTotalAges(int age1, int age2); // method signature 

    public bool IsAlive(); // method signature 
}
