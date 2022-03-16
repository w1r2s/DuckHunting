using System;
using System.Collections.Generic;

namespace DuckHunting
{
  abstract class Ducks
  {

    Random random = new Random();

    public string type;
    public string name;
    public int weight;
    public bool canRun = true;
    public bool knowHome = false;
    public string home;


    public virtual bool Swim() { return false; }
    public virtual bool Crawl() { return false; }

    public virtual bool Run() { return false; }

    public virtual bool Hide() { return false; }
    public virtual bool Fly() { return false; }
    public virtual bool Migrate() { return false; }

    public void RunAway(Ducks duck, Lakes lake, Lakes farm)
    {
      if (canRun)
      {
        farm.ducks.Remove(duck);
        lake.ducks.Add(duck);
        canRun = false;
      }
    }

    public virtual void Voice()
    {
      Console.WriteLine($"Меня зовут {name}.");
      Console.WriteLine($"Я - {type}");
      if (home != null) Console.WriteLine($"Мой дом - {home}.");
      else Console.WriteLine("Я не знаю где мой дом!");
    }
  }
  class Lakes
  {
    public string name;
    public bool wild;
    public List<Ducks> ducks = new List<Ducks>();
    public List<Hunters> hunters = new List<Hunters>();
    public bool Protect = false;
    public bool end = false;

    public Lakes(string name, bool wild)
    {
      this.name = name;
      this.wild = wild;
    }
    public void Info()
    {
      if (ducks != null)
      {
        int swim = 0; int crawl = 0; int hide = 0;
        int fly = 0; int run = 0; int mig = 0;

        foreach (var duck in ducks)
        {
          if (duck != null)
          {
            if (duck.Swim()) swim++;
            if (duck.Crawl()) crawl++;
            if (duck.Fly()) fly++;
            if (duck.Hide()) hide++;
            if (duck.Migrate()) mig++;
            if (duck.Run()) run++;
          }
        }
          if (wild) { Console.WriteLine($"Имя озера: {name}"); }
          else { Console.WriteLine($"Имя фермы: {name}"); }
        Console.WriteLine($"Кол-во уток: {ducks.Count}");
        Console.WriteLine($"Уток, умеющих :\n Плавать: {swim}\n Ползать {crawl}\n Летать {fly}\n" +
          $" Прятаться {hide}\n Мигрировать {mig}\n Бегать {run}");
        Console.WriteLine();
      }
      else  Console.WriteLine($"На {name} нет уток.\r\n");
    }

    public void Check()
    {
      if (ducks.Count <= 1) end = true;
      if (ducks.TrueForAll(x => x.type == "Гоголи")) end = true;
     
    }
  }

  class Hunters
  {
    public int catchMin;
    public int catchMax;
    public string name;

    public Hunters(string name, int catchMin, int catchMax)
    {
      this.catchMin = catchMin;
      this.catchMax = catchMax;
      this.name = name;
    }

    
    public void Hunt(Lakes lake, Lakes farm)
    {
      Random rn = new Random();
      int x;
      if (catchMin <= lake.ducks.Count)
      {
        while (true)
        {
          x = rn.Next(catchMin, catchMax + 1);
          if (x <= lake.ducks.Count) break;
        }

        int i = 0;
        while (i != x)
        {
          int j = rn.Next(0, lake.ducks.Count);
          Ducks duck = lake.ducks[j];
          if (duck.Hide() == false)
          {
            lake.ducks.Remove(duck);
            farm.ducks.Add(duck);
          }
          i++;
        }
      }
    }
  }
  class Spatula_Discors : Ducks
  {
    // живёт на первом озере
    public int pawSize;
    public int lenght;

    Random random = new Random();

    // Атрибуты утки
    public Spatula_Discors()
    {
      type = "Голубокрылый чирок";
      weight = random.Next(200, 600);
      pawSize = random.Next(4, 8);
      lenght = random.Next(20, 50);
    }
    // Способность утки
    public override bool Swim()
    {
      return true;
    }

    // утка рассказывает о себе
    public override void Voice()
    {
      base.Voice();
      Console.WriteLine($"Я умею плавать.");
      Console.WriteLine($"Мой вес {weight} г.");
      Console.WriteLine($"Я {lenght} см в длинну.");
      Console.WriteLine($"Мои лапки {pawSize} размера.");
      Console.WriteLine($"Меня можно узнать по синему зеркальцу на крыльях и желтым лапкам.");

    }
  }

  class Aythya : Ducks
  {
    // живёт на первом озере

    public int lenght;
    public int health;
    public string fdish;



    Random random = new Random();

    // Атрибуты утки
    public Aythya()
    {
      type = "Чернети";
      weight = random.Next(400, 800);
      lenght = random.Next(30, 50);
      health = random.Next(1, 100);
      fdish = DishChoise(random.Next(1, 4));
    }
    // Способность утки
    public override bool Run()
    {
      return true;
    }

    // Утка рассказывает о себе
    public override void Voice()
    {
      base.Voice();
      Console.WriteLine($"Я умею хорошо бегать.");
      Console.WriteLine($"Мой вес {weight} г.");
      Console.WriteLine($"Я {lenght} см в длинну.");
      Console.WriteLine($"У меня {health} ед. здоровья.");
      Console.WriteLine($"Моё любимое блюдо {fdish}.");
    }
    private string DishChoise(int x)
    {
      switch (x)
      {
        case 1:
          return "Насекомые";
        case 2:
          return "Мелкие рачки";
        case 3:
          return "Стебли и семена растений";
        case 4:
          return "Зерно";

      }
      return "";
    }
  }

  class Bucephala : Ducks
  {
    // живёт на первом озере
    public int tailSize;
    public int lenght;


    Random random = new Random();


    // Атрибуты утки
    public Bucephala()
    {
      type = "Гоголи";
      weight = random.Next(500, 1000);
      lenght = random.Next(40, 60);
      tailSize = random.Next(5, 10);

    }
    // Способность утки
    public override bool Hide()
    {
      return true;
    }

    // Утка рассказывает о себе
    public override void Voice()
    {
      base.Voice();
      Console.WriteLine($"Я умею прятаться.");
      Console.WriteLine($"Мой вес {weight} г.");
      Console.WriteLine($"Я {lenght} см в длинну.");
      Console.WriteLine($"Мой хвост {tailSize} размера.");
      Console.WriteLine($"У меня оранжевые лапки с тёмными перепонками.");
    }
  }

  class Bucephala2 : Ducks
  {
    // живёт на втором озере
    
    public int beakSize;
    public int lenght;


    Random random = new Random();

    // Атрибуты утки
    public Bucephala2()
    {
      type = "Гоголи";
      weight = random.Next(500, 1000);
      lenght = random.Next(40, 60);
      beakSize = random.Next(2, 5);

    }
    // Способность утки
    public override bool Hide()
    {
      return true;
    }

    // Утка рассказывает о себе
    public override void Voice()
    {
      base.Voice();
      Console.WriteLine($"Я умею прятаться.");
      Console.WriteLine($"Мой вес {weight} г.");
      Console.WriteLine($"Я {lenght} см в длинну.");
      Console.WriteLine($"Мой клюв {beakSize} размера.");
      Console.WriteLine($"У меня чёрно-бурые крылья с большим белым зеркальцем.");
    }
  }

  class Tadorna : Ducks
  {
    // живёт на втором озере
    
    public int tailSize;
    public int lenght;
    public int wings;

    Random random = new Random();

    // Атрибуты утки
    public Tadorna()
    {
      type = "Пеганки";
      weight = random.Next(600, 1600);
      tailSize = random.Next(4, 8);
      lenght = random.Next(50, 70);
      wings = random.Next(100, 140);
    }
    // Способность утки
    public override bool Migrate()
    {
      return true;
    }

    // утка рассказывает о себе
    public override void Voice()
    {
      base.Voice();
      Console.WriteLine($"Я умею мигрировать.");
      Console.WriteLine($"Мой вес {weight} г.");
      Console.WriteLine($"Я {lenght} см в длинну.");
      Console.WriteLine($"Мой хвост {tailSize} размера.");
      Console.WriteLine($"Мой размах крыльев {wings} см.");

    }
  }

  class Marmaronetta_Angustirostris : Ducks
  {
    // живет на втором озере
   
    public int high;
    public int lenght;
    public int pawSize;
    Random random = new Random();

    // Атрибуты утки
    public Marmaronetta_Angustirostris()
    {
      type = "Мраморный чирок";
      knowHome = true;
      home = "Киву";
      weight = random.Next(300, 600);
      high = random.Next(15, 25);
      lenght = random.Next(25, 45);
      pawSize = random.Next(4, 8);
    }
    // Способность утки
    public override bool Fly()
    {
      return true;
    }

