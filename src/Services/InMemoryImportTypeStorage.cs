using System;
using System.Collections.Generic;
using System.Linq;

namespace CASPR.Extensions.Import.Services
{
    public class InMemoryImportTypeStorage : IImportTypeStorage
    {
        public InMemoryImportTypeStorage(ICollection<ImportType> importTypes)
        {
            ImportTypes = importTypes ?? throw new ArgumentNullException(nameof(importTypes));
        }

        public InMemoryImportTypeStorage() : this(new List<ImportType>())
        {
        }

        public ICollection<ImportType> ImportTypes { get; set; }

        public ImportType GetImportType(string name)
        {
            return ImportTypes.FirstOrDefault(it => it.Name == name);
        }
    }
}