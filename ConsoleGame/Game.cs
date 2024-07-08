namespace ConsoleGame;

public class Game
{
    private List<Soldier> empireSoldier = new List<Soldier>();
    private List<Soldier> rebelSoldier = new List<Soldier>();
    private static Random random = new Random();

    public Game(int numberOfEmpireSoldier, int numberOfRebelSoldier)
    {
        for(int i = 0; i < numberOfRebelSoldier; i++)
        {
            Soldier empire = new Soldier(Faction.Empire);
            empireSoldier.Add(empire);
        }
        
        
        for(int i = 0; i < numberOfEmpireSoldier; i++)
        {
            Soldier rebel = new Soldier(Faction.Rebel);
            rebelSoldier.Add(rebel);
        }
    }
    public void RunGame()
    {
        Console.WriteLine("La partie va commencer !");
        
        // Choose a random soldier
        
        var allSoldier = this.empireSoldier.Concat(this.rebelSoldier);
        int index = random.Next(allSoldier.Count());
        
        Soldier shooter = allSoldier.ElementAt(index);
        Soldier target = GetRandomSoldier(shooter.faction);
        Console.WriteLine(target.health);
        int damage = shooter.Attack(target);
        
        DisplayFightInfo(shooter, target, 3, damage);



    }

    private Soldier GetRandomSoldier(Faction faction)
    {
        var selectedList = faction == Faction.Empire ? this.rebelSoldier : this.empireSoldier;
        int index = random.Next(selectedList.Count);
        return selectedList[index];
    }

    private void DisplayFightInfo(Soldier shooter, Soldier target, int turn, int damage)
    {
        Console.WriteLine($"Le tour {turn} commence !");
        
        Thread.Sleep(1000);
        
        Console.WriteLine($"Le soldat {shooter.reference} ({shooter.faction}) attaque le soldat {target.reference} ({target.faction})");

        string attackSentence = shooter.faction == Faction.Empire ? "Traitor !!" : "Pour la princesse Organa !";
        Console.WriteLine(attackSentence);
        
        Console.WriteLine($"Il lui inflige {damage} points de dégats.");
        if (target.health > 0)
        {
            Console.WriteLine($"Il reste {target.health} points de vie au {target.faction}. ");
        }
        else
        {
            Console.WriteLine($"Le soldat {target.reference} ({target.faction}) est mort... RIP.");
        }
        
        Console.WriteLine("Tour suivant... ");
    }
    
    
    
}