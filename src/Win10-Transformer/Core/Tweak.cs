using System;

namespace Win10_Transformer.Core
{
    public class Tweak
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Action Apply { get; set; }
        public Action Revert { get; set; }
        public bool IsApplied { get; set; }

        public Tweak(string name, string description, Action apply, Action revert)
        {
            Name = name;
            Description = description;
            Apply = apply;
            Revert = revert;
            IsApplied = false; // We can add logic to check the current state later
        }
    }
}
