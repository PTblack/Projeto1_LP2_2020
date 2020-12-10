# Projeto1 - LP2 (2020)

## Autoria

* Diogo Henriques, nº 21802132
* João Dias, nº 21803573
* Pedro Fernandes, nº 21803791

### Distribuição de Tarefas

*Todos os membros do grupo estiveram envolvidos no projeto desde o seu início 
até à sua entrega, tendo todos tido parte no desenvolvimento da maioria das 
partes do mesmo*

1. O que cada membro fez
    * Diogo Henriques:

            Construiu as querries do search-planet e search-star e o overload 
            do operador '+' para Planet e Star.
            Envolvido também nas classes FileManager, FileSearcher, Menu e 
            nas structs Planet e Star.
            Encarregado pelo Doxygen e o UML.

    * João Dias:

            Responsável pelas classes FileSearcher e Menu. Envolvido também nas
            structs Planet e Star, nas classes FileManager e ExceptionManager 
            e no UML.

    * Pedro Fernandes:

            Responsável pelas classes FileManager e ExceptionManager e as 
            enumerações AttribPos e ErrorCodes. Envolvido também no 
            desenvolvimento das structs Planet, Star, nas classes FileSearcher 
            e Menu e no UML. 
            Escreveu a maioria do Markdown.

### Repositório Git Utilizado (Opcional)


[Repositório Git](https://github.com/PTblack/Projeto1_LP2_2020)

---

## Arquitetura da Solução

### Forma de Implementação

> Não-interativo, consola

### Descrição de Solução

* #### Como foi organizado
  Os argumentos são recebidos pela class `Menu`, que guarda os argumentos 
  passados pelo utilizador. Depois disto, a classe `FileManager` abre o 
  ficheiro, criando as coleções de Planet e Star. Criando estas coleções, são 
  enviadas para a classe `FileSearcher` onde, através de uma _querry_ cria-se 
  uma nova coleção filtrada com os criterios definidos pelo utilizador. Por fim, 
  estas coleções são imprimidas pela classe `Menu`, sendo que, caso o nome dado 
  pelo utilizador seja igual a algum dos nomes dos astros presentes na coleção, 
  imprime apenas um.
  
* #### Coleções usadas e porquê
  
  * #### HashSets
    
    Foram utilizadas _HashSets_ para guardar as coleções de planetas e de 
    estrelas, separadamente. Estas garantem que não são guardadas linhas do 
    `csv` exatamente iguais.
    
   * #### Dictionary
  
    Foram utilizados _Dictionaries_ para guardar os argumentos passados
    pelo utilizador. Criou-se um para cada tipo de argumentos: 
    bool (para os tipos de pesquisa), string (para nomes e tipos de 
    descoberta) e floats (para todos os limites de intervalos para os 
    atributos com um valor numérico).
   * #### IEnumerable
  
    Foram utilizados _IEnumerables_ para manter o maior nivel de generalidade
    possivel quando se guardava os resultados das _querrys_ para encontrar os 
    elementos que cumpriam os critérios definidos pelo utilizador.
  
* #### Algoritmos utilizados e porquê
  
  * #### FileManager

    Na classe `FileManager`, realizou-se o processo de abrir o ficheiro `csv`, 
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
    ficheiro, guardando a sua posição num _array_ de ints, para depois procurar 
    especificamente essa categoria em qualquer linha do ficheiro, ignorando as 
    outras.

    Estando as posições dos atributos identificados no _header_ guardadas, esses 
    valores são usados para o programa aceder especificamente às posições dos 
    atributos que lhe interessam, para criar as coleções `HashSetPL` e 
    `HashSetST`, guardando os valores pretendidos de cada linha em instâncias da 
    _struct_ `Planet` e da `Star`, guardando-as depois nas suas coleções 
    respetivas.

  * #### Menu

  Em  `Menu`, após obter a coleção filtrada de planetas ou de estrelas, 
  realiza-se nestas uma querry adicional que procura astros com exatamente o 
  mesmo nome que o argumento dado pelo utilizador nessa mesma propriedade, 
  passando os valores "selecionados" para uma _IEnumerable_ nova. Caso esta 
  coleção tenha qualquer valor que seja dentro da mesma, o que será mostrado ao 
  utilizador é o resultado da soma dos astros desta coleção, sendo que o que 
  acontece nesta operação com overload é que qualquer valor descrito como 
  "\[MISSING\]", será substituido pelo primeiro valor que existir para esta
  propriedade em qualquer uma das outras iterações do astro com o mesmo nome, 
  sendo o pretendido que, no fim desta operação, apresente-se o astro com o 
  máximo de campos preenchidos. Para além disto, específico para a estrela, 
  utiliza-se o tamanho desta _IEnumerable_ para determinar o número de planetas 
  que a orbitam, apresentando este valor juntamente com os outros atributos.

  * #### ExceptionManager

  A classe `static` `ExceptionManager` serve de central de controlo para 
  responder a quaisquer exceções que sejam identificadas na utilização do 
  programa. Esta, com o _método_ `ExceptionControl()`, tem o propósito de 
  interromper o programa e transmitir uma mensagem de erro compreensível, 
  indicando por que razão o programa parou. O _método_ identifica a mensagem a 
  mostrar através da utilização de uma enumeração chamada `ErrorCodes` que, 
  sendo passada para o método `ExceptionControl`, permite que este, através de 
  um SwitchCase, determine a mensagem exata a passar ao utilizador.
  
  Desta maneira, pode-se facilmente criar condições em diversos pontos do 
  código que, se verificadas, chamam esta _class_ e avisam de um erro. Exemplos 
  disto são o jogador não transmitir o mínimo de argumentos necessários quando 
  corre o programa, o ficheiro `csv` não possuir qualquer um dos atributos 
  obrigatórios (`pl_name`, `hostname` ou `help`), ou uma linha do ficheiro `csv` 
  não ter o mesmo número de itens que estão presentes/anunciados no _header_.

* #### As principais querrys construidas
  
  Na classe `FileSearcher`, foram feitas duas _queries_ que têm 
  como objetivo filtrar as coleções de planetas e estrelas criadas a partir da 
  informação do ficheiro, as `PlanetHashSet` e `StarHashSet`.
  O _filtro_, configurado de acordo com os argumentos passados para o programa 
  pelo utilizador, é constituido pelas condições diferentes definidas para cada 
  tipo destes, seja string ou float.

  Na classe `Menu`, existem duas queries adicionais feitas para determinar se 
  existem, na coleção filtrada - pelas queries já referidas - planetas ou 
  estrelas (de acordo com o tipo de procura) que tenham o nome exatamente 
  igual ao argumento dado pelo utilizador, servindo esta nova IEnumerable para 
  identificar uma unica instancia com o nome do planeta/estrela e para 
  determinar o número de planetas a orbitar a estrela.
  
* #### Otimizações implementadas
  
  Guardando as posições dos atributos importantes ao analizar-se o header do 
  ficheiro `csv`, é-se possível (quando se vai para construir as coleções) 
  analizar somente os atributos que interessam, ignorando os outros.

  Para guardar os valores numericos dos diversos atributos (temperatura, 
  raio, massa, etc.), evitou-se a utilização de ints, aplicando-se floats.

  Para todos o casos possíveis onde se sabiam o numero de dados pretendidos,
  criou-se coleções com tamanhos pré-definidos. Como exemplo tem-se as coleções 
  que se referem aos atributos importantes, criando-se estas sempre com um 
  número predefinido.

### Diagrama UML

![Diagrama UML](/images/uml.png) 

---

### Program Controls (Arguments for search type and criteria)

  **File:** `-file` \
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
  **Distance to Sun:** `-sy-dist-min` or `-sy-dist-max` \

  **The file the user wants to be searched must be in the Project Folder**

---

## Referências

* Troca de ideias com o colega Rafael Castro e Silva sobre como tratar
  dos argumentos na consola

* Microsoft .Net API
    https://docs.microsoft.com/en-us/dotnet/api/?term=console&view=netcore-3.1

* C# Database
    https://docs.microsoft.com/en-us/dotnet/csharp/
