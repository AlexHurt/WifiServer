namespace WifiServer
{
    public static class WifiFactory
    {
        private static WifiConnectionContext db;

        public static WifiConnectionContext GetContext()
        {
            return db ?? (db = new WifiConnectionContext());
        }
    }
}