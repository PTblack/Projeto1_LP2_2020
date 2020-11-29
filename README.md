# Projeto1 - LP2 (2020)

## Autoria

* Diogo Henriques, nº 21802132
* João Dias, nº 21803573
* Pedro Fernandes, nº 21803791

### Distribuição de Tarefas

1. O que foi feito pela equipa em geral

2. O que cada pessoa fez
    * Diogo Henriques:

            Lista do que fez

    * João Dias:

            Lista do que fez

    * Pedro Fernandes:

            Lista do que fez

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
  
* #### Algoritmos utilizados e porquê
  
* #### As principais querrys construidas
  
* #### Otimizações específicas implementadas

### Diagrama UML

![Diagrama UML](/images/uml.png) 
< Terá de se por o caminho para a imagem 'uml' no markdown

---

## Referências

* Trocas de Ideias com colegas
* Código aberto utilizado (Stack overflow) por exemplo)
* Bibliotecas de Terceiros utilizadas


---

# Lista de Sugestões

> ___a ser removido na altura de entrega___

Pôr um tick em cada parte feita/terminada (remover aos não adequados ao 
planeamento feito)

#### Sugestões para arquitetura do projeto

> _Seja em consola ou Unity, um bom modelo para começar a organizar as classes 
> deste projeto é o seguinte:_

- [ ] Uma classe controladora central que guia o programa. 
  Tudo o que acontece no programa parte desta classe.

- [ ] Uma classe exclusivamente dedicada ao UI.
  
- [ ] Uma classe cuja responsabilidade é apenas abrir o ficheiro 
  e produzir as coleções necessárias de planetas e estrelas.

- [ ] Uma classe cuja única responsabilidade é realizar queries 
  e devolver os resultados.

#### Sugestões de Otimização

> O ficheiro de dados pode ser grande, pelo que pode ser útil fazer algumas
> otimizações. Existem várias técnicas que podem e devem ser utilizadas para este fim, nomeadamente:

- [ ] Os campos existentes em cada linha não necessários devem ser ignorados.

- [ ] Devem ser utilizados tipos apropriados e o mais "pequenos" possível para 
  cada um dos campos. Por exemplo, para representar o ano de descoberta é mesmo preciso um **int**?

- [ ] As coleções usadas para guardar os dados devem ser pré-alocadas com o 
  tamanho exato necessário. Por exemplo, as listas têm um **construtor** que 
  aceita como parâmetro o tamanho inicial da lista, e os arrays são sempre 
  pré-alocados.

- [ ] No Unity, ao apresentar os resultados de dada pesquisa, é necessário ter 
  cuidado com a quantidade de resultados injetada no UI. Demasiados resultados 
  podem prejudicar o desempenho e até crashar a aplicação. O **LINQ** tem 
  formas de devolver apenas alguns resultados de cada vez,
  evitando esta situação.