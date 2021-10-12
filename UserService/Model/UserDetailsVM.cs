namespace UserService.Model
{
    using System.Collections.Generic;
    using UserService.ViewModel;

    public class UsersDetailsVM
    {
        public List<UserDetailsVM> UsersList { get; set; }
        public List<DelegationVM> delegations { get; set; }
        public List<TagPatientDetails> tagPatientDetails { get; set; }
    }
}
