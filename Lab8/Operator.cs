//главный клаcc

class Operator
{
    private string name;

    internal Operator(string name)
    {
        this.name = name;
    }

    public string Name => name;

    /// коллекции
    
    internal List<Client> clients = new List<Client>();

    

    internal void AddClient(Client client)
    {
        if (client == null)
            throw new ArgumentNullException(nameof(client), "Клиент не может быть null.");
        clients.Add(client);
    }

    internal decimal SummaryProfit()//итерирует через IBillable
    {
        decimal summaryProfit = 0;
        foreach (Client client in clients)
        {
            summaryProfit += client.CalculateCost();
        }
        return summaryProfit;
    }

    
}