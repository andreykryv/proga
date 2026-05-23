/// <summary>
/// Встроенный кухонный процессор (стационарный в столешницу).
/// Дополнительные функции: миксер (IMixer) и тестомешалка (IDoughMixer).
/// </summary>
class BuiltinProcessor : ProcessorBase, IMixer, IDoughMixer
{
    public override void GetInfo()
    {
        Say($"Я встроенный кухонный процессор, тип: {Type}. " +
            "Вмонтирован в столешницу, мощный и тихий.");
    }

    public void Mix()
    {
        Say("Миксер (встроенный): взбиваю белки / сливки планетарным венчиком");
    }

    public void MixDough()
    {
        Say("Тестомешалка: вымешиваю крутое дрожжевое тесто крюком-насадкой");
    }
}
