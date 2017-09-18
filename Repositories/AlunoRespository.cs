
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
    public class AlunoRepository
    {
        public async Task<IList<AlunoViewModel>> GetAluno()
        {
            using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) })
            {
                string response = await httpClient.GetStringAsync(
                    string.Format("{0}/aluno", "http://controleacademico-env.bpea3squex.us-east-2.elasticbeanstalk.com"));
                return JsonConvert.DeserializeObject<IList<AlunoViewModel>>(response);
            }
        }

        public async Task<int> GetBolsaEnem()
        {
            using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) })
            {
                string response = await httpClient.GetStringAsync(
                    string.Format("{0}/bolsaEnem", "http://controleacademico-env.bpea3squex.us-east-2.elasticbeanstalk.com"));
                return Convert.ToInt32(response);
            }
        }

        public async Task<string> SaveAluno(AlunoViewModel aluno)
        {
            using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) })
            {
                string postData = JsonConvert.SerializeObject(aluno);
                var postContent = new StringContent(postData, Encoding.UTF8, "application/json");
                var post = await httpClient.PostAsync(string.Format("{0}/aluno/gravar", "http://controleacademico-env.bpea3squex.us-east-2.elasticbeanstalk.com"), postContent);

                return await post.Content.ReadAsStringAsync();
            }
        }
    }
}