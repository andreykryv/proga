/// <summary>
/// Ручной кухонный процессор (погружной).
/// Дополнительные функции: блендер (IBlender) и соковыжималка (IJuicer).
/// </summary>
class HandProcessor : ProcessorBase, IBlender, IJuicer
{
    public override void GetInfo()
    {
        Say($"Я ручной погружной процессор, тип: {Type}. " +
            "Компактный — работаю прямо в кастрюле или стакане.");
    }

    public void Blend()
    {
        Say("Блендер (погружной): измельчаю прямо в ёмкости, не переливая");
    }

    public void ExtractJuice()
    {
        Say("Соковыжималка: отжимаю сок из цитрусовых насадкой-конусом");
    }
}
