using System.Collections.Generic;

public interface IStocareData
{
    void AddJucarie(Jucarie j);
    List<Jucarie> GetJucarii();
    void SalveazaTot(List<Jucarie> lista);
}