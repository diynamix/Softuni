﻿namespace MilitaryElite.Models.Contracts
{
    using MilitaryElite.Models.Enums;

    public interface IMission
    {
        string CodeName { get; }
        State State { get; }

        void CompleteMission();
    }
}
