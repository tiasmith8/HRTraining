using System;

namespace HRTraining_asp.Domain.Entities
{
    public class AccountModel
    {
        public Guid? ID { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastSignedIn { get; set; }
    }
}
