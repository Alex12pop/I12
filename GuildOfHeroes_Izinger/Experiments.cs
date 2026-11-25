// Эксперименты ПР №4: пробы, трассировка, «две ошибки» и дополнительная часть.

public static class Experiments {
    public static void Run() {
        Console.WriteLine("##### ПР №4: эксперименты #####");
        ReferencesNotCopies();
        DuplicateRecords();
        Trace();
        Mistake1IndexOutOfRange();
        Mistake2Copy();
        ExtraEmptyAndTwoGuilds();
        ExtraAboveAverage();
    }

    private static void Header(string text) {
        Console.WriteLine();
        Console.WriteLine($"--- {text} ---");
    }

    // Этап 6: список хранит ссылки, а не копии
    private static void ReferencesNotCopies() {
        Header("Этап 6: ссылки, а не копии");

        Hero probeHero = new Hero("Учебная проба", 100);
        List<Hero> probeList = new List<Hero>();
        probeList.Add(probeHero);

        probeHero.TakeDamage(20);

        Console.WriteLine($"Через переменную: {probeHero.Health}");
        Console.WriteLine($"Через список: {probeList[0].Health}");
        Console.WriteLine($"Элементов: {probeList.Count}");
    }

    // Этап 9: что private set защищает, а что нет (строка с CS0272 удалена)
    private static void DuplicateRecords() {
        Header("Этап 9: private set и повторная запись");

        Guild probeGuild = new Guild("Учебная гильдия");
        Hero probeWarrior = new Hero("Учебный воин", 150);

        probeGuild.Heroes.Add(probeWarrior);
        probeGuild.Heroes.Add(probeWarrior);
        Console.WriteLine($"Записей: {probeGuild.Heroes.Count}");

        probeWarrior.TakeDamage(30);
        foreach (Hero hero in probeGuild.Heroes) {
            Console.WriteLine($"{hero.Name}: {hero.Health}");
        }
    }

    // Этап 10: трассировка
    private static void Trace() {
        Header("Этап 10: трассировка");

        Guild traceGuild = new Guild("Трассировка");
        Hero first = new Hero("Первый", 100);
        Hero second = new Hero("Второй", 80);

        traceGuild.Heroes.Add(first);
        traceGuild.Heroes.Add(second);
        traceGuild.Heroes.Add(first);

        first.TakeDamage(30);

        Console.WriteLine(traceGuild.Heroes.Count);
        Console.WriteLine(traceGuild.Heroes[2].Health);
        foreach (Hero hero in traceGuild.Heroes) {
            Console.WriteLine($"{hero.Name}: {hero.Health}");
        }
        Console.WriteLine(traceGuild.Heroes[traceGuild.Heroes.Count - 2].Name);
    }

    // Этап 11, ошибка 1: количество принято за последний индекс
    private static void Mistake1IndexOutOfRange() {
        Header("Этап 11, ошибка 1: Count вместо Count - 1");

        Guild guild = new Guild("Гильдия героев");
        guild.Heroes.Add(new Hero("Ярослав", 100));
        guild.Heroes.Add(new Hero("Анастасия", 90));
        guild.Heroes.Add(new Hero("Артём", 120));
        guild.Heroes.Add(new Hero("Александр", 150));
        guild.Heroes.Add(new Hero("Сергей", 110));

        try {
            if (guild.Heroes.Count > 0) {
                Console.WriteLine(guild.Heroes[guild.Heroes.Count].Name);
            }
        } catch (ArgumentOutOfRangeException) {
            Console.WriteLine("ArgumentOutOfRangeException: индекс Count выходит за границу списка");
        }

        if (guild.Heroes.Count > 0) {
            Console.WriteLine($"Исправлено: {guild.Heroes[guild.Heroes.Count - 1].Name}");
        }
    }

    // Этап 11, ошибка 2: в список положили копию
    private static void Mistake2Copy() {
        Header("Этап 11, ошибка 2: копия вместо ссылки");

        Hero probeHero = new Hero("Учебная проба", 100);
        List<Hero> probeList = new List<Hero>();
        probeList.Add(new Hero(probeHero.Name, probeHero.Health));
        probeHero.TakeDamage(20);
        Console.WriteLine($"С копией: {probeHero.Health} и {probeList[0].Health}");

        Hero fixedHero = new Hero("Учебная проба", 100);
        List<Hero> fixedList = new List<Hero>();
        fixedList.Add(fixedHero);
        fixedHero.TakeDamage(20);
        Console.WriteLine($"Исправлено: {fixedHero.Health} и {fixedList[0].Health}");
    }

    // Д.1: пустая гильдия и две гильдии
    private static void ExtraEmptyAndTwoGuilds() {
        Header("Д.1: пустая гильдия и две гильдии");

        Guild firstGuild = new Guild("Первая учебная гильдия");
        Guild emptyGuild = new Guild("Пустая учебная гильдия");
        Hero sharedHero = new Hero("Общий учебный герой", 100);
        firstGuild.Heroes.Add(sharedHero);

        Console.WriteLine($"В пустой гильдии: {emptyGuild.Heroes.Count}");
        int passes = 0;
        foreach (Hero hero in emptyGuild.Heroes) {
            Console.WriteLine(hero.Name);
            passes += 1;
        }
        Console.WriteLine($"Проходов цикла по пустой гильдии: {passes}");

        emptyGuild.Heroes.Add(sharedHero);
        Console.WriteLine($"В первой: {firstGuild.Heroes.Count}, во второй: {emptyGuild.Heroes.Count}");
        Console.WriteLine($"Один и тот же список: {object.ReferenceEquals(firstGuild.Heroes, emptyGuild.Heroes)}");
        Console.WriteLine($"Один и тот же герой: {object.ReferenceEquals(firstGuild.Heroes[0], emptyGuild.Heroes[0])}");

        sharedHero.TakeDamage(10);
        Console.WriteLine($"Здоровье через первую: {firstGuild.Heroes[0].Health}, через вторую: {emptyGuild.Heroes[0].Health}");
    }

    // Д.2: здоровее среднего
    private static void ExtraAboveAverage() {
        Header("Д.2: здоровее среднего");

        Guild guild = new Guild("Гильдия героев");
        guild.Heroes.Add(new Hero("Ярослав", 100));
        guild.Heroes.Add(new Hero("Анастасия", 90));
        guild.Heroes.Add(new Hero("Артём", 120));
        guild.Heroes.Add(new Hero("Александр", 150));
        guild.Heroes.Add(new Hero("Сергей", 110));

        if (guild.Heroes.Count > 0) {
            int sum = 0;
            foreach (Hero hero in guild.Heroes) {
                sum += hero.Health;
            }
            int average = sum / guild.Heroes.Count;

            int aboveAverage = 0;
            foreach (Hero hero in guild.Heroes) {
                if (hero.Health > average) {
                    aboveAverage += 1;
                }
            }

            Console.WriteLine($"Сумма: {sum}, среднее: {average}");
            Console.WriteLine($"Здоровее среднего: {aboveAverage}");
        }
    }
}
