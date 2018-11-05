using Nancy;
using Newtonsoft.Json;
using PiyiServer.Server.DataModel;

namespace PiyiServer.Server
{
    public class InitialModule : NancyModule
    {
        public InitialModule()
        {
            Get["/Hello/{hello}"] = parameters =>
            {
                string hello = parameters.hello;
                return JsonConvert.SerializeObject(new ResultModel(new SingleStringModel(hello)));
            };

            Get["/mm"] = parameters =>
            {
                //return JsonConvert.SerializeObject(new ResultModel(new Result(hello)));
                return "i love u";
            };

            Get["/SetInnerStr/{Is}"] = parameters =>
            {
                //_innerStr = (string)parameters.Is;
                StaticData.Current.Sentence = (string)parameters.Is;
                return StaticData.Current.Sentence;
            };

            Get["/GetInnerStr"] = parameters =>
            {
                return StaticData.Current.Sentence + " yes";
                //return "gw";
            };
        }
    }
}
