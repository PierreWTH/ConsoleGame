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

        Soldier favorite = this.GetRandomFavorite();
        Console.WriteLine($"Le favori de la parti est le soldat {favorite.reference} de {favorite.faction} !");

        while (remainEmpireSoldier && remainRebelSoldier)
        {
            // Choose a random soldier
            
            remainEmpireSoldier = EmpireHasSoldier();
            remainRebelSoldier = RebelsHasSoldier();
            
            if (remainEmpireSoldier == false)
            {
                Console.WriteLine("****************");
                Console.WriteLine("Il ne reste plus de soldats de l'empire. Les rebelles ont gagné ! ");
                if (favorite.faction == Faction.Empire)
                {
                    Console.WriteLine("Le favori est mort");
                }
                else if(this.rebelSoldier.Contains(favorite))
                {
                    Console.WriteLine("Le favori rebelle est vivant !");
                }
                return; 
            }
            if(remainRebelSoldier == false)
            {
                Console.WriteLine("****************");
                Console.WriteLine("Il ne reste plus de soldats rebelles. L'empire a gagné !");
                if (favorite.faction == Faction.Rebel)
                {
                    Console.WriteLine("Le favori est mort");
                }
                else if(this.empireSoldier.Contains(favorite))
                {
                    Console.WriteLine("Le favori de l'empire est vivant !");
                }
                return;
            }

            if (turn > 0)
            {
                Console.WriteLine("Tour suivant... ");
            }
            
            var allSoldier = this.empireSoldier.Concat(this.rebelSoldier);
            int index = random.Next(allSoldier.Count());
            
            Soldier shooter = allSoldier.ElementAt(index);
            Soldier target = GetRandomSoldier(shooter.faction);
            int damage = shooter.Attack(target);
            
            DisplayFightInfo(shooter, target, turn, damage);

            turn++;
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
        Console.WriteLine("-------------------------------------");
        
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
        
        //Thread.Sleep(1000);
    }

    private Boolean RebelsHasSoldier()
    {
        int health = 0;
        foreach (Soldier soldier in this.rebelSoldier)
        {
            health += soldier.health;
        }

        return health != 0;
    }
    
    private Boolean EmpireHasSoldier()
    {
        int health = 0;
        foreach (Soldier soldier in this.empireSoldier)
        {
            health += soldier.health;
        }

        return health != 0;
    }

    private Soldier GetRandomFavorite()
    {
        var allSoldier = this.empireSoldier.Concat(this.rebelSoldier);
        int index = random.Next(allSoldier.Count());
        Soldier favorite = allSoldier.ElementAt(index);

        return favorite;

    }
}