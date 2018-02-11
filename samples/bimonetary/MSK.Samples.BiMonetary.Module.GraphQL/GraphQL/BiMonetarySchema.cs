using GraphQL.Types;

namespace MSK.Samples.BiMonetary.Module.GraphQL.GraphQL
{
    public class BiMonetarySchema : Schema
    {
        public BiMonetarySchema()
        {
            Query = new BiMonetaryQuery();
            Mutation = new BiMonetaryMutation();
            Subscription = new BiMonetarySubscriptions();
        }    
    }
}