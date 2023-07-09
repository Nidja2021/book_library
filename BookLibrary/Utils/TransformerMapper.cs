
namespace BookLibrary.Utils
{
    public static class TransformerMapper<TSource, TDestination>
    {
        public static TDestination Map(TSource source)
        {
            var destination = Activator.CreateInstance<TDestination>();

            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties
                    .FirstOrDefault(p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);

                if (destinationProperty != null)
                {
                    var value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }

            return destination;
        }
    }
}