    // утка рассказывает о себе
    public override void Voice()
    {
      base.Voice();
      Console.WriteLine($"Я умею летать.");
      Console.WriteLine($"Мой вес {weight} г.");
      Console.WriteLine($"Я {lenght} см в длинну.");
      Console.WriteLine($"Я {high} см в высоту.");
      Console.WriteLine($"Мои лапки {pawSize} размера.");

    }
  }

  class Netta : Ducks
  {
    // живёт на третьем озере
    public int agility;
    public int lenght;


    Random random = new Random();

    // Атрибуты утки
    public Netta()
    {
      type = "Нырки";
      weight = random.Next(500, 1200);
      agility = random.Next(1, 50);
      lenght = random.Next(40, 60);
    }
    // Способность утки
    public override bool Swim()
    {
      return true;
    }

    // утка рассказывает о себе
    public override void Voice()
    {
      base.Voice();
      Console.WriteLine($"Я умею плавать.");
      Console.WriteLine($"Мой вес {weight} г.");
      Console.WriteLine($"Я {lenght} см в длинну.");
      Console.WriteLine($"У меня {agility} eд. ловкости.");
      Console.WriteLine($"Мои крылья без зеркальца.");

    }
  }

  class Tadorna1 : Ducks
  {
    // живёт на третьем озере 
    public int strength;
    public int lenght;


    Random random = new Random();

    // Атрибуты утки
    public Tadorna1()
    {
      type = "Пеганки";
      weight = random.Next(600, 1600);
      strength = random.Next(1, 50);
      lenght = random.Next(50, 70);

    }
    // Способность утки
    public override bool Crawl()
    {
      return true;
    }

    // утка рассказывает о себе
    public override void Voice()
    {
      base.Voice();
      Console.WriteLine($"Я умею мигрировать.");
      Console.WriteLine($"Мой вес {weight} г.");
      Console.WriteLine($"Я {lenght} см в длинну.");
      Console.WriteLine($"Мой хвост {strength} размера.");
      Console.WriteLine($"Мои перья крыльев внешней стороны предплечья черные, внутренней — белые. Подхвостье оранжево-рыжее.");

    }

  }

  class Lophonetta_specularioides : Ducks
  {
    // живёт на третьем озере
    public int strength;
    public int lenght;
    public int wings;



    Random random = new Random();

    // Атрибуты утки
    public Lophonetta_specularioides()
    {
      type = "Хохлатая утка";
      weight = random.Next(500, 800);
      strength = random.Next(1, 50);
      lenght = random.Next(40, 50);
      wings = random.Next(60, 72);
    }
    // Способность утки
    public override bool Crawl()
    {
      return true;
    }

