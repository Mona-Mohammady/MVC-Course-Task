using Lab_2.Models;

namespace Lab_2.Repository
{
    public interface IDepartementRepository
    {
        List<Department> GetAll();
        Department GetBYId(int id);
        void Add(Department department);
        void Update(int id, Department department);
        void Delete(int id);
        void Save();

    }
}