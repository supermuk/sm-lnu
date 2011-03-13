using System;
using System.Web.Security;

namespace CMT.Providers
{
    public class CustomMembershipUser : MembershipUser
    {
        public CustomMembershipUser(string providerName,
            string name,
            object providerUserKey,
            string email,
            string passwordQuestion,
            string comment,
            bool isApproved,
            bool isLockedOut,
            DateTime creationDate,
            DateTime lastLoginDate,
            DateTime lastActivityDate,
            DateTime lastPasswordChangedDate,
            DateTime lastLockoutDate)
            : base(providerName,
            name,
            providerUserKey,
            email,
            passwordQuestion,
            comment,
            isApproved,
            isLockedOut,
            creationDate,
            lastLoginDate,
            lastActivityDate,
            lastPasswordChangedDate,
            lastLockoutDate
            )
        {
        }
    }
}