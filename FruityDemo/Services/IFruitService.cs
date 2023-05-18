using FruityDemo.Models;

namespace FruityDemo.Services
{
    public interface IFruitService
    {
        Task<List<Fruit>> GetAllFruits();
        Task<List<Fruit>> GetFruitsByFamily(string fruitFamily);
    }
}
