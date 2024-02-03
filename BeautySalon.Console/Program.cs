using System.Data;
using BeautySalon.DAL;
using BeautySalon.DAL.DTO;
using BeautySalon.DAL.IRepositories;
using BeautySalon.DAL.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BeautySalon.Console;

using System;

class Program
{
    static void Main(string[] args)
    {
        #region NotWorks

        //Не работает
        // IOrderRepository orderRepository = new OrderRepository();
        // var repositories = orderRepository.GetAllOrdersForClient();
        // foreach (var repository in repositories)
        // {
        //     Console.WriteLine($"{repository.Id} {repository.Date} {repository.ClientId} {repository.MasterId}");
        // }

        //Не работает
        // IUserRepository userRepository = new UserRepository();
        // var userRepositories = userRepository.GetAllEmployees();
        // foreach (var user in userRepositories)
        // {
        //     Console.WriteLine($"{user.Id} {user.Name} {user.Phone} {user.Mail} {user.Roles}");
        // }

        #endregion

        #region MyRegion

        //Работает
        // IUserRepository userRepository2 = new UserRepository();
        // var userRepositories2 = userRepository2.GetClientByNameAndId("Оксана Дмитриевна Кек", 4);
        // foreach (var user in userRepositories2)
        // {
        //     Console.WriteLine($"{user.ClientsId} {user.Client}");
        // }

        // //Работает
        // IUserRepository userRepository3 = new UserRepository();
        // var userRepositories3 = userRepository3.GetClientByNameAndPhone("Оксана Дмитриевна Кек", "877566588690");
        // foreach (var user in userRepositories3)
        // {
        //     Console.WriteLine($"{user.Name} {user.Phone}");
        // }
        
        //Работает
        // IUserRepository userRepository4 = new UserRepository();
        // userRepository4.AddUserByChatId(32423, "Janet342","Жанна Дарк", "8999324556", "jannet@mail.ru",3, 0,0,0);
        //
        
        IUserRepository userRepository5 = new UserRepository();
        var userRepositories5 = userRepository5.GetMasterByNameAndId("Анна Петровна Брек", 2);
        foreach (var user in userRepositories5)
        {
            Console.WriteLine($"{user.Master} {user.MasterId}");
        }
        
        //Работает
        // IIntervalsRepository intervalsRepository = new IntervalsRepository();
        // var intervalsRepositories = intervalsRepository.GetAllShiftsWithFreeIntervalsOnCurrentService(4);
        // foreach (var interval in intervalsRepositories)
        // {
        //      Console.WriteLine($"");
        // }
        // Console.WriteLine();
        // Console.ReadLine();

        #endregion
        
    }

    class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public int RoleId { get; set; }
    }
}