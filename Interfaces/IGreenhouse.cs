using HorizonLab.DataLayer.Models;

namespace HorizonLab.DataLayer.Interfaces
{
    public interface IGreenhouse
    {
        Greenhouse GetGreenhouse(int id);
        List<Greenhouse> GetGreenhouses();
    }
}
