using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassifierPrototypeML.Model;
using Microsoft.Extensions.ML;

namespace ServiceClassifierWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private readonly PredictionEnginePool<ModelInput, ModelOutput> Pool;
        public ClassificationController(PredictionEnginePool<ModelInput, ModelOutput> _Pool)
        {
            Pool = _Pool;
        }
        private void Preprocessing(ref string text)
        {
            //удаление из входной строки ссылок, лишних пробелов, символов и тд
            if (!String.IsNullOrEmpty(text))
            {
                text = text.Replace("ё", "е");
                text = System.Text.RegularExpressions.Regex.Replace(text, @"((www\.[^\s]+)|(https?://[^\s]+))", " ");
                text = System.Text.RegularExpressions.Regex.Replace(text, @"[^a-zA-Zа-яА-Я1-9]+", " ");
                text = System.Text.RegularExpressions.Regex.Replace(text, @"[ ]+", " ");
                text = text.Trim();
                text = text.ToLower();
            }
        }
        private async void Log(string log)
        {
            using (System.IO.StreamWriter loger = new System.IO.StreamWriter("log.txt", true, System.Text.Encoding.Default))
            {
                await loger.WriteLineAsync(log);
            }
        }
        private string Query(string input)
        {
            string result = String.Empty;
            Preprocessing(ref input);
            if (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input))
            {
                result = "Empty Query!";
            }
            var load = new ModelInput
            {
                Col0 = input
            };
            var modelOut = Pool.Predict(load);
            if (Math.Abs(modelOut.Score[0] - modelOut.Score[1]) <= 0.15)
            {
                result = "Neutral!";
            }
            else if (modelOut.Prediction == "-1 ")
            {
                result = "Negative!";
            }
            else if (modelOut.Prediction == "1 ")
            {
                result = "Positive!";
            }
            Log($"{input} - {result}");
            return result;

        }

        //Запрос в URL
        [HttpGet("urlquery/{input}")]
        public ActionResult<OutputData> GetFromURL(string input)
        {
            return (new OutputData { Output = Query(input) });
        }

        //Пустой запрос URL
        [HttpGet("urlquery")]
        public ActionResult<OutputData> GetEmptyURL()
        {
            return (new OutputData { Output = "Empty Query!" });
        }

        //Запрос через формат JSON

        [HttpGet("jsonquery")]
        public ActionResult<OutputData> GetFromJSON([FromBody] InputData inputJSON)
        {
            if (String.IsNullOrEmpty(inputJSON.Input))
            {
                return (new OutputData { Output = "Empty Query" });
            }
            else
            {
                return (new OutputData { Output = Query(inputJSON.Input) });
            }
        }
    }
}

