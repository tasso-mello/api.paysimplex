namespace domain.paysimplex.Enums
{
    using System.ComponentModel;
    public enum State
    {
        [Description("Agendada")]
        Scheduled = 1,
        [Description("Para Fazer")]
        ToDo = 2,
        [Description("Em Progresso")]
        InProgress = 3,
        [Description("Finalizada")]
        Done = 4
    }
}
