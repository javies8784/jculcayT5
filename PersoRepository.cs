using jculcayS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jculcayS5
{
    public class PersoRepository
    {
        string _dbPath;
        private SQLiteConnection conn;
        // para el manejo de mensajes
        public string StatusMessage { get; set; }
        //funcion para validar la conecion a la base
        private void Init() 
        {
            if (conn is not null) 
                return;
            conn = new(_dbPath);
            conn.CreateTable<Persona>();

            
        }
        public PersoRepository(string dbPath) {
            _dbPath = dbPath;
        }
        public void AddNewPerson(string names) {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(names))
                    throw new Exception("Nombre es requerido");
                Persona person = new() { Name = names };
                result = conn.Insert(person);
                StatusMessage = string.Format("Se inserto una persona", result, names);


            }
            catch (Exception ex) {
                StatusMessage = string.Format("Error no se inserto", names, ex.Message);

            }
        }

        public void UpdatePerson(int ids,string names)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(names))
                    throw new Exception("Nombre es requerido");
                Persona person = new() { Id= ids, Name = names };
                result = conn.Update(person);
                StatusMessage = string.Format("Se Modifico la persona", result, names);


            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error no se modifico", names, ex.Message);

            }
        }

        public void DeletePerson(int ids)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(ids.ToString()))
                    throw new Exception("ID es requerido");
                Persona person = new() { Id = ids};
                result = conn.Delete(person);
                StatusMessage = string.Format("Se elimino a la persona", result, ids);


            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error no se elimino el registro: ", ids.ToString(), ex.Message);

            }
        }

        public List<Persona> GetAllPeople()
        {

            try
            {
                Init();
                return conn.Table<Persona>().ToList();

            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al listar", ex.Message);
            }
            return new List<Persona>();
        }  
      
    }
}
