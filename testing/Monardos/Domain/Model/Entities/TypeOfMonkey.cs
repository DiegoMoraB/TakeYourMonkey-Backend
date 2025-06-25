
namespace testing.Monardos.Domain.Model.Entities;
public partial class TypeOfMonkey
{
    public int Id  { get; private set; }
    public string Name { get; private set; }
    public ICollection<Monkey> Monkeys { get; private set; } = new List<Monkey>();
}