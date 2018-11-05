using Nancy;

namespace PiyiServer.Server
{
    public class InitialModule:NancyModule
    {
        public InitialModule()
        {
            Get["/Hello/{hello}"] = parameters =>
            {
                string hello = parameters.hello;
                //return JsonConvert.SerializeObject(new ResultModel(new Result(hello)));
                return hello + "lkfw";
            };

            Get["/mm"] = parameters =>
            {
                //return JsonConvert.SerializeObject(new ResultModel(new Result(hello)));
                return "i love u";
            };
        }
    }
}
