namespace MultiShop.WebUI.Settings
{
    public class ClientSetings
    {
        public Client MultiShopVisitorClient { get; set; }
        public Client MultiShopManagerClient { get; set; }
        public Client MultiShopAdminClient { get; set; }

    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
      
    }
}
