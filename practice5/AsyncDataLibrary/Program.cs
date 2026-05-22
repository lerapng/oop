using AsyncDataLibrary.Infrastructure;
using AsyncDataLibrary.Models;
using AsyncDataLibrary.Repositories;
using AsyncDataLibrary.Services;

var serializer = new JsonDataSerializer();
var storage    = new FileStorageProvider("data");

var userRepo  = new JsonRepository<User>(storage, serializer);
var bookRepo  = new JsonRepository<Book>(storage, serializer);
var orderRepo = new JsonRepository<Order>(storage, serializer);

var userService  = new UserService(userRepo);
var bookService  = new BookService(bookRepo);
var orderService = new OrderService(orderRepo);

Console.WriteLine("Async Data Library demo\n");

await userService.AddAsync(new User { Name = "Олена Коіaль",   Email = "olena@example.com" });
await userService.AddAsync(new User { Name = "Сікс севен",  Email = "67@example.com" });

Console.WriteLine("Користувачі:");
foreach (var u in await userService.GetAllAsync()) Console.WriteLine($"[{u.Id}] {u.Name} — {u.Email}");

await bookService.AddAsync(new Book { Title = "Clean Code", Author = "Robert Martin", Price = 450, Stock = 10 });
await bookService.AddAsync(new Book { Title = "The Pragmatic Programmer", Author = "David Thomas", Price = 520, Stock = 5 });
await bookService.AddAsync(new Book { Title = "Design Patterns", Author = "Gang of Four",  Price = 380, Stock = 0 });

Console.WriteLine("\nКниги в наявності:");
foreach (var b in await bookService.GetInStockAsync())
    Console.WriteLine($"  [{b.Id}] {b.Title} — {b.Author} — {b.Price} грн (залишок: {b.Stock})");

await orderService.AddAsync(new Order { UserId = 1, BookId = 1, Quantity = 2 });
await orderService.AddAsync(new Order { UserId = 2, BookId = 2, Quantity = 1 });

Console.WriteLine("\nЗамовлення:");
foreach (var o in await orderService.GetAllAsync())
    Console.WriteLine($"  [{o.Id}] User#{o.UserId} Book#{o.BookId} x{o.Quantity} — {o.Status}");

await orderService.UpdateStatusAsync(1, OrderStatus.Processing);
Console.WriteLine("\nПісля оновлення статусу замовлення #1:");
var updated = await orderService.GetByIdAsync(1);
Console.WriteLine($"  Статус: {updated?.Status}");

var found = await userService.FindByEmailAsync("67@example.com");
Console.WriteLine($"\nПошук по email: {found?.Name ?? "не знайдено"}");

Console.WriteLine("\nДані збережено у папці /data");