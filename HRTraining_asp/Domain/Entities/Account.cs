using System;

namespace HRTraining.Domain.Entities
{
    public class Account : EntityBase
    {
        public virtual string Username { get; set; }
        public virtual string HashedPassword { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime? DateLastSignedIn { get; set; }
    }
}
