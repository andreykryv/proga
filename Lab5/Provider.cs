//главный клаcc 






class Provider
{

    private string name;
   
    
    internal Provider(string name )
    {
        this.name = name;
   
        


    }
public string Name => name;

 /// коллекции 
   internal List<Tariff> tariffs = new List<Tariff>();
   internal List<Client> clients = new List<Client>();

internal void AddTariff(Tariff tariff)
    {
        if (tariff == null)
            throw new ArgumentNullException(nameof(tariff), "Тариф не может быть null.");
        tariffs.Add(tariff);
    }
internal void AddClient(Client client) 
    {if (client == null)
        throw new ArgumentException("Количество клиентов не может быть отрицательным.");
   
      clients.Add(client);        
    

    }
internal decimal SummaryProfit(){
    decimal SummaryProfit = 0;
    foreach (Client client in clients)
    {
        SummaryProfit += client.CalculateCost();
       
    } 

 return SummaryProfit; 
}
internal Client GreatestClient()
{  if (clients.Count == 0)
        throw new InvalidOperationException("Список клиентов пуст.");
     Client GreatestClient = clients[0];
    decimal maxCost = clients[0].CalculateCost();

    foreach (Client client in clients)
    {
       if (client.CalculateCost() >= maxCost)
       {maxCost = client.CalculateCost();
        GreatestClient = client;
       }
    
    } 
     
     return GreatestClient;
} 









    
   






    
}