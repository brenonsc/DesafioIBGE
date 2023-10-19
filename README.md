# DesafioIBGE :envelope::earth_americas:

Este repositório contém a API que foi criada como parte do desafio para gerenciar dados de cidades e estados de todo o Brasil, baseada no conjunto de dados disponível no seguinte repositório: [ibge](https://github.com/andrebaltieri/ibge). A API foi desenvolvida com base no desafio proposto e possui as funcionalidades especificadas.

<br>

## Funcionalidades da API

A API desenvolvida contém as seguintes funcionalidades:

### Autenticação e Autorização
- A API implementa um sistema de autenticação com token JWT para proteger as rotas da API. Os usuários podem se autenticar e receber um token JWT para acessar recursos protegidos.

### Cadastro de E-mail e Senha
- Os usuários podem se cadastrar na aplicação fornecendo um e-mail e senha.

### Login (Token, JWT)
- Após o cadastro, os usuários podem fazer login para obter um token JWT, que é utilizado para autenticar nas rotas protegidas da API.

### CRUD de Localidade
- A API oferece operações CRUD para gerenciar localidades, incluindo a criação, leitura, atualização e exclusão de informações como código, estado e cidade.

### Pesquisa por Cidade e por Estado
- Os usuários podem realizar pesquisas de localidades com base no nome da cidade ou do estado.

### Pesquisa por Código (IBGE)
- É possível pesquisar localidades com base no código IBGE correspondente.

### Boas práticas da API
- A API segue boas práticas de desenvolvimento de APIs, como tratamento de erros, respostas consistentes, etc.

### Versionamento
- A API pode incluir versionamento, facilitando futuras atualizações sem quebrar a compatibilidade com as versões anteriores.

### Padronização
- O código da API segue convenções de nomenclatura e padronização, tornando-o legível e consistente.

### Documentação (Swagger)
- A API é documentada com o uso do Swagger ou uma ferramenta similar, facilitando o uso e entendimento por parte dos desenvolvedores.

<br>

## Classificação das Equipes

A classificação da sua equipe (Júnior, Pleno ou Sênior) é determinada pelo integrante mais experiente. Com base nisso, seu grupo deve seguir as entregas correspondentes:

### Júnior

- Implementar todas as funcionalidades base
- Usar .NET 7 ou superior
- Arquitetura: MVC ou Minimal APIs com estrutura de projeto simples
- Objetivo: Entregar uma API funcionando

### Pleno

- Implementar todas as funcionalidades base
- Usar .NET 7 ou superior
- Arquitetura: Minimal APIs
- Incluir Testes de Unidade
- Objetivo: Entregar uma API funcionando, com boa arquitetura, organização, código limpo e testes de unidade.

### Sênior

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

## Contribuidores

- [Breno Henrique](https://github.com/brenonsc)
- [Anderson Alves](https://github.com/ander-alves)

<br>

## Considerações Finais

Este repositório contém a API completa desenvolvida como parte do desafio DesafioIBGE. A API oferece funcionalidades básicas e adicionais, seguindo as melhores práticas de desenvolvimento de software.

Divirta-se explorando e utilizando a API! Se tiver alguma dúvida ou sugestão, sinta-se à vontade para entrar em contato com a equipe de desenvolvimento.