# Projeto N2 - Progamação e Integração de Jogos

## Como jogar: 
Ao iniciar o jogo, movimente-se com W A S D, para selecionar a fase que deseja jogar aperte "E", ao completar uma fase, as próximas são liberadas. Dentro da fase, controle o personagem com "A" e "D" para se movimentar na horizontal e "ESPAÇO" para pular. Pode também subir e descer as escadas com "W" e "S", respectivamente. Dentro do menu de seleção de fases, aperte TAB para ver a tabela de upgrades, e clique com botão esquerdo para comprar se tiver moedas o suficiente.

## Estrutura de Dados:

### Grafo:
A representação de grafo utilizada no jogo foi o sistema de escolha de fase. Cada objeto que representa uma fase no menu é um nodo no grafo e contém um ID, o estado do nível que ele representa (completo, incompleto e bloqueado) e uma lista de nodos adjacentes. Todos os nodos são objetos dinâmicos, pois contém outras informações que precisam ser alteradas em runtime como o material e o estado do nível.

```
private void Start() - Desenha linhas o conectando aos nodos presentes na lista, para melhor representação visual.

public void SetLevelState() - Função pública para definir o estado do nível em runtime.

public void Teleport() - Muda a cena para o nível referênciado.

public bool IsUnlocked() - Retorna true se o nível está incompleto ou completo.
```

### Árvore:
A implementação de Árvore no jogo foi o sistema de melhorias do jogador. Cada melhoria é um elemento na árvore e contém um ID, um custo de compra, referência de seus "filhos" e um modificador que aplica ao player quando é comprado. Todos estes parâmetros são definidos na build e não tem necessidade de serem alocados dinamicamente, salvo algumas exceções para que a jogabilidade seja facilitada, como alteração de cor do botão, etc.

```
private void Start() - Chama o método IsBought() para checar se o jogador já comprou esse upgrade préviamente e atualizar seu estado.

private bool IsBought() - Checa se o jogador já comprou esta melhoria e, se sim, faz o mesmo com os filhos imediatos dela e assim sucessivamente.

private void TryBuyUpgrade() - Checa se o jogador pode comprar a melhoria e se sim, chama o método BuyUpgrade().

private void BuyUpgrade() - Remove as moedas do jogador, chama o método ApplyModifiers() e chama o método IsBought() para atualizar o estado da melhoria.

private void ApplyModifiers() - Aplica o devido modificador aos parâmetros do jogador.
```
