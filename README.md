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

  Na class FileSearcher, realizou-se o processo de abrir o ficheiro csv, 
  determinar que atributos - dos pretendidos - este tem, e guardar as suas
  posições para depois criar as coleções de planetas  e estrelas através dos 
  atributos identificados.

  Isto acontece através do método FindValAttributeIndex, que abre o ficheiro e 
  progride até à primeira linha do ficheiro que não seja comentada ou vazia, 
  sendo esta o header do ficheiro csv que mostra as categorias presentes no 
  ficheiro. Após identificar esta linha, dentro do método FindValAttributeIndex, 
  chama-se FindValAttributes, passando-se um array criado a partir dessa mesma 
  linha do ficheiro (com o método Split()). Dentro deste método, o array é 
  analisado para se determinar quais dos atributos importantes existem no 
  ficheiro, guardando a sua posição no array, sendo isto usado para identificar 
  essa categoria em qualquer linha do ficheiro.

  Estando as posições dos atributos guardadas, aquando a chamada dos métodos
  CreatePlanetCollection e CreateStarCollection, esses valores são usados para o
  programa aceder especificamente às posições dos atributos que lhe interessam,
  guardando os valores de cada linha em instancias da classe planeta e da classe
  estrela.

* #### As principais querrys construidas
  
* #### Otimizações específicas implementadas
  
  Guardando as posições dos atributos importantes ao analizar-se o header do 
  ficheiro csv, é-se possível, quando se vai para construir as coleções, 
  analizar somente os atributos que interessam, ignorando os outros.

  Para todos o casos possíveis onde se sabiam o numero de dados pretendidos,
  criou-se coleções com tamanhos definidos. Como exemplo tem-se as coleções que
  se referem aos atributos importantes, criando-se estes sempre com um número
  predefinido.

### Diagrama UML

![Diagrama UML](/images/uml.png) 
< Terá de se por o caminho para a imagem 'uml' no markdown

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
> otimizações. Existem várias técnicas que podem e devem ser utilizadas para este fim, nomeadamente:

- [x] Os campos existentes em cada linha não necessários devem ser ignorados.

- [ ] Devem ser utilizados tipos apropriados e o mais "pequenos" possível para 
  cada um dos campos. Por exemplo, para representar o ano de descoberta é mesmo preciso um **int**?

- [x] As coleções usadas para guardar os dados devem ser pré-alocadas com o 
  tamanho exato necessário. Por exemplo, as listas têm um **construtor** que 
  aceita como parâmetro o tamanho inicial da lista, e os arrays são sempre 
  pré-alocados.