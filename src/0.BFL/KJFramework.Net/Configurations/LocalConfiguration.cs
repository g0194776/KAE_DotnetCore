using KJFramework.Attribute;
namespace KJFramework.Net.Configurations
{
    [CustomerSection("KJFramework")]
    public sealed class LocalConfiguration 
    {
        #region Members.

        /// <summary>
        ///     �����������
        /// </summary>
        [CustomerField("KJFramework.Net")] public NetworkLayerConfiguration NetworkLayer;

        #endregion

    }
}