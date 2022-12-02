
using ShoppingWebAPI.EFcore;

namespace ShoppingWebAPI.Model
{
    public class DBHelper
    {
        private EF_DataContext _context;
        public DBHelper(EF_DataContext context)
        {
            _context = context;
        }

        public List<StudentModel> GetStudents()
        {
            List<StudentModel> response = new List<StudentModel>();
            var data = _context.Students.ToList();
            data.ForEach(row => response.Add(new StudentModel() {
                email = row.email,
                id = row.id,
                name = row.name,
                high = row.high,
                age = row.age
            }));
            return response;
        }
        public StudentModel GetStudentByID(int id)
        {
            StudentModel response = new StudentModel();
            var row = _context.Students.Where(p => p.id.Equals(id)).FirstOrDefault();
           
            return new StudentModel() {
                email = row.email,
                id = row.id,
                name = row.name,
                high = row.high,
                age = row.age
            };
        }

        public void SaveClass(ClassModel orderModel)
        {
            Class dbTable = new Class();
            if (orderModel.id > 0)
            {
                //put
                dbTable = _context.Classes.Where(d=> d.id.Equals(orderModel.id)).FirstOrDefault();
                if(dbTable != null)
                {
                    dbTable.cousera = orderModel.cousera;
                    dbTable.tern = orderModel.tern;
                }
                else
                {
                    dbTable = new Class();
                    dbTable.cousera = orderModel.cousera;
                    dbTable.tern = orderModel.tern;
                    dbTable.name = orderModel.name;

                    dbTable.Student = _context.Students.Where(f => f.id.Equals(orderModel.Student_id)).FirstOrDefault();
                    _context.Classes.Add(dbTable);
                }
             
            }
            _context.SaveChanges();
        }

        public void DeleteClass(int id)
        {

            var order = _context.Classes.Where(d => d.id.Equals(id)).FirstOrDefault();
            if(order != null)
            {
                _context.Classes.Remove(order);
                _context.SaveChanges();
            }

        }
    }
}
