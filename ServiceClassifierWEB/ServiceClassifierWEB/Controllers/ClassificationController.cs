using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.ML;
using ClassifierPrototypeML.Model;

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
        private void Prepare(ref string text)
        {
            text = text.Replace("ё", "е");
            text = System.Text.RegularExpressions.Regex.Replace(text, @"((www\.[^\s]+)|(https?://[^\s]+))", " ");
            text = System.Text.RegularExpressions.Regex.Replace(text, @"[^a-zA-Zа-яА-Я1-9]+", " ");
            text = System.Text.RegularExpressions.Regex.Replace(text, @"[ ]+", " ");
            text = text.Trim();
            text = text.ToLower();
        }
        private string Process(string input)
        {
            string output = String.Empty;
            Prepare(ref input);
            if (String.IsNullOrEmpty(input))
            {
                output = "Neutral!";
            }
            else
            {
                var load = new ModelInput
                {
                    Col0 = input
                };
                var result = Pool.Predict(load);
                if (Math.Abs(result.Score[0] - result.Score[1]) <= 0.15)
                {
                    output = "Neutral!";
                }
                else if (result.Prediction == "-1 ")
                {
                    output = "Negative!";
                }
                else if (result.Prediction == "1 ")
                {
                    output = "Positive";
                }
            }
            return output;
            
        }

        [HttpGet]
        public ActionResult<string> Go([FromBody] string inputText)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string output = Process(inputText);
            return Ok(output);
        }

    }
}
