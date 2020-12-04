using Integrador.HubSpot.Rest.Base;
using Integrador.HubSpot.Rest.Models.Get;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Integrador.HubSpot.Rest
{
    public class RestPipeline : RestBase
    {
        /// <summary>
        /// Recupera todos os pipelines existentes no ambiente
        /// </summary>
        /// <returns></returns>
        public List<PipelineModelGet> RecuperarTodosOsPipelines()
        {
            var endpoint = $"{base.UrlBase}/deals/v1/pipelines?hapikey={base.HapiKey}";
            var model = base.GetAll<PipelineModelGet>(endpoint).ToList();
            return model;
        }

        /// <summary>
        /// Recupera todos os dealstage de um determinado pipeline
        /// </summary>
        /// <param name="pipelineId"></param>
        /// <returns></returns>
        public PipelineStageModelGet RecuperarPipelineComDealStages(string pipelineId)
        {
            var endpoint = $"{base.UrlBase}/deals/v1/pipelines/{pipelineId}?hapikey={base.HapiKey}";
            var model = base.Get<PipelineStageModelGet>(endpoint);
            return model;
        }
    }
}
