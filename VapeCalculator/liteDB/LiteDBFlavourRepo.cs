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
    class LiteDBFlavourRepo
    {

        LiteDatabase _db;
        LiteCollection<FlavourModel> _dbCollection;

        public LiteDBFlavourRepo()
        {
            // Create directory in my documents
            var path = @Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VapeDB";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Set up db collection
            _db = new LiteDatabase(@Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VapeDB\\VapeCalculatorFlavours.db");
            _dbCollection = _db.GetCollection<FlavourModel>("FlavourProfiles");
        }

        public bool CreateDB()
        {
            // Does the db exist?
            try
            {
                _db.GetCollection<FlavourModel>("FlavourProfiles");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveFlavourProfile(int Id)
        {
            // Delete a flavour by id
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

        public IEnumerable<FlavourModel> GetAllFlavourProfiles()
        {
            // Get all flavours
            return _dbCollection.FindAll();
        }

        public FlavourModel GetFlavourProfileById(int Id)
        {
            // Get a specific flavour
            return _dbCollection.Find(i => i.Id == Id).FirstOrDefault();
        }

        public decimal GetFlavourWeight(string Name)
        {
            // Return the flavours weight
            return _dbCollection.Find(i => i.FlavourName == Name).Select(i => i.Weight).FirstOrDefault();
        }

        public bool InsertFlavourProfile(FlavourModel data)
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

        public bool UpdateFlavourProfile(FlavourModel data)
        {
            // Update an existing flavour
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
