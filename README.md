# webapi-globaltec
@author: Paulo Franco Machado
@email: francomachado@gmail.com

###### ARQUITETURA #######
WebApi desenvolvida com:
   - Asp.net Core 3.1 
   - C#
   - Entity Framework
   - Jwt Bearer (autenticação)
   - Banco de dados em memória

Ps.: Pode ser que seja necessário instalar o seguinte pacote:
dotnet add package Microsoft.EntityFrameworkCore.InMemory

###### DOCUMENTAÇÃO #######
A API foi documentada utilizando Swagger. Para ver a lista de APIs, acesse:
http://localhost:/swagger/

###### IMPORTANTE #########
- O banco de dados é em memória. As informações de usuário estão contidas em DataContext.cs
- A chave mestra de autenticação está em Controllers Settings.cs

##### API`s com JSON ######

# Login
POST
Rota: /v1/globaltec/auth/login

Envio: Body
{"username":"anakin","password":"skywalker"}
{"username":"obiwan","password":"kenobi"}

Resposta: Retorna o Token

# Valida autenticação
GET
Rota: /v1/globaltec/auth/login

Envio: Header
Authorization = "bearer " + [token]

Retorna: Confirmação que usuário está logado

# Cadastra usuário
POST
Rota: /v1/globaltec/pessoa

Envio: Header
Authorization = "bearer " + [token]

Envio: Body
{"Nome":"xxxxxxxx","CPF":"99999999999","UF":"GO","DataNascimento":"1986-06-06"}

Retorno: usuário cadastrado


# Consulta todos os usuários
Get
Rota: /v1/globaltec/pessoa

Envio: Header
Authorization = "bearer " + [token]

Retorno: todos os usuários cadastrados (para aquela sessão no banco de dados em memória)


# Consulta por código
Get
Rota: /v1/globaltec/pessoa/codigo/{codigo}

Envio: Header
Authorization = "bearer " + [token]

Retorna: usuário filtrando pelo código informado


# Consulta por UF
Get
Rota: /v1/globaltec/pessoa/uf/{uf}

Envio: Header
Authorization = "bearer " + [token]

Retorno: usuário filtrando pela UF informada

# Update usuário
Post
Rota: /v1/globaltec/pessoa/update/{codigo}

Envio: Header
Authorization = "bearer " + [token]

Envio: body
{"Nome":"Santo Amaro","CPF":"44444444444","UF":"RJ","DataNascimento":"1986-05-06"}
(Todos os dados do usuário exceto o código)

Retorno: dados do usuário atualizado

# Delete usuário
Post
Rota: /v1/globaltec/pessoa/delete/{codigo}

Envio: Header
Authorization = "bearer " + [token]

Retorno: mensagem de registro do usuário apagado com sucesso



