using MonoDemo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonoDemo.Repositories
{
    public class UserRepository
    {
        private const string XMLPath = "Add Absolute Path to MonoDemo.xml HERE!";
        private string XMLUri = new Uri(XMLPath, UriKind.Absolute).ToString();

        public UserModel NewUser()
        {
            return new UserModel();
        }

        public UserModel CreateUser()
        {
            XDocument doc = XDocument.Load(XMLUri);

            var id = doc.Descendants("UserModels").Elements("UserModel").Count() > 0 ? doc.Descendants("UserModels").Elements("UserModel").Last().Element("Id").Value : "0";

            return new UserModel() { Id = int.Parse(id) + 1 };
        }

        public UserModel GetUser(int id)
        {
            XDocument doc = XDocument.Load(XMLUri);

            var userModel = doc.Descendants("UserModels").Elements("UserModel").Where(w => w.Element("Id").Value == id.ToString()).Select(s => new UserModel()
            {
                Id = int.Parse(s.Element("Id").Value),
                FirstName = s.Element("FirstName").Value,
                LastName = s.Element("LastName").Value
            });

            return userModel.First();
        }

        public IEnumerable<UserModel> GetUsers()
        {
            XDocument doc = XDocument.Load(XMLUri);

            return doc.Descendants("UserModels").Elements("UserModel").Select(s => new UserModel() { 
                Id = int.Parse(s.Element("Id").Value), FirstName = s.Element("FirstName").Value, LastName = s.Element("LastName").Value }).ToList();
        }

        public void UpdateUser(UserModel userModel)
        {
            var validationContext = new ValidationContext(userModel, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(userModel, validationContext, validationResults);

            if (isValid)
            {
                XDocument doc = XDocument.Load(XMLUri);

                var userModelItems = doc.Descendants("UserModels").Elements("UserModel").Where(w => w.Element("Id").Value == userModel.Id.ToString()).Select(s => s);

                foreach (XElement item in userModelItems)
                {
                    item.SetElementValue("FirstName", userModel.FirstName);
                    item.SetElementValue("LastName", userModel.LastName);
                }

                doc.Save(XMLPath);
            }
            else
            {
                // Log an error
            }
        }

        public void SaveUser(UserModel userModel)
        {
            var validationContext = new ValidationContext(userModel, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(userModel, validationContext, validationResults);

            if (isValid)
            {
                XDocument doc = XDocument.Load(XMLUri);

                var userModelItems = doc.Element("UserModels");

                userModelItems.Add(
                    new XElement("UserModel",
                        new XElement("Id", userModel.Id),
                        new XElement("FirstName", userModel.FirstName),
                        new XElement("LastName", userModel.LastName)
                        )
                    );

                doc.Save(XMLPath);
            }
            else
            {
                // Log an error
            }
        }

        public void DeleteUser(int id)
        {
            XDocument doc = XDocument.Load(XMLUri);

            doc.Descendants("UserModels").Elements("UserModel").Where(w => w.Element("Id").Value == id.ToString()).Remove();

            doc.Save(XMLPath);
        }
    }
}
