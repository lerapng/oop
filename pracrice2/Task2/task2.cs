using System;

class DamageEventArgs : EventArgs
{
    public int Damage { get; }
    public int CurrentHP { get; }
    public DamageEventArgs(int damage, int currentHP)
    {
        Damage = damage;
        CurrentHP = currentHP;
    }
}

class Player
{
    public event EventHandler<DamageEventArgs> DamageReceived;

    private int _hp;
    public int HP => _hp;

    public Player(int hp) => _hp = hp;

    public void TakeDamage(int damage)
    {
        _hp = Math.Max(0, _hp - damage);
        DamageReceived?.Invoke(this, new DamageEventArgs(damage, _hp));
    }
}

class UIHealthBar
{
    public void OnDamageReceived(object sender, DamageEventArgs e)
    {
        Console.WriteLine($"[HealthBar] HP: {e.CurrentHP}");
    }
}

class SoundSystem
{
    public void OnDamageReceived(object sender, DamageEventArgs e)
    {
        Console.WriteLine("[SoundSystem] Звук отримання урону");
        if (e.CurrentHP <= 20)
            Console.WriteLine("[SoundSystem] Звук критичного стану!");
    }
}

class AchievementSystem
{
    private bool _halfHealthGiven = false;
    private bool _firstDeathGiven = false;

    public void OnDamageReceived(object sender, DamageEventArgs e)
    {
        if (e.CurrentHP <= 50 && !_halfHealthGiven)
        {
            Console.WriteLine("[Achievements] Досягнення отримано: \"Half Health\"");
            _halfHealthGiven = true;
        }
        if (e.CurrentHP <= 0 && !_firstDeathGiven)
        {
            Console.WriteLine("[Achievements] Досягнення отримано: \"First Death\"");
            _firstDeathGiven = true;
        }
    }
}

class GameLogger
{
    public void OnDamageReceived(object sender, DamageEventArgs e)
    {
        Console.WriteLine($"[Logger] Отримано урон: -{e.Damage}, поточне HP: {e.CurrentHP}");
    }
}

class Program
{
    static void Main()
    {
        Player player = new Player(100);
        UIHealthBar healthBar = new UIHealthBar();
        SoundSystem sound = new SoundSystem();
        AchievementSystem achievements = new AchievementSystem();
        GameLogger logger = new GameLogger();

        player.DamageReceived += healthBar.OnDamageReceived;
        player.DamageReceived += sound.OnDamageReceived;
        player.DamageReceived += achievements.OnDamageReceived;
        player.DamageReceived += logger.OnDamageReceived;

        int[] damages = { 20, 35, 15, 20, 30 };

        foreach (int dmg in damages)
        {
            Console.WriteLine($"\n--- Гравець отримує {dmg} урону ---");
            player.TakeDamage(dmg);
        }
    }
}