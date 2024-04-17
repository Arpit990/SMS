using SpeakerManagementSystem.DatabaseContext;
using SpeakerManagementSystem.Models;
using SpeakerManagementSystem.Repository.Interface;

namespace SpeakerManagementSystem.Repository
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        #region Constructor
        public OrganizationRepository(SpeakerMgmtDbContext context) : base(context) { }
        #endregion
    }
}
