using System;
using System.Dynamic;
using System.Linq;
using ModelDBContext;
using hotel;

namespace lab3_ipz
{
    class Program
    {
        static void TestLaba3()
        {
            Hotel h = new Hotel();

            InfoDiscription info1 = new InfoDiscription(Guid.NewGuid(), "Room odin. Oshen' krasivay komnat!!Mamoy klyanus", 1000, 2);
            InfoDiscription info2 = new InfoDiscription(Guid.NewGuid(), "Room dwa. Bomzh komnata nichego net odni steni", 100, 3);
            InfoDiscription info3 = new InfoDiscription(Guid.NewGuid(), "Hall odin. Ochen' balshoy. Mnogo-mnogo vleset", 5000, 75);

            Room r1 = new Room(Guid.NewGuid(), info1);
            Client client1 = new Client(Guid.NewGuid(), "Pup", "Vasyachkin", "Volosatovich", "fff", "232fgh".GetHashCode(), h);

            h.Sudo.AddAdmin(Guid.NewGuid(), "Arkadiy", "Petrovich", "Vsesilkin", "Admin", "3333".GetHashCode(), h, AccessLevel.Master);

            h.AddHall(Guid.NewGuid(), info3);
            h.AddRoom(Guid.NewGuid(), info1);
            h.AddRoom(Guid.NewGuid(), info2);
            h.AddClient(Guid.NewGuid(), "Pup", "Vasyachkin", "Volosatovich", "fff", "232fgh".GetHashCode(), h);

            h.AddRquisites(new Requisites(Guid.NewGuid(), "Hotel", "PrivatBank",
                "3244364734", "658434342", "32545512"));

            client1.AddReservation(new Reservation(Guid.NewGuid(), r1,
                new DateTime(2016, 5, 20), 20));
            client1.PayCart();

            YaVisitor v = new YaVisitor();

            v.Visit(h);
        }

        private static void TestLaba4()
        {
            using (HotelDbContext db = new HotelDbContext())
            {
                // создаем два объекта User
                InfoDiscription info1 = new InfoDiscription(Guid.NewGuid(),
                    "Room odin. Oshen' krasivay komnat!!Mamoy klyanus", 1000, 2);

               // Room r1 = new Room(Guid.NewGuid(), info1);

                db.InfoDiscriptions.Add(info1);
                // добавляем их в бд
//                db.Rooms.Add(r1);
                db.SaveChanges();

                var query = from b in db.InfoDiscriptions orderby b.id select b;

                foreach (InfoDiscription discription in query)
                {
                    Console.WriteLine(discription);
                }
                Console.WriteLine("Объекты успешно сохранены");
                Console.ReadLine();

                // получаем объекты из бд и выводим на консоль
//                var users = db.Users;
//                Console.WriteLine("Список объектов:");
//                foreach(User u in users)
//                {
//                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
//                }
            }
        }

        static void Main ( string [ ] args )
        {
            TestLaba4();
        }
    }
}
