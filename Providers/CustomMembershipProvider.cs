using System;
using System.Linq;
using System.Web.Security;
using CMT.Models;

namespace CMT.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        protected Storage mStorage;

        public CustomMembershipProvider()
        {
            mStorage = new Storage();
        }

        public CustomMembershipProvider(Storage userStorage)
        {
            mStorage = userStorage;
        }

        protected string GetConfigValue(string configValue, string defaultValue)
        {
            return String.IsNullOrEmpty(configValue) ? defaultValue : configValue;
        }

        public MembershipCreateStatus CreateUser(string username, string password, string email)
        {
            try
            {
                var user = new User
                {
                    UserName = username,
                    Password = mStorage.EncryptPassword(password),
                    Email = email
                };

                mStorage.CreateUser(user);

                return MembershipCreateStatus.Success;
            }
            catch (Exception)
            {
                return MembershipCreateStatus.ProviderError;
            }
        }
        
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            status = CreateUser(username, password, email);

            return status == MembershipCreateStatus.Success ? GetUser(username, false) : null;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            var user = mStorage.GetUser(u => u.UserName == username);

            return user != null ? user.Password : null;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                if (username == mStorage.GetCurrentUser().UserName)
                {
                    mStorage.ChangePassword(new ChangePasswordModel { NewPassword = newPassword, OldPassword = oldPassword });

                    return true;
                }
            }
            catch (Exception)
            {
            }

            return false;
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var user = mStorage.GetUser(u => u.UserName == username && u.Password == mStorage.EncryptPassword(password));

            return user != null && !user.Deleted;
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            return GetMembershipUser(mStorage.GetUser(u => u.Id == (int)providerUserKey));
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return GetMembershipUser(mStorage.GetUser(u => u.UserName == username));
        }

        public MembershipUser GetMembershipUser(User user)
        {
            return new MembershipUser("CustomMembershipProvider", user.UserName, user.Id, user.Email, "", "", true,
                                            false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
        }

        public override string GetUserNameByEmail(string email)
        {
            return mStorage.GetUser(u => u.Email == email).UserName;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            try
            {
                mStorage.DeleteUser(username);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            var collection = new MembershipUserCollection();
            var users = mStorage.GetUsers(pageIndex, pageSize);

            totalRecords = users.Count();

            foreach (var user in users)
            {
                collection.Add(GetMembershipUser(user));
            }

            return collection;
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            var collection = new MembershipUserCollection();

            var users = mStorage.GetUsers(pageIndex, pageSize).Where(u => u.UserName.Contains(usernameToMatch));
            totalRecords = users.Count();

            foreach (var user in users)
            {
                collection.Add(GetMembershipUser(user));
            }

            return collection;
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            var collection = new MembershipUserCollection();

            var users = mStorage.GetUsers(pageIndex, pageSize).Where(u => u.Email.Contains(emailToMatch));
            totalRecords = users.Count();

            foreach (var user in users)
            {
                collection.Add(GetMembershipUser(user));
            }

            return collection;
        }

        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }

        public override bool EnablePasswordReset
        {
            get { return false; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 0; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 0; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 0; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return ""; }
        }
    }
}