using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace ElasticsearchSampleWebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController1 : ControllerBase
    {
        /// <summary>
        /// 创建索引
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("创建索引")]
        public void CreateIndex()
        {
            var client = ElasticSearchHelper.GetClient("user");
            client.CreateIndex<user>(typeof(user).Name);
        }

        /// <summary>
        /// 删除索引
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("删除索引")]
        public void DeleteIndex()
        {
            var client = ElasticSearchHelper.GetClient("user");
            client.DeleteIndex<user>(typeof(user).Name);
        }

        /// <summary>
        /// 批量
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("增加字段")]
        public void AddField()
        {
            var client = ElasticSearchHelper.GetClient("user");
            var res = client.Indices.PutMapping<user>
                (d => d
                .Properties(ps => ps
                .Text(s => s
                //.Name("testText4").SearchAnalyzer("english").Analyzer("english"))
                .Name("testText6").SearchAnalyzer("icu_analyzer").Analyzer("icu_analyzer"))
              ));
        }
    }

    [ElasticsearchType(IdProperty = "Id")]  
    public class user
    {
        [Keyword]
        public int Id { get; set; }
        [Keyword]
        public string Name { get; set; }
        [Keyword]
        public int Code { get; set; }
        [Keyword]
        public int MobileNo { get; set; }
        [Keyword]
        public DateTime Birthday { get; set; }
        [Keyword]
        public string CreateDate { get; set; }
    }
}
