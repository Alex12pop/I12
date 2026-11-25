Probe.Run();
Experiments.Run();

// Hero yaroslav = new Hero("Ярослав", 100);
// Hero anastasia = new Hero("Анастасия", 90);
// Hero artem = new Hero("Артём", 120);
// Hero alexander = new Hero("   Александр   ", 150);
// Hero sergey = new Hero("Сергей", 110);

// alexander.TakeDamage(10);
// alexander.Heal(10);

// Guild guild = new Guild("Гильдия героев");
// guild.Heroes.Add(yaroslav);
// guild.Heroes.Add(anastasia);
// guild.Heroes.Add(artem);
// guild.Heroes.Add(alexander);
// guild.Heroes.Add(sergey);

// Console.WriteLine($">>> {guild.Name}: перекличка <<<");
// Console.WriteLine($"Участников: {guild.Heroes.Count}");

// if (guild.Heroes.Count > 0) {
//     Console.WriteLine($"Первый: {guild.Heroes[0].Name}");
//     Console.WriteLine($"Последний: {guild.Heroes[guild.Heroes.Count - 1].Name}");
// }

// Console.WriteLine();
// foreach (Hero hero in guild.Heroes) {
//     Console.WriteLine(hero.GetInfo());
//     Console.WriteLine();
// }

// int strongCount = 0;
// foreach (Hero hero in guild.Heroes) {
//     if (hero.Health >= 120) {
//         strongCount += 1;
//     }
// }
// Console.WriteLine($"Могут нести тяжёлые ящики (здоровье от 120): {strongCount}");

// if (guild.Heroes.Count > 0) {
//     Hero strongest = guild.Heroes[0];
//     foreach (Hero hero in guild.Heroes) {
//         if (hero.Health > strongest.Health) {
//             strongest = hero;
//         }
//     }
//     Console.WriteLine($"Самый здоровый: {strongest.Name} ({strongest.Health})");
// }

// // ===== Личный проект: «Библиотека» =====
// Console.WriteLine();
// Console.WriteLine("=== Личный проект: библиотека ===");

// Book warAndPeace = new Book("Война и мир", "Лев Толстой", 1225, 650);
// Book masterAndMargarita = new Book("  Мастер и Маргарита  ", "Михаил Булгаков", 480, 520);
// Book crimeAndPunishment = new Book("Преступление и наказание", "Фёдор Достоевский", 592, 380);

// Library library = new Library("Городская библиотека");
// library.Books.Add(warAndPeace);
// library.Books.Add(masterAndMargarita);
// library.Books.Add(crimeAndPunishment);

// Book twelveChairs = new Book("Двенадцать стульев", "Илья Ильф и Евгений Петров", 400, 310);
// library.Books.Add(twelveChairs);

// Console.WriteLine($">>> {library.Name}: каталог <<<");
// Console.WriteLine($"Книг: {library.Books.Count}");

// if (library.Books.Count > 0) {
//     Console.WriteLine($"Первая: {library.Books[0].Title}");
//     Console.WriteLine($"Последняя: {library.Books[library.Books.Count - 1].Title}");
// }

// Console.WriteLine();
// foreach (Book book in library.Books) {
//     Console.WriteLine(book.GetInfo());
//     Console.WriteLine();
// }

// int expensiveCount = 0;
// foreach (Book book in library.Books) {
//     if (book.Price > 500) {
//         expensiveCount += 1;
//     }
// }
// Console.WriteLine($"Книг дороже 500 руб.: {expensiveCount}");

// warAndPeace.Wear(25);
// Console.WriteLine($"Состояние «Войны и мира» через переменную: {warAndPeace.Condition}");
// Console.WriteLine($"Состояние «Войны и мира» через список: {library.Books[0].Condition}");
