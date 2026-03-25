# 🃏 Biblioteca JogosGenericos - ARQUITETURA ABSTRATA para QUALQUER JOGO DE CARTAS

## 👥 Desenvolvedores
**Vinicius Oliveira** RM556908  
**Enzo Dias** RM558225  
**Gustavo Pierre** RM558928  
**Gabriel Belo** RM551669  
**Laura Souza** RM556320  

## 🎯 **FILOSOFIA DO PROJETO**

### **Por que esta biblioteca Class Library?**
Criei esta biblioteca pensando na **REUTILIZAÇÃO** e **EXTENSIBILIDADE**. Todo jogo de cartas (Truco, Poker, UNO, BlackJack, Canastra...) tem **padrões comuns**:

```
1. CARTAS (ICarta) - nome, valor, virar
2. PILHAS/MONTES (MonteDeCartas) - embaralhar, puxar cartas  
3. JOGADORES (IJogador) - mão, receber/descartar
4. FLUXO DE JOGO (JogoGenericoAbstrato) - turnos, vitória
```

**Ao invés de reescrever isso 10x**, uma biblioteca central que **qualquer desenvolvedor** pode referenciar e **ESTENDER em 4 métodos simples**!

### **Por que essas classes específicas?**
```
ICarta ← qualquer carta (UNO colorida, poker número/naipe)
  ↓
MonteDeCartas ← baralho, pilha descarte, reserva (genérico!)
  ↓  
IJogador ← IA ou humano (mesmo contrato)
  ↓
JogoGenericoAbstrato ← seu Truco/Poker em 20 linhas!
```

## 🏗️ **ARQUITETURA DETALHADA**

```
INTERFACES (contratos rígidos)
├── ICarta: Nome, Naipe?, Valor, Virar (obrigatório)
├── IJogador: Mao, ReceberCarta, Descartar  
└── IGameDeCartas: Jogadores, Turnos, Fim

CLASSES ABSTRATAS (implementação 80% pronta)
├── MonteDeCartas (abstract):
│   ├── InicializarMonte() ← seu tipo de carta
│   ├── Embaralhar(), PuxarCarta(), Adicionar()
├── JogoGenericoAbstrato:
│   ├── CriarMonte() ← seu monte
│   ├── CriarJogador() ← IA/humano  
│   ├── VerificarVitoria() ← sua regra
│   └── RealizarJogada() ← sua lógica turn

EXEMPLO CONCRETO (52 cartas tradicional)
├── CartaGenerica (implementa ICarta)
└── MonteGenericoTradicional (52 cartas)
```

## 🚀 **COMO USAR (3 minutos)**

### 1. Referencie a lib:
```xml
<PackageReference Include="JogosGenericos" Version="1.0.0" />
```

### 2. Crie seu jogo (ex: Truco):
```csharp
public class Truco : JogoGenericoAbstrato
{
    protected override MonteDeCartas CriarMonte() 
        => new MonteTruco(); // suas 40 cartas espanholas
    
    protected override IJogador CriarJogador(string nome) 
        => new JogadorIA(nome); // ou humano
    
    protected override bool VerificarCondicaoVitória()
        => jogador.Mao.Count == 0; // primeiro sem cartas ganha!
    
    protected override void RealizarJogada(IJogador jogador)
    {
        // lógica do truco: descartar pior carta
        var pior = jogador.Mao.MinBy(c => c.Valor);
        jogador.DescartarCarta(jogador.Mao.IndexOf(pior));
    }
}
```

### 3. Execute:
```csharp
var truco = new Truco(4);
truco.IniciarJogo();
while (!truco.JogoTerminado) truco.JogarTurno();
```

## 🛠️ **Compilar/Publicar**
```bash
cd JogosDeCartas
dotnet build
dotnet pack --output nupkgs/
```

## 🎉 **VANTAGENS desta arquitetura:**
- ✅ **Reutilizável** - uma lib para todos projetos
- ✅ **Testável** - mocks fáceis via interfaces  
- ✅ **Extensível** - seu jogo em 20 linhas
- ✅ **Robusta** - turnos, distribuição automática
- ✅ **Genérica** - UNO, Poker, Truco, Magic...

**Esta biblioteca resolve o problema "reinventar a roda" em jogos de cartas!** 🏆
