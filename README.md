# DesafioIBGE :envelope::earth_americas:

Este repositório contém a API que foi criada como parte do desafio para gerenciar dados de cidades e estados de todo o Brasil, baseada no conjunto de dados disponível no seguinte repositório: [ibge](https://github.com/andrebaltieri/ibge). A API foi desenvolvida com base no desafio proposto e possui as funcionalidades especificadas.

<br>

## Funcionalidades da API :gear:

A API desenvolvida contém as seguintes funcionalidades:

### Autenticação e Autorização :closed_lock_with_key:
- A API implementa um sistema de autenticação com token JWT para proteger as rotas da API. Os usuários podem se autenticar e receber um token JWT para acessar recursos protegidos.

### Cadastro de E-mail e Senha :e-mail:
- Os usuários podem se cadastrar na aplicação fornecendo um e-mail e senha.

### Login (Token, JWT) :key:
- Após o cadastro, os usuários podem fazer login para obter um token JWT, que é utilizado para autenticar nas rotas protegidas da API.

### CRUD de Localidade :pushpin:
- A API oferece operações CRUD para gerenciar localidades, incluindo a criação, leitura, atualização e exclusão de informações como código, estado e cidade.

### Pesquisa por Cidade e por Estado :round_pushpin:
- Os usuários podem realizar pesquisas de localidades com base no nome da cidade ou do estado.

### Pesquisa por Código (IBGE) :earth_americas:
- É possível pesquisar localidades com base no código IBGE correspondente.

### Boas práticas da API :ballot_box_with_check:
- A API segue boas práticas de desenvolvimento de APIs, como tratamento de erros, respostas consistentes, etc.

### Versionamento :hash:
- A API pode incluir versionamento, facilitando futuras atualizações sem quebrar a compatibilidade com as versões anteriores.

### Padronização :warning:
- O código da API segue convenções de nomenclatura e padronização, tornando-o legível e consistente.

### Documentação (Swagger) :green_circle:
- A API é documentada com o uso do Swagger, facilitando o uso e entendimento por parte dos desenvolvedores.

<br>

## Classificação das Equipes 

A classificação da sua equipe (Júnior, Pleno ou Sênior) é determinada pelo integrante mais experiente. Com base nisso, seu grupo deve seguir as entregas correspondentes:

### Júnior :baby:

- Implementar todas as funcionalidades base
- Usar .NET 7 ou superior
- Arquitetura: MVC ou Minimal APIs com estrutura de projeto simples
- Objetivo: Entregar uma API funcionando

### Pleno :man:

- Implementar todas as funcionalidades base
- Usar .NET 7 ou superior
- Arquitetura: Minimal APIs
- Incluir Testes de Unidade
- Objetivo: Entregar uma API funcionando, com boa arquitetura, organização, código limpo e testes de unidade.

### Sênior :older_man:

- Implementar todas as funcionalidades base
- Usar .NET 7 ou superior
- Arquitetura: Minimal APIs
- Incluir Testes de Unidade
- Implementar Funcionalidades Adicionais
- Objetivo: Entregar uma API funcionando, com boa arquitetura, organização, código limpo, testes de unidade e funcionalidades adicionais.

### Funcionalidades Adicionais (Sênior)

- Importação de Dados: Criar um endpoint para importar os dados a partir deste arquivo Excel: [SQL INSERTS - API de localidades IBGE.xlsx](https://github.com/andrebaltieri/ibge/blob/main/SQL%20INSERTS%20-%20API%20de%20localidades%20IBGE.xlsx).
- A API começará sem dados e os dados serão carregados via um endpoint que permita o upload do Excel.

<br>

## Rodando o Projeto :arrow_forward:

Para executar este projeto localmente, siga os passos abaixo:

1. Clone este repositório em sua máquina:

   ```bash
   git clone https://github.com/brenonsc/DesafioIBGE.git
   ```

2. Abra o projeto em sua IDE favorita, como o Visual Studio ou Visual Studio Code.

3. Execute o Docker Compose para configurar o ambiente. Na raiz do projeto, execute o seguinte comando:

   ```
   $ docker-compose up
   ```

4. Abra o arquivo `appsettings.json` no projeto e mude a variável de ambiente `"Environment":"Start"` para `"DEV"`. Isso configurará o ambiente para desenvolvimento.

5. Agora você está pronto para rodar o projeto localmente. Certifique-se de que seu ambiente de desenvolvimento esteja configurado corretamente e execute a aplicação.

6. Para explorar a API e suas funcionalidades, você pode usar a documentação disponível no Swagger. Acesse a documentação em `http://localhost:5000/swagger`.

<br>

## Contribuidores :busts_in_silhouette:

- [Breno Henrique](https://github.com/brenonsc)
- [Anderson Alves](https://github.com/ander-alves)

<br>

## Considerações Finais :checkered_flag:

Este repositório contém a API completa desenvolvida como parte do desafio DesafioIBGE. A API oferece funcionalidades básicas e adicionais, seguindo as melhores práticas de desenvolvimento de software.

Divirta-se explorando e utilizando a API! Se tiver alguma dúvida ou sugestão, sinta-se à vontade para entrar em contato com a equipe de desenvolvimento.