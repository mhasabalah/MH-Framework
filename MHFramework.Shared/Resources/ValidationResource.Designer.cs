namespace MHFramework.Shared.Resources
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ValidationResource
    {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationResource() { }

        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MHFramework.Shared.Resources.ValidationResource", typeof(ValidationResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture
        {
            get => resourceCulture;
            set => resourceCulture = value;
        }
        public static string GreaterThan => ValidationResource.ResourceManager.GetString(nameof(GreaterThan), ValidationResource.resourceCulture);

        public static string GreaterThanOrEqualTo => ValidationResource.ResourceManager.GetString(nameof(GreaterThanOrEqualTo), ValidationResource.resourceCulture);

        public static string IsRequired => ValidationResource.ResourceManager.GetString(nameof(IsRequired), ValidationResource.resourceCulture);

        public static string Length => ValidationResource.ResourceManager.GetString(nameof(Length), ValidationResource.resourceCulture);

        public static string LessThan => ValidationResource.ResourceManager.GetString(nameof(LessThan), ValidationResource.resourceCulture);

        public static string LessThanOrEqualTo => ValidationResource.ResourceManager.GetString(nameof(LessThanOrEqualTo), ValidationResource.resourceCulture);

        public static string MaximumLength => ValidationResource.ResourceManager.GetString(nameof(MaximumLength), ValidationResource.resourceCulture);

        public static string WrongEmailFormat => ValidationResource.ResourceManager.GetString(nameof(WrongEmailFormat), ValidationResource.resourceCulture);

        public static string WrongFieldMessage => ValidationResource.ResourceManager.GetString(nameof(WrongFieldMessage), ValidationResource.resourceCulture);
    }
}
