# Projeto1 - LP2 (2020)

## Autoria

* Diogo Henriques, nº 21802132
* João Dias, nº 21803573
* Pedro Fernandes, nº 21803791

### Distribuição de Tarefas

*Todos os membros do grupo estiveram envolvidos no projeto desde o seu início 
até à sua entrega*

2. O que cada pessoa fez
    * Diogo Henriques:

            Lista do que fez

    * João Dias:

            Lista do que fez

    * Pedro Fernandes:

            As classes FileManager e ExceptionManager, envolvido também nas
            classes Planet e Star. Escreveu parte do Markdown.

### Repositório Git Utilizado (Opcional)

> Referencia a repositório utilizado

---

## Arquitetura da Solução

### Forma de Implementação

> Formato de Implemetnação escolhido 
> (interativo Unity/consola ou não-interativo consola decidir)

### Descrição de Solução

* #### Como foi organizado
  
  ![Fluxograma](/images/flowchart.png) 
< Terá de se por o caminho para a imagem 'flowchart' no markdown
  
* #### Coleções usadas e porquê
  
  * #### HashSets
    
    Foram utilizadas HashSets para guardar as coleções de planetas e de 
    estrelas, separadamente.
  
* #### Algoritmos utilizados e porquê
  
  #### FileSearcher

  Na classe `FileSearcher`, realizou-se o processo de abrir o ficheiro `csv`, 
  determinar que atributos - dos pretendidos - este tem, e guardar as suas
  posições nas linhas do ficheiro para depois criar as coleções de planetas 
  e estrelas através dos atributos identificados.

  Isto acontece através do _método_ `FindValAttributeIndex()`, que abre o 
  ficheiro e progride até à primeira linha do ficheiro que não seja comentada 
  (`#`) ou vazia (`""`), sendo esta o header do ficheiro `csv` que mostra as 
  categorias presentes no mesmo. 
  Após identificar esta linha, dentro de `FindValAttributeIndex()`, chama-se o 
  método `FindValAttributes()`, passando-se um _array_ criado a partir do 
  header do ficheiro (com o método `Split()`). Dentro deste método, o _array_ 
  é analisado para se determinar quais dos atributos importantes existem no 
  ficheiro, guardando a sua posição no _array_, para depois procurar 
  especificamente essa categoria em qualquer linha do ficheiro.

  Estando as posições dos atributos identificados no _header_ guardadas, esses 
  valores são usados para o programa aceder especificamente às posições dos 
  atributos que lhe interessam, para criar as coleções `HashSetPL` e 
  `HashSetST`, guardando os valores de cada linha em instâncias da 
  _struct_ `Planet` e `Star`, passando-as para as suas coleções respetivas.

  #### ExceptionManager

  A classe `static` `ExceptionManager` serve de central de controlo para 
  responder a quaisquer exceções que sejam identificadas na utilização do 
  programa. Esta, com o _método_ `ExceptionControl`, tem o propósito de 
  interromper o programa e transmitir uma mensagem de erro compreensível, 
  indicando por que razão o programa parou. O _método_ identifica a mensagem a 
  mostrar através da utilização de uma enumeração chamada `ErrorCodes` que, 
  sendo passada para o método `ExceptionControl`, permite que este, através de 
  um SwitchCase, determine a mensagem exata a passar ao utilizador.
  
  Desta maneira, pode-se facilmente criar condições em diversos pontos do 
  código que, se verificadas, chamam esta _class_ e avisam de um erro. Exemplos 
  disto são o jogador não transmitir o mínimo de argumentos necessários quando 
  corre o programa, o ficheiro csv não possuir qualquer um dos atributos 
  obrigatórios (`pl_name` ou `hostname`), ou uma linha do ficheiro `csv` não 
  ter o mesmo número de itens que estavam presentes no _header_.

* #### As principais querrys construidas
  
  Na classe `FileSearcher` foram feitas quatro _queries_ principais que têm 
  como objetivo filtrar as coleções de planetas e estrelas criadas a partir da 
  informação do ficheiro, sendo o _filtro_ configurado de acordo com os 
  argumentos passados para o programa pelo jogador.

  Para os apresentar a informação do planeta ou da estrela duas queries separadas
  uma para cada tipo, em que se o utilizador pedir a informação do planeta ou 
  estrela, `-planet-info` ou `star-info`, deve de inserir o nome do planeta e o 
  nome da estrela que ele orbita (_hostname_), ou no caso da estrela apenas o 
  nome dela, se forem encontrados mais de 1 planeta/estrela com o mesmo nome e 
  _hostname_, o programa deve apenas apresentar ao utilizador apenas um 
  planeta/estrela que tenha, todas as informações preenchidas, ou seja, se por 
  acaso houver alguma informação `[MISSING]`, esta deve ser preenchida, pela 
  informação de um planeta/estrela, com o mesmo nome e host name (ou só nome no 
  caso da estrela), que esteja abaixo. Isto é feito pegando na _query_ 
  `planet-info` / `star-info` e se esta tiver mais de um elemento, percorre 
  todos os elementos e preenche a informação que estiver vazia.

  Para procurar os planetas/estrelas temos outras duas _queries_, que filtram a 
  informação das coleções `PlanetHashSet` e `StarHashSet` de acordo com todas os 
  parâmetros de pesquisa para planetas e estrelas, em que todos os estes
  parâmetros da query são executados à parte dos obrigatórios, que têm de ser
  diferentes de `[MISSING]`.
  
