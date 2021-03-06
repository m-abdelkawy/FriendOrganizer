﻿using Autofac;
using FriendOrganizer.DataAcess;
using FriendOrganizer.Infrastructure.Repositories;
using FriendOrganizer.Infrastructure.UnitOfWork;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModel;
using Prism.Events;

namespace FriendOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();
            //builder.RegisterType<FriendRepository>().As<IFriendRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<FriendOrganizerDbContext>().AsSelf();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();

            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();

            return builder.Build();
        }
    }
}