    // утка рассказывает о себе
    public override void Voice()
    {
      base.Voice();
      Console.WriteLine($"Я умею плавать.");
      Console.WriteLine($"Мой вес {weight} г.");
      Console.WriteLine($"Я {lenght} см в длинну.");
      Console.WriteLine($"У меня {strength} eд. силы.");
      Console.WriteLine($"Мой размах крыльев {wings} см.");

    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      Random rn = new Random();
      int n = 93;
      // распределение по озёрам

      int L1 = rn.Next(1, n / 2); 
      int L2 = rn.Next(1, (n - L1) / 2); 
      int L3 = n - L1 - L2; 

      Lakes lake1 = new Lakes("Матано", true);
      Lakes lake2 = new Lakes("Киву", true);
      Lakes lake3 = new Lakes("Аргентино", true);

      List<Lakes> lakesum = new List<Lakes> { lake1, lake2, lake3 };

      Lakes farm1 = new Lakes("DIJOWAHY", false);


      List<Ducks> ducksSum = new List<Ducks>(); 

      // 1-е озеро
      for (int i = 0; i < L1; i++)
      {
        lake1.ducks.Add(Chose(rn.Next(1, 4)));
        lake1.ducks[i].name = $"Утка_{i + 1}";
      }
      // 2-е озеро
      for (int i = 0; i < L2; i++)
      {
        lake2.ducks.Add(Chose(rn.Next(4, 7)));
        lake2.ducks[i].name = $"Утка_{L1 + i + 1}";
      }
      //  3-е озеро
      for (int i = 0; i < L3; i++)
      {
        lake3.ducks.Add(Chose(rn.Next(7, 10)));
        lake3.ducks[i].name = $"Утка_{n - L3 + i + 1}";
      }

      ducksSum.AddRange(lake1.ducks);
      ducksSum.AddRange(lake2.ducks); 
      ducksSum.AddRange(lake3.ducks);

      // заполнение фермы
      farm1.hunters.Add(new Hunters("#1", 2, 11));
      farm1.hunters.Add(new Hunters("#2", 3, 11));

      int start = 0;
      while (!lakesum.TrueForAll(x => x.end))
      {
        int cmd = 0;
        while (true)
        {
          Console.WriteLine("1 - информация о месте \t2 - обратиться к утке \t3 - сезона охоты (9 дней)\n");
          Console.Write("Выберите команду: ");
          Console.ForegroundColor = ConsoleColor.Blue;
          if (Int32.TryParse(Console.ReadLine(), out int x) && (x < 4 && x > 0))
          {
            cmd = x;
            Console.ResetColor();
            break;
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nНекорректный ввод");
            Console.ResetColor();
          }

          Console.ReadLine();
          Console.Clear();
        }
        Console.WriteLine();
        Command(cmd);

        if (cmd == 3)
        {
          int days = 1;
          while (days <= 9)
          {
            Console.Clear();
            Console.WriteLine("\t\t\t-----Сезон охоты-----\n");

            Console.WriteLine($"День {days}\n-----\n");

           
            if (!lakesum.TrueForAll(x => x.end))
            {
              Lakes lakeHunt;
              while (true)
              {
                lakeHunt = FL(rn.Next(1, 4));
                if (lakeHunt.ducks.Count != 0) break;
              }
              for (int i = 0; i < farm1.hunters.Count; i++) { farm1.hunters[i].Hunt(lakeHunt, farm1); } 

              
              if ((farm1.ducks.Count > 0) && start != 0)
              {
                int col = 0;
                foreach (var duck in farm1.ducks.ToArray())
                {
                  if (duck.Swim() && duck.knowHome == false && duck.canRun == true)
                  {
                    duck.RunAway(duck, FL(rn.Next(1, 4)), farm1);
                    col++;
                  }
                }
                int f1 = col;
                if (f1 > 0) Console.WriteLine($"Сбежавших с фермы {farm1.name}: {f1}\n");
                else Console.WriteLine($"С фермы { farm1.name} никто не убежал\n");
                col = 0;
              }
              farm1.Info();
              lake1.Info(); lake1.Check();
              lake2.Info(); lake2.Check();
              lake3.Info(); lake3.Check();
              Console.ReadLine();
            }
            else
            {
              Console.WriteLine("Всех утрок поймали!");
              Console.ReadLine();
              days += 10;
            }
            start++;
            days++;
          }
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("...Нажмите ENTER для продолжения...");
        Console.ResetColor();
        Console.ReadLine();
        Console.Clear();
      }
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("\t\t---Игра закончена---\n");
      Console.ResetColor();
      Console.ReadKey();

      // выбор команды
      void Command(int x)
      {
        switch (x)
        {
          case 1:
            Console.WriteLine("1 - озеро Матано, 2 - озеро Киву, 3 - озеро Аргентино, 4 - ферма DIJOWAHY");
            Console.ForegroundColor = ConsoleColor.Blue;
            int cmd = Int32.Parse(Console.ReadLine());
            Console.ResetColor();
            Console.WriteLine();
            FL(cmd).Info();
            break;
          case 2:
            OneDuck();
            Console.WriteLine();
            break;
          case 3:
            break;
        }
      }

      // выбор озера
      Lakes FL(int x)
      {
        switch (x)
        {
          case 1:
            return lake1;
          case 2:
            return lake2;
          case 3:
            return lake3;
          case 4:
            return farm1;
        }
        return lake1;
      }

      // поисе определенной утки
      void OneDuck()
      {
        Console.Write("Введите имя утки (Например 'Утка_5'): ");
        Console.ForegroundColor = ConsoleColor.Blue;
        string name = Console.ReadLine();
        Console.ResetColor();
        Console.WriteLine();

        ducksSum[ducksSum.FindIndex(x => x.name == name)].Voice();
      }

      // Выбор типа утки
      Ducks Chose(int x)
      {
        Ducks duck = null;
        switch (x)
        {
          case 1:
            duck = new Spatula_Discors();
            break;
          case 2:
            duck = new Aythya();
            break;
          case 3:
            duck = new Bucephala();
            break;
          case 4:
            duck = new Bucephala2();
            break;
          case 5:
            duck = new Tadorna();
            break;
          case 6:
            duck = new Marmaronetta_Angustirostris();
            break;
          case 7:
            duck = new Netta();
            break;
          case 8:
            duck = new Tadorna1();
            break;
          case 9:
            duck = new Lophonetta_specularioides();
            break;
        }
        return duck;
      }
    }
  }
}
  
