/// <summary>
/// Настольный кухонный процессор.
/// Дополнительные функции: миксер (IMixer) и блендер (IBlender).
/// </summary>
class TableProcessor : ProcessorBase, IMixer, IBlender
{
    public override void GetInfo()
    {
        Say($"Я настольный кухонный комбайн, тип: {Type}. " +
            "Имею насадки миксера и блендера.");
    }

    public void Mix()
    {
        Say("Миксер: взбиваю крем / тесто на выбранной скорости");
    }

    public void Blend()
    {
        Say("Блендер: превращаю ингредиенты в однородную массу");
    }
}
