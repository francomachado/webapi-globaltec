using System.Collections.Generic;
using System.Linq;
using Globaltec.Models;

namespace Globaltec.Repositories
{
    public static class UserRepository
    {
        //Usuários simulados em memória
        //Conforme orientação do desafio, nenhuma informação foi persistida no banco
        //Criados dois usuários com diferentes Roles. Algumas rotas foram exclusivas do gerente.
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "obiwan", Password = "kenobi", Role = "Jedi"});
            users.Add(new User { Id = 2, Username = "anakin", Password = "skywalker", Role = "Padawan"});
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
