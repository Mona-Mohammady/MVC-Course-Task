
using Lab_2.Models;

namespace Lab_2.Repository
{
    public class DepartementRepository: IDepartementRepository
    {
        ITIContext Context;
        public DepartementRepository()
        {
            Context = new ITIContext();
        }
       public List<Department> GetAll()
        {
            return Context.Department.ToList();
        }
        public Department GetBYId(int id) {
            return Context.Department.SingleOrDefault(d => d.Id == id);
         }
        public void Add(Department department) { 
           Context.Department.Add(department);

        }
        public void Update(int id , Department department)
        {
            Department olddept = GetBYId(id);
            olddept.Name = department.Name;
            olddept.Id = department.Id;
            olddept.Manager = department.Manager;
            olddept.crs_id=department.crs_id;
            olddept.trainee_id=department.trainee_id; 
            olddept.ins_id=department.ins_id;   
            //Context.Update(department);
        }
        public void Delete(int id)
        {
            Department olddept=GetBYId(id);
            Context.Department.Remove(olddept);    
        }
        public void Save() {
            Context.SaveChanges();
        }
    }
}
