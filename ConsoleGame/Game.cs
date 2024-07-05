namespace ConsoleGame;

public class Game
{
    private List<Soldier> empireSoldier;
    private List<Soldier> rebelSoldier;

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
    
    
}