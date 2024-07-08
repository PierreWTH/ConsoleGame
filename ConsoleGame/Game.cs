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

        Boolean remainEmpireSoldier = true;
        Boolean remainRebelSoldier = true;
        int turn = 0;

        while (remainEmpireSoldier || remainRebelSoldier)
        {
            // Choose a random soldier
            
            remainEmpireSoldier = RebelsHasSoldier();
            remainRebelSoldier = EmpireHasSoldier();
            
            var allSoldier = this.empireSoldier.Concat(this.rebelSoldier);
            int index = random.Next(allSoldier.Count());
            
            Soldier shooter = allSoldier.ElementAt(index);
            Soldier target = GetRandomSoldier(shooter.faction);
            int damage = shooter.Attack(target);
            
            DisplayFightInfo(shooter, target, turn, damage);

            turn++;
        }

        if (remainEmpireSoldier == false)
        {
            Console.WriteLine("Les rebelles ont gagné ! ");
        }
        else
        {
            Console.WriteLine("L'empire a gagné !");
        }
        
    }

    private Soldier GetRandomSoldier(Faction faction)
    {
        var selectedList = faction == Faction.Empire ? this.rebelSoldier : this.empireSoldier;
        
        // Remove dead soldiers
        selectedList.RemoveAll(soldier => soldier.health == 0);
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
        Thread.Sleep(1000);
    }

    private Boolean RebelsHasSoldier()
    {
        List<int> health = new List<int>();
        foreach (Soldier soldier in this.rebelSoldier)
        {
            health.Add(soldier.health);
        }

        Boolean remainSoldier = health.Distinct().Skip(0).Any();

        return remainSoldier;
    }
    
    private Boolean EmpireHasSoldier()
    {
        List<int> health = new List<int>();
        foreach (Soldier soldier in this.empireSoldier)
        {
            health.Add(soldier.health);
        }

        Boolean remainSoldier = health.Distinct().Skip(0).Any();

        return remainSoldier;
    }
    
}