* #### Otimizações implementadas
  
  Guardando as posições dos atributos importantes ao analizar-se o header do 
  ficheiro `.csv`, é-se possível, quando se vai para construir as coleções, 
  analizar somente os atributos que interessam, ignorando os outros.

  Para todos o casos possíveis onde se sabiam o numero de dados pretendidos,
  criou-se coleções com tamanhos definidos. Como exemplo tem-se as coleções que
  se referem aos atributos importantes, criando-se estes sempre com um número
  predefinido.

### Diagrama UML

![Diagrama UML](/images/uml.png) 
< Terá de se por o caminho para a imagem 'uml' no markdown

---

### Program Controls (Arguments for search type and criteria)

  **File:** `-file` \
  **Planet Information:** `-planet-info` \
  **Star Information:** `-star-info` \
  **Planet Search:** `-search-planet` \
  **Star Search:** `-search-star`

  **PLANET OPTIONS**

  > (`min` = minimum)
  > (`max` = maximum)

  **Name:** `-planet-name` \
  **Host Name (Star Name):** `-host-name` \
  **Discovery Method:** `-disc-method` \
  **Discovery Year:** `-disc-year-min` or `-disc-year-max` \
  **Orbit Period:** `-planet-orbper-min` or `-planet-orbper-max` \
  **Radius (vs Earth):** `-planet-rade-min` or `-planet-rade-max` \
  **Mass (vs Earth):** `-planet-mass-min` or `-planet-mass-max` \
  **Equilibrium Temperature:** `-planet-temp-min` or `-planet-temp-max` 

  **STAR OPTIONS**

  > (`min` = minimum)  \
  > (`max` = maximum)

  **Star Name:** `-host-name` \
  **Effective Temperature:** `-star-temp-min` or `-star-temp-max` \
  **Radius (vs Earth):** `-star-rade-min` or `-star-rade-max` \
  **Mass (vs Earth):** `-star-mass-min` or `-star-mass-max` \
  **Age:** `-star-age-min` or `-star-age-max` \
  **Rotation Velocity:** `-star-vsin-min` or `-star-vsin-max` \
  **Rotation Period:** `-star-rotp-min` or `-star-rotp-max` \
  **Distance to Sun:** `-sy-dist-min` or `-sy-dist-max`

---

## Referências

* Troca de ideias com o colega Rafael Castro e Silva sobre como tratar 
  dos argumentos

* Código aberto utilizado (Stack overflow) por exemplo)
* Bibliotecas de Terceiros utilizadas


---

## Lista de Sugestões

> ___a ser removido na altura de entrega___

Pôr um tick em cada parte feita/terminada (remover aos não adequados ao 
planeamento feito)

#### Sugestões para arquitetura do projeto

> _Seja em consola ou Unity, um bom modelo para começar a organizar as classes 
> deste projeto é o seguinte:_

- [ ] Uma classe controladora central que guia o programa. 
  Tudo o que acontece no programa parte desta classe.

- [ ] Uma classe exclusivamente dedicada ao UI.
  
- [x] Uma classe cuja responsabilidade é apenas abrir o ficheiro 
  e produzir as coleções necessárias de planetas e estrelas.

- [x] Uma classe cuja única responsabilidade é realizar queries 
  e devolver os resultados.

#### Sugestões de Otimização

> O ficheiro de dados pode ser grande, pelo que pode ser útil fazer algumas
> otimizações. Existem várias técnicas que podem e devem ser utilizadas para
> este fim, nomeadamente:

- [x] Os campos existentes em cada linha não necessários devem ser ignorados.

- [ ] Devem ser utilizados tipos apropriados e o mais "pequenos" possível para 
  cada um dos campos. Por exemplo, para representar o ano de descoberta é mesmo 
  preciso um **int**?

- [x] As coleções usadas para guardar os dados devem ser pré-alocadas com o 
  tamanho exato necessário. Por exemplo, as listas têm um **construtor** que 
  aceita como parâmetro o tamanho inicial da lista, e os arrays são sempre 
  pré-alocados.
