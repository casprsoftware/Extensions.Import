using System;
using System.Collections.Generic;
using System.Linq;

namespace CASPR.Extensions.Import.Services
{
    public class InMemoryImportProfileStorage : IImportProfileStorage
    {
        public InMemoryImportProfileStorage(ICollection<ImportProfile> importProfiles)
        {
            ImportProfiles = importProfiles ?? throw new ArgumentNullException(nameof(importProfiles));
        }

        public InMemoryImportProfileStorage() : this(new List<ImportProfile>())
        {
        }

        public ICollection<ImportProfile> ImportProfiles { get; set; }

        public ImportProfile GetImportProfile(string name)
        {
            return ImportProfiles.FirstOrDefault(p => p.Name == name);
        }
    }
}