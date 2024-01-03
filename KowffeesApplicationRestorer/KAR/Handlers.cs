namespace KAR
{
    internal static class Handlers
    {
        internal static async Task<bool> InitSetup()
        {
            try
            {
                Directory.CreateDirectory("KARInstalls");
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}
