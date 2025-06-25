namespace testing.Monardos.Interface.ACL;

public interface IMonkeyContextFacade
{
    Task<int> CreateMonkey(string name,int typeOfMonkeyId);
}