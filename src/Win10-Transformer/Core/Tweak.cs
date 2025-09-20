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

        public string Category
        {
            get
            {
                if (Name.Contains(':'))
                {
                    return Name.Split(':')[0];
                }
                return "General";
            }
        }

        public string DisplayName
        {
            get
            {
                if (Name.Contains(':'))
                {
                    return Name.Split(':')[1].Trim();
                }
                return Name;
            }
        }

        public Tweak(string name, string description, Action apply, Action revert)
        {
            Name = name;
            Description = description;
            Apply = apply;
            Revert = revert;
            IsApplied = false;
        }
    }
}
