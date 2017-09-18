
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SCA.Models;

namespace SCA.Repositories
{
public class MatriculaRepository
{
        public async Task<IList<MatriculaViewModel>> GetMatricula()
        {
            using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) })
            {                
                string response = await httpClient.GetStringAsync(
                    string.Format("{0}/matricula", "http://controleacademico-env.bpea3squex.us-east-2.elasticbeanstalk.com"));
                return JsonConvert.DeserializeObject<IList<MatriculaViewModel>>(response);
            }
        }
        public async Task<string> SaveMatricula(MatriculaViewModel matricula)
        {
            using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) })
            {  
                string postData = JsonConvert.SerializeObject(matricula);
                var postContent = new StringContent(postData, Encoding.UTF8, "application/json");
                var post = await httpClient.PostAsync(string.Format("{0}/matricula/gravar", "http://controleacademico-env.bpea3squex.us-east-2.elasticbeanstalk.com"), postContent);
                
                return await post.Content.ReadAsStringAsync();
            }  
        }
}
}