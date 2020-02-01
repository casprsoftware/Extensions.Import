using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CASPR.Extensions.Import.Services;

namespace CASPR.Extensions.Import
{
    public abstract class ImportWorkerBase : IImportWorker
    {
        public async Task<ImportBatchResult> RunAsync(
            ImportWorkerContext context, 
            CancellationToken cancellationToken)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            
            var result = new ImportBatchResult();
            
            using (var stream = File.OpenRead(context.Batch.FileName))
            {
                using (var streamReader = new StreamReader(stream, Encoding.UTF8, true, 128))
                {
                    bool skipFirstRow = context.Profile.IsFirstRowHeading;
                    int rowIndex = -1;
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            //throw or skip??
                        }

                        rowIndex += 1;

                        if (skipFirstRow)
                        {
                            skipFirstRow = false;
                            continue;
                        }

                        var columns = ParseLine(line, context.Profile);
                        var row = MapColumns(columns, context.Profile);

                        var validationResult = await ValidateRowAsync(row, rowIndex);
                        if (validationResult != null)
                        {
                            result.Failures.Add(validationResult);
                            //todo log
                            continue;
                        }

                        await OnImportRowAsync(row, rowIndex);
                    }
                }
            }

            return result;
        }

        private ICollection<string> ParseLine(string line, ImportProfile importProfile)
        {
            var columns = line.Split(importProfile.FieldDelimiter);
            if (importProfile.TextQualifier != 0)
            {
                return columns
                    .Select(col => col.Trim(importProfile.TextQualifier))
                    .ToList();
            }

            return columns;
        }

        private IDictionary<string, object> MapColumns(ICollection<string> columns, ImportProfile importProfile)
        {
            var row = new Dictionary<string, object>();
            for (int i = 0; i < columns.Count; i++)
            {
                var columnValue = columns.ElementAt(i);
                var map = importProfile
                    .RecordDefinitions.First()
                    .FieldMappings
                    .FirstOrDefault(m => m.FieldDefinitionNumber == (i+1));

                if (map!=null)
                {
                    row.Add(map.FieldName, columnValue);
                }
            }

            return row;
        }

        protected ImportWorkerContext Context { get; set; }

        protected virtual Task<ImportBatchFailure> ValidateRowAsync(IDictionary<string, object> row, int rowIndex)
        {
            return Task.FromResult<ImportBatchFailure>(null);
        }

        protected abstract Task OnImportRowAsync(IDictionary<string, object> row, int rowIndex);
    }
}