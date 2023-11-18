using Microsoft.AspNetCore.Mvc;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using System.Diagnostics;
using YetGenAkbankJump.MVCClient.Models;
using OpenAI.Interfaces;

namespace YetGenAkbankJump.MVCClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IOpenAIService _openAiService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_openAiService = openAIService;
        }

        /*public IActionResult Index()
        {

            return View(new HomeIndexViewModel());
        }*/

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeIndexViewModel viewModel)
        {
            /*var imageResult = await _openAiService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = viewModel.Prompt,
                N = viewModel.ImageCount,
                Size = StaticValues.ImageStatics.Size.Size512,
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                User = "Mr. Bülüç"
            });


            if (imageResult.Successful)
            {
                viewModel.ImageUrls = imageResult.Results.Select(r => r.Url).ToList();
            }
            else
            {
                Console.WriteLine(imageResult.Error.Message);
            }*/

            /*var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
    {
        ChatMessage.FromUser(viewModel.Prompt),
    },
                Model = OpenAI.ObjectModels.Models.Gpt_3_5_Turbo,
                MaxTokens = 4000//optional
            });
            if (completionResult.Successful)
            {
                viewModel.ChatGPTResponse = completionResult.Choices.First().Message.Content;
            }
            else
            {
                viewModel.ChatGPTResponse = completionResult.Error.Messages.ToString();
            }*/

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}