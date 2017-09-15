
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
public class CursoRepository
{
        public async Task<IList<CursoViewModel>> GetCurso()
        {
            using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) })
            {                
                string response = await httpClient.GetStringAsync(
                    string.Format("{0}/curso", "http://localhost:8082"));
                return JsonConvert.DeserializeObject<IList<CursoViewModel>>(response);
            }
        }
        public async Task<string> SaveCurso(CursoViewModel curso)
        {
            using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) })
            {  
                string postData = JsonConvert.SerializeObject(curso);
                var postContent = new StringContent(postData, Encoding.UTF8, "application/json");
                var post = await httpClient.PostAsync(string.Format("{0}/curso/gravar", "http://localhost:8082"), postContent);
                
                return await post.Content.ReadAsStringAsync();
            }  
        }
}
}