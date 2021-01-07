using Autofac;
using FriendOrganizer.DataAcess;
using FriendOrganizer.Infrastructure.Repositories;
using FriendOrganizer.Infrastructure.UnitOfWork;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModel;

namespace FriendOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();
            //builder.RegisterType<FriendRepository>().As<IFriendRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<FriendOrganizerDbContext>().AsSelf();

            return builder.Build();
        }
    }
}
