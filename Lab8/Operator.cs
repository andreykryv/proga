/// <summary>Главный класс — интернет-оператор.</summary>
class Operator
{
    private string name;
    internal List<Client> clients = new List<Client>();

    internal Operator(string name)
    {
        this.name = name;
    }

    public string Name => name;

    internal void AddClient(Client client)
    {
        if (client == null)
            throw new ArgumentNullException(nameof(client), "Клиент не может быть null.");
        clients.Add(client);
    }

    /// <summary>
    /// Суммарная стоимость услуг по всем клиентам.
    /// Итерирует через IBillable — демонстрация полиморфизма.
    /// </summary>
    internal decimal SummaryProfit()
    {
        decimal total = 0;
        foreach (IBillable billable in clients)   // клиенты через интерфейсную ссылку
            total += billable.CalculateCost();
        return total;
    }
}