using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeCalculator.Models;

namespace VapeCalculator.liteDB
{
    class LiteDBRepo
    {

        LiteDatabase _db;
        LiteCollection<JuiceProfile> _dbCollection;

        public LiteDBRepo()
        {
            // Create directory in my documents
            var path = @Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VapeDB";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Set up db collection
            _db = new LiteDatabase(@Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VapeDB\\VapeCalculator.db");
            _dbCollection = _db.GetCollection<JuiceProfile>("JuiceProfiles");
        }

        public bool CreateDB()
        {
            // Does the db exist?
            try
            {
                _db.GetCollection<JuiceProfile>("JuiceProfiles");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveProfile(int Id)
        {
            // Delete a juice
            try
            {
                _dbCollection.Delete(Id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<JuiceProfile> GetAllProfiles()
        {
            // Get all flavours
            return _dbCollection.FindAll();
        }

        public JuiceProfile GetProfileById(int Id)
        {
            // Get a specific flavour by id
            return _dbCollection.Find(i => i.Id == Id).FirstOrDefault();
        }

        public bool InsertJuiceProfile(JuiceProfile data)
        {
            // Create a new flavour
            try
            {
                _dbCollection.Insert(data);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateJuiceProfile(JuiceProfile data)
        {
            // Update a flavour
            try
            {
                _dbCollection.Update(data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
