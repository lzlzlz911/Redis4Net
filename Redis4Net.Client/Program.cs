namespace Redis4Net.Client{
    #region Using
    using System;
    using System.Collections.Generic;

    using ServiceStack.Redis;

    #endregion

    internal class Program{

        private static void Main(string[] args){

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            RedisClient redis = new RedisClient("127.0.0.1", 6379); //redis服务IP和端口

            /*List<string> storeMembers = new List<string>(){"one", "two", "three"};
            storeMembers.ForEach(x => Redis.AddItemToList("lilist", x));

            var members = Redis.GetAllItemsFromList("lilist");
            members.ForEach(s => Console.WriteLine($"additemtolist:{s}"));*/

            /*List<User> userList = new List<User>();

            User user1 = new User{UAddress ={CityName = "city1"}};
            userList.Add(user1);

            User user2 = new User{UAddress ={CityName = "city2"}};
            userList.Add(user2);

            User user3 = new User{UAddress ={CityName = "city3"}};
            userList.Add(user3);

            User user4 = new User{UAddress ={CityName = "city4"}};
            userList.Add(user4);

            User user5 = new User{UAddress ={CityName = "city5"}};
            userList.Add(user5);

            redis.Set("userlist", userList);*/

            List<User> readUserList = redis.Get<List<User>>("userlist");
            readUserList.ForEach(
                user =>{
                    Console.WriteLine($"username:{user.Name}");
                    Console.WriteLine($"streetname:{user.UAddress.StreetName}");
                    Console.WriteLine($"ciryname:{user.UAddress.CityName}");
                });

            Console.ReadLine();
        }

        public class User{

            public string Name { get; set; } = "user-name";

            public Address UAddress { get; set; } = new Address();

        }

        public class Address{

            public string StreetName { get; set; } = "address-street";

            public string CityName { get; set; }

        }

    }

}