using Lab_2.Models;

namespace Lab_2.Repository
{
    
    public class DepartementMemoryRepository:IDepartementRepository
    {
        List<Department> depts;
        public DepartementMemoryRepository()
        {
            depts = new List<Department>();
            depts.Add(new Department() { Id = 1, Name = "Memory1", Manager = "Mona1" });
            depts.Add(new Department() { Id = 2, Name = "Memory2", Manager = "Mona2" });
        }

        public void Add(Department department)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll() {
            return depts;
        }

        public Department GetBYId(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Department department)
        {
            throw new NotImplementedException();
        }
    }

}
