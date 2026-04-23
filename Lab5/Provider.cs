//главный клаcc

class Provider
{
    private string name;

    internal Provider(string name)
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
    {
        if (client == null)
            throw new ArgumentNullException(nameof(client), "Клиент не может быть null.");
        clients.Add(client);
    }

    internal decimal SummaryProfit()
    {
        decimal summaryProfit = 0;
        foreach (Client client in clients)
        {
            summaryProfit += client.CalculateCost();
        }
        return summaryProfit;
    }

    internal Client GreatestClient()
    {
        if (clients.Count == 0)
            throw new InvalidOperationException("Список клиентов пуст.");

        Client greatestClient = clients[0];
        decimal maxCost = clients[0].CalculateCost();

        foreach (Client client in clients)
        {
            decimal cost = client.CalculateCost();
            if (cost > maxCost)
            {
                maxCost = cost;
                greatestClient = client;
            }
        }

        return greatestClient;
    }
}