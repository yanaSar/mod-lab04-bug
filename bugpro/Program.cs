using Stateless;
namespace BugPro
{

public class Bug 
{
    public enum State 
    {
        NewDefected,
        RazborDefectoved,
        NeedMoreInfoed,
        NoVosproizvodimoed,
        Returned,
        Ispravlenied,
        ProblemaReshenaed,
        Closed,
        PereOpened
    }

    public enum Action 
    {
        RazborDefectov,
        NeedMoreInfo,
        NoVosproizvodimo,
        Return,
        Ispravlenie,
        ProblemaReshena,
        Close,
        PereOpene
    }

    public StateMachine<State, Action> _machine;

    public Bug(State initialState = State.NewDefected) 
    {
        _machine = new StateMachine<State, Action>(initialState);

        ConfigureMachine();
    }

    private void ConfigureMachine() 
    {
        _machine.Configure(State.NewDefected)
            .Permit(Action.RazborDefectov, State.RazborDefectoved);

        _machine.Configure(State.RazborDefectoved)
            .Permit(Action.NeedMoreInfo, State.NeedMoreInfoed)
            .Permit(Action.NoVosproizvodimo, State.NoVosproizvodimoed)
            .Permit(Action.Ispravlenie, State.Ispravlenied);

        _machine.Configure(State.NeedMoreInfoed)
            .Permit(Action.RazborDefectov, State.RazborDefectoved)
            .Permit(Action.Ispravlenie, State.Ispravlenied);

        _machine.Configure(State.NoVosproizvodimoed)
            .Permit(Action.Close, State.Closed)
            .Permit(Action.Return, State.Returned);

        _machine.Configure(State.Returned)
            .Permit(Action.RazborDefectov, State.RazborDefectoved);

        _machine.Configure(State.Ispravlenied)
            .Permit(Action.ProblemaReshena, State.ProblemaReshenaed);

        _machine.Configure(State.ProblemaReshenaed)
            .Permit(Action.Close, State.Closed)
            .Permit(Action.Return, State.Returned);

        _machine.Configure(State.Closed)
            .Permit(Action.PereOpene, State.PereOpened);

        _machine.Configure(State.PereOpened)
            .Permit(Action.RazborDefectov, State.RazborDefectoved);
    }
 
    public static void Main()
    {
        var bug = new Bug();
        Console.WriteLine($"Initial State: {bug._machine.State}");

        bug._machine.Fire(Action.RazborDefectov);
        Console.WriteLine($"Current State: {bug._machine.State}");

        bug._machine.Fire(Action.NeedMoreInfo);
        Console.WriteLine($"Current State: {bug._machine.State}");

        bug._machine.Fire(Action.Ispravlenie);
        Console.WriteLine($"Current State: {bug._machine.State}");

        bug._machine.Fire(Action.ProblemaReshena);
        Console.WriteLine($"Current State: {bug._machine.State}");

        bug._machine.Fire(Action.Close);
        Console.WriteLine($"Current State: {bug._machine.State}");
    }
}
}
