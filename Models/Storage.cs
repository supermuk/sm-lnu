using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CMT.Models
{
    public class Storage
    {
        private DatabaseDataContext GetDB()
        {
            return new DatabaseDataContext();
        }

        #region Users

        public int CreateUser(User user)
        {
            var db = GetDB();

            user.Administrator = false;
            user.Created = DateTime.Now;
            user.DisplayName = user.UserName;
            user.Wins = 0;
            user.Losses = 0;
            user.Drafts = 0;
            user.Rating = 0;

            db.Users.InsertOnSubmit(user);
            
            db.SubmitChanges();

            return user.Id;
        }

        public User GetUser(Func<User, bool> predicate)
        {
            return GetDB().Users.SingleOrDefault(predicate);
        }

        public IEnumerable<User> GetUsers(int pageIndex, int pageSize)
        {
            var db = GetDB();

            return db.Users.Skip(pageIndex).Take(pageSize);
        }

        public User GetCurrentUser()
        {
            if (HttpContext.Current.User == null)
            {
                return null;
            }

            var identity = HttpContext.Current.User.Identity;

            if (!identity.IsAuthenticated)
            {
                return null;
            }

            return GetDB().Users.SingleOrDefault(u => u.UserName == identity.Name);
        }

        public void DeleteUser(string userName)
        {
            var db = GetDB();

            var user = db.Users.Single(u => u.UserName == userName);
            user.Deleted = true;

            db.SubmitChanges();
        }

        public string EncryptPassword(string password)
        {
            var provider = new SHA1CryptoServiceProvider();
            var bytes = Encoding.UTF8.GetBytes(password);
            return BitConverter.ToString(provider.ComputeHash(bytes)).Replace("-", "");
        }

        public void ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var db = GetDB();

            var user = GetCurrentUser();
            user.Password = EncryptPassword(changePasswordModel.NewPassword);

            db.SubmitChanges();
        }

        #endregion

        #region Champ

        public int CreateChamp(Champ champ)
        {
            var db = GetDB();

            champ.CreatedBy = GetCurrentUser().Id;
            champ.Created = DateTime.Now;

            db.Champs.InsertOnSubmit(champ);
            db.SubmitChanges();

            return champ.Id;
        }

        public Champ GetChamp(Func<Champ, bool> predicate)
        {
            return GetDB().Champs.Where(c => c.Deleted == false).FirstOrDefault(predicate);
        }

        public IEnumerable<Champ> GetChamps()
        {
            return GetDB().Champs.Where(c => c.Deleted == false).AsEnumerable();
        }

        public void DeleteChamp(int id)
        {
            var db = GetDB();

            var champ = db.Champs.Single(c => c.Id == id);
            champ.Deleted = true;

            db.SubmitChanges();
        }
        
        public void UpdateChamp(Champ champ)
        {
            var db = GetDB();

            var newChamp = db.Champs.Single(c => c.Id == champ.Id);
            newChamp.Name = champ.Name;

            db.SubmitChanges();
        }

        #endregion
    }
}