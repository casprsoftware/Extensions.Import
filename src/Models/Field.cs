namespace CASPR.Extensions.Import
{
    public class Field
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public FieldDataType DataType { get; set; }
        public bool IsRequired { get; set; }
    }
}