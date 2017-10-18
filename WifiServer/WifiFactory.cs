namespace WifiServer
{
    public static class WifiFactory
    {
        private static WifiConnectionContext _db;

        public static WifiConnectionContext GetContext()
        {
            return _db ?? (_db = new WifiConnectionContext());
        }
    }
}