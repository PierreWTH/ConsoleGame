// See https://aka.ms/new-console-template for more information

using ConsoleGame;

// Ask for number of soldiers for each camp

int nbEmpire = AskNumberOfSoldier(Faction.Empire);
int nbRebel = AskNumberOfSoldier(Faction.Rebel);


static int AskNumberOfSoldier(Faction faction)
{
    string factionDesc = GetFactionName(faction);
    
    while(true){
        Console.WriteLine($"Nombre de soldats {factionDesc} : ");
    
        string nbEmpireStr = Console.ReadLine();
        bool isValid = int.TryParse(nbEmpireStr, out int nbSoldier);
        if (!isValid)
        {
            Console.WriteLine("Merci d'entrer un nombre");
        }
        else if (isValid && nbSoldier <= 0)
        {
            Console.WriteLine($"Le nombre de soldat {factionDesc} doit être supérieur à 0");
        }
        else
        {
            return nbSoldier;
        }
    
    }    
}

static string GetFactionName(Faction faction)
{
    switch (faction)
    {
        case Faction.Empire:
            return "de l'empire";
        case Faction.Rebel:
            return "rebelles";
        default:
            return string.Empty;
    }
}