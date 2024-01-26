
public class AllServices
{
    private static AllServices _instance;

    public static AllServices Container => _instance ?? (_instance = new AllServices());

    public void Register<TService>(TService service) where TService : IService => 
        Implementation<TService>.ServiceInstance = service;

    public TService Single<TService>() where TService : IService =>
        Implementation<TService>.ServiceInstance;

    private class Implementation<TService> where TService : IService
    {
        public static TService ServiceInstance;
    }
}

