namespace Globaltec.Models
{
    //Modelo de dados dos usuários
    //Apenas em memória, informações não serão persistidas
    //Dados de login no respositório UserRepository.cs
    public class User
    {
        public int Id {get; set;}

        public string Username {get; set;}

        public string Password {get; set;}

        public string Role {get; set;}
    }
}