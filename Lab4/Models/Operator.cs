class Operator
{
    private static Operator? operatorInstance;
    private string operatorName;
    private int subscriberCount;
    private Tariff operatorTariff;






    public string OperatorName => operatorName;
    public int SubscriberCount => subscriberCount;
    public decimal CurrentTariffCost => Tariff.TariffCost;


    private Operator()
    {
        operatorName = "Неизветное имя";
        subscriberCount = 0;
        operatorTariff = new Tariff();
    }
    private Operator(string name, int count, decimal cost)
    {
            operatorName = name;
            subscriberCount = count;
            operatorTariff = new Tariff(cost);
    }




    public static Operator GetInstance()
    {
        if (operatorInstance == null)
                operatorInstance = new Operator();
            return operatorInstance;
    }
    
    public static void ResetInstance()
{
    operatorInstance = null;
}




    public decimal  CalculateRevenue()
    {
    return subscriberCount * Tariff.TariffCost;//Подсчёт общей выручки (subscriberCount × TariffCost)    
    }
    public void TariffUp(decimal amount)
    {
        Tariff.IncreaseCost(amount);//Увеличение тарифа (делегирует в Tariff)
    }
    public void TariffDown(decimal amount)
    {
       Tariff.DecreaseCost(amount);//Уменьшение тарифа (делегирует в Tariff)    
    }
    public void  AddSubscribers(int count)
    {
         subscriberCount += count;
    }
    public void RemoveSubscribers(int count)
    {
          if (count > subscriberCount)
        throw new ArgumentException("Нельзя удалить больше абонентов, чем есть.");
    subscriberCount -= count;
    }


}