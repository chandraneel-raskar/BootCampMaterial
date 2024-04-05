using System.ComponentModel.DataAnnotations;

namespace DesignPatternWkshp
{
        public sealed class Validator
        {
            private Validator() { }
            private static Validator instance=null;

                public static Validator getInstance()
                {
                    if (instance == null)
                    {
                        instance=new Validator();
                        return instance;
                    }
                    return instance;
                }

            public static OrderValidation()
            {
            // Order Validation Logic
                return null;
            }
            public static SiteValidation()
            {
                // Site Validation Logic
                return null;
            }
            
        }
    
}
