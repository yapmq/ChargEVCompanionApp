using ChargEVCompanionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargEVCompanionApp.Services
{
    class MembershipServices
    {
        //public static async Task<Memberships> GetMembership()
        //{
        //    var membership = await App.MobileService.GetTable<Memberships>()
        //        .Where(m => m.IsActive == false)
        //        .Where(m => m.UserId == App.globaluser.Id)
        //        .ToListAsync();

        //    return membership;
        //}

        public static async Task<Memberships> IsMemberActive()
        {
            Memberships membership = (await App.MobileService.GetTable<Memberships>()
                .Where(m => m.IsActive == true)
                .Where(m => m.UserId == App.globaluser.Id)
                .ToListAsync()).FirstOrDefault();



            if (membership.EndTime != null)
            {
                if (DateTimeOffset.Now > membership.EndTime)
                {
                    membership.IsActive = false;

                    await App.MobileService.GetTable<Memberships>().UpdateAsync(membership);
                    Memberships updatedmembership = (await App.MobileService.GetTable<Memberships>()
                    .Where(m => m.IsActive == true)
                    .Where(m => m.UserId == App.globaluser.Id)
                    .ToListAsync()).FirstOrDefault();

                    return updatedmembership;

                }
                return membership;
            }
            return membership;
        }
    }
}
