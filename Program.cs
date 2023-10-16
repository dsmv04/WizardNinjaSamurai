using System;

class Human
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Health { get; set; }
     
    public Human(string name, int str, int intel, int dex, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        Health = hp;
    }
     
    public virtual int Attack(Human target)
    {
        int dmg = Strength * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
}

class Wizard : Human
{
    public Wizard(string name) : base(name, 3, 25, 3, 50) { }

    public override int Attack(Human target)
    {
        int damage = 3 * Intelligence;
        target.Health -= damage;
        Health += damage;
        Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage and healed for {damage} health!");
        return target.Health;
    }

    public void Heal(Human target)
    {
        int healing = 3 * Intelligence;
        target.Health += healing;
        Console.WriteLine($"{Name} healed {target.Name} for {healing} health!");
    }
}

class Ninja : Human
{
    public Ninja(string name) : base(name, 3, 3, 75, 100) { }

    public override int Attack(Human target)
    {
        int damage = Dexterity;
        if (new Random().Next(1, 6) == 1)
        {
            damage += 10;
        }

        target.Health -= damage;
        Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
        return target.Health;
    }

    public void Steal(Human target)
    {
        target.Health -= 5;
        Health += 5;
        Console.WriteLine($"{Name} stole 5 health from {target.Name}!");
    }
}

class Samurai : Human
{
    public Samurai(string name) : base(name, 3, 3, 3, 200) { }

    public override int Attack(Human target)
    {
        if (target.Health < 50)
        {
            target.Health = 0;
        }
        else
        {
            base.Attack(target);
        }
        Console.WriteLine($"{Name} attacked {target.Name}!");
        return target.Health;
    }

    public void Meditate()
    {
        Health = 200;
        Console.WriteLine($"{Name} meditated and healed to full health!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Wizard wizard = new Wizard("Gandalf");
        Ninja ninja = new Ninja("Ryu");
        Samurai samurai = new Samurai("Kenshin");

        Human target = new Human("Enemy", 3, 3, 3, 100);

        wizard.Attack(target);
        wizard.Heal(wizard);
        ninja.Attack(target);
        ninja.Steal(target);
        samurai.Attack(target);
        samurai.Meditate();
    }
}
