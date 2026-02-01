using static AnimeParams;

public class Ganster2Controller : PlayerController
{

    protected override void _attack()
    {
        if (_attacking)
            return;
        _attacking = true;
        animator.SetTrigger(Attack);
    }


}
