namespace CompositeValidationAttributeExample
{
    public class Person
    {
        [Name]
        public string Name { get; set; }

        [Email]
        public string EmailAddress { get; set; }
    }
}
