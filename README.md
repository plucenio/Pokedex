# Pokedex

* Aplicaçāo client que consome a PokeAPI

- Um pouco diferente do que a comunidade Xamarin tem seguido como arquitetura utilizando Services, Repositories, Views e ViewModels, A arquitetura deste APP foi definida em 4 camadas. Aproveitei o projeto pra aplicar um novo conceito pelo menos para mim. As 4 camadas:
    - Domain
    - Data
    - External
    - Presenter

    * Na camada Domain é onde as regras do aplicação são definidas, os usecases e as entidades conhecidas somente pela aplicação.

    * A camada Data é onde os dados são transformados, neste projeto em específico nenhuma regra foi aplicada.

    * A camada External é onde o app conhece o mundo externo, caso seja necessário fazer a troca de API de consumo, esta seria a parte que sofreria alterações e com impacto minimo nas outras camadas.

    * A camada de apresentação são as views e as viewmodels

- Um dos design aplicados ao projeto foi a utilização de injeção de dependências utilizando o Dryloc junto com o Prism Framework. Esta abordagem é muito importante para mim para a aplicação de testes automatizados. No projeto eu não apliquei testes em todos os módulos mas deixei claro que a utilização é plenamente possível.

* Alguns Nugets foram adicionados para deixar o alicativo um poucomais fluido, como:
    - LottieFiles: Para a utilização de animações disponiveis na biblioteca do lottieFiles.com.
    - XamAnimations: Para animações dos componentes XAML.
    - LiteDB (Desenvolvido pela empresa onde trabalho): Que é um banco de dados NoSQL que utiliza o fomato BSON. No meu ponto de vista um DB mais confiável que o SQLite.
    - Rg.Plugins: Para a utilização de popups
    - Pancake: Plugin para incrementos visuais como bordas arredondadas em componentes.

DETALHES DO PRODUTO

+ Dados de paginas e itens são cacheados
