namespace ConsoleGame;

public enum Faction
{
    Rebel, 
    Empire
}

public class Soldier
{
    private static Random random = new Random();
    private int health;
    private int damage;
    private string reference;
    private Faction faction;

    public Soldier(Faction faction)
    {
        this.health = random.Next(1000, 2000);
        this.damage = random.Next(100, 500);
        this.reference = GenerateRandomReference(6);
        this.faction = faction;
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