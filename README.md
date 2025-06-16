# Refit Demo

Este projeto demonstra como consumir APIs de forma **declarativa** utilizando a biblioteca [Refit](https://github.com/reactiveui/refit) em aplicações .NET. O exemplo utiliza a API pública do [TMDB (The Movie Database)](https://www.themoviedb.org/documentation/api) para ilustrar requisições HTTP tipadas, limpas e de fácil manutenção.

## Pré-requisitos

Escolha uma das opções para executar o projeto:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- [Postman](https://www.postman.com/) ou similar (para testar endpoints ou inspecionar resultados)

## Como Executar

Você pode executar o projeto de duas formas:

1. **Com Docker** (recomendado para evitar configurações locais)
2. **Localmente com .NET SDK** (caso já tenha o ambiente .NET configurado)

### Clone o Projeto

Clone este repositório em sua máquina local:

```bash
git clone https://github.com/kauatwn/Refit_Demo.git
```

### Executar com Docker

1. Navegue até a pasta raiz do projeto:

    ```bash
    cd Refit_Demo/
    ```

2. Construa a imagem Docker:

    ```bash
    docker build -t refitdemoapi:dev -f src/Refit_Demo.API/Dockerfile .
    ```

3. Execute o container:

    ```bash
    docker run -d -p 5000:8080 --name Refit_Demo.API refitdemoapi:dev
    ```

Após executar os comandos acima, a API estará disponível em `http://localhost:5000`.

### Executar Localmente com .NET SDK

1. Navegue até o diretório da API:

    ```bash
    cd src/Refit_Demo.API/
    ```

2. Restaure as dependências do projeto:

    ```bash
    dotnet restore
    ```

3. Inicie a aplicação:

    ```bash
    dotnet run
    ```

Após rodar a aplicação, a API ficará acessível em `http://localhost:5288`.

## Estrutura do Projeto

O projeto está organizado da seguinte forma:

```plaintext
Refit_Demo/
└── src/
    └── Refit_Demo.API/
        ├── Clients/
        │   └── ITmdbMovieApi.cs
        ├── Controllers/
        │   └── MoviesController.cs
        ├── DTOs/
        │   └── Responses/
        │       ├── MovieDetailsResponse.cs
        │       └── MovieListResponse.cs
        ├── Options/
        │   └── TmdbOptions.cs
        └── Services/
            └── TmdbService.cs
```

## Como Funciona

A biblioteca **Refit** permite definir interfaces para APIs HTTP externas. O projeto define uma interface para a API do TMDB e a consome de forma tipada, facilitando a manutenção e a clareza do código.

### Exemplo de requisição

```http
GET /api/movies/{movieId}
````

Este endpoint retorna os detalhes de um filme específico a partir de seu ID, incluindo título, descrição, data de lançamento e gêneros disponíveis.

```plaintext
http://localhost:5288/api/Movies/1113682?language=en-US
```

### Exemplo de resposta

```json
{
  "id": 1113682,
  "title": "Close Up",
  "originalTitle": "Close Up",
  "overview": "More than 150 silent short films about singers, actors and directors captured during Press Conferences in Cannes, Venice and Berlin, between 1993 and 2002. Presented the first time in 2012 (ten years after the last shooting) in Napoli Film Festival and in 2013 at the Art Institute of California in Santa Ana. An anthropological experiment on the facial expressions of famous people showing the human being aspect. All original footage from Mel Gibson to Peter Jackson, from George Lucas to Catherine Deneuve, from Michael Douglas to Giancarlo Giannini and many others.",
  "releaseDate": "2012-09-30",
  "genres": [
    {
      "id": 99,
      "name": "Documentary"
    }
  ]
}
```

> **Nota:** Para acessar a API do TMDB, é necessário fornecer uma chave de API válida. Consulte a documentação oficial do TMDB para obter sua chave e configure-a no arquivo de configuração do projeto.
