class Operator
{
    private string name;
    private List<Client> clients = new List<Client>();

    public Operator(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название оператора не может быть пустым.");
        this.name = name;
    }

    public string Name => name;
    public IReadOnlyList<Client> Clients => clients;

    public void AddClient(Client client)
    {
        if (client == null)
            throw new ArgumentNullException(nameof(client), "Клиент не может быть null.");
        clients.Add(client);
    }

    
    public decimal SummaryProfit()
    {
        decimal total = 0;
        foreach (IBillable billable in clients)
            total += billable.CalculateCost();
        return total;
    }

    
    
    
    
    public void PrintDiscountSummary()
    {
        foreach (IBillable billable in clients)
        {
            if (billable is Client client)
            {
                decimal baseCost       = client.CalculateBaseCost();
                decimal discountedCost = client.CalculateCost();
                decimal saved          = baseCost - discountedCost;

                if (saved > 0)
                {
                    string discountLabel = client.GetStrategy().DiscountLabel;
                    Console.WriteLine($"{client.Name}: {discountLabel}, " +
                                      $"экономия {saved:F2} руб.");
                }
            }
        }
    }

    
    public void PrintAllInfo()
    {
        foreach (IDisplayable displayable in clients)
            Console.WriteLine(displayable.GetInfo());
    }
}