using System.Collections.Generic;
using LibApp.Models;
using System.Threading.Tasks;

namespace LibApp.Interfaces
 {
    //Methods
     public interface IMembershipTypeActions
     {
        //Methods
        IEnumerable<MembershipType> GetMsTs();
        MembershipType GetMsTById(int id);
        void Delete(int id);
        void Add(MembershipType MsT);
        void Update(MembershipType MsT);
        void Save();

    //AsyncedMethods
        Task<IEnumerable<MembershipType>> GetMsTsAsync();
        Task<MembershipType> GetMsTByIdAsync(int id);
        Task DeleteAsync(int id);
        Task AddAsync(MembershipType MsT);
        Task UpdateAsync(MembershipType MsT);
        Task SaveAsync();
     }
 }