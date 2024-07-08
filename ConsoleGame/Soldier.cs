namespace ConsoleGame;

public enum Faction
{
    Rebel, 
    Empire
}

public class Soldier
{
    private static Random random = new Random();
    public int health { get; set; }
    public int damage { get; set; }
    public string reference { get; set; }
    public Faction faction { get; set; }

    public Soldier(Faction faction)
    {
        this.health = random.Next(1000, 2000);
        this.damage = random.Next(100, 500);
        this.reference = GenerateRandomReference(6);
        this.faction = faction;
    }

    public int Attack(Soldier target)
    {
        int percentage = random.Next(1,100);
        int damage = this.damage / percentage * 100;

        target.health -= damage;

        return damage;
    }

    private static string GenerateRandomReference(int lenght)
    {
        String str = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        String reference = "";

        for (int i = 0; i < lenght; i++)
        {
            int x = random.Next(str.Length);
            reference = reference + str[x];
        }
        return reference;
    }
}