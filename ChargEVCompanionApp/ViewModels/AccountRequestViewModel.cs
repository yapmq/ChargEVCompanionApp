using ChargEVCompanionApp.Models;
using ChargEVCompanionApp.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChargEVCompanionApp.ViewModels
{
    public class AccountRequestViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Users> RequestList { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Users> ApproveCommand { get; }

        public AccountRequestViewModel()
        {
            Title = "Account Approval";

            RequestList = new ObservableRangeCollection<Users>();

            RefreshCommand = new AsyncCommand(Refresh);
            ApproveCommand = new AsyncCommand<Users>(Approve);
            Initialize();
        }

        async Task Approve(Users user)
        {
            if (user == null)
            {
                return;
            }
            else
            {
                user.IsActive = true;
                await UserService.Update(user);
            }
                
           
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            RequestList.Clear();
            var requests = await UserService.GetRequests();
            RequestList.AddRange(requests);

            IsBusy = false;
        }

        public async void Initialize()
        {
            await Refresh();
        }
    }
}
