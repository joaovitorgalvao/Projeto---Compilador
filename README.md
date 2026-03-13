# Compilador C#

Um projeto educacional que implementa um compilador para a linguagem C#, com o objetivo de compreender o funcionamento do processo de compilação e suas etapas.

## 📋 Visão Geral

Este projeto é uma implementação didática de um compilador para C# que demonstra as principais fases da compilação:
- **Análise Léxica**: Tokenização do código-fonte
- **Análise Sintática**: Construção da árvore sintática abstrata (AST)
- **Análise Semântica**: Verificação de tipos e validação semântica
- **Geração de Código**: Tradução para código intermediário ou executável

## ✨ Características

- 📝 Suporte a estruturas básicas de C#
- 🔍 Análise léxica completa
- 🌳 Construção de árvore sintática abstrata (AST)
- ✅ Validação semântica e de tipos
- 🎯 Geração de código intermediário
- 🧪 Testes para cada etapa da compilação

## 🚀 Como Usar

### Instalação

```bash
git clone https://github.com/joaovitorgalvao/Projeto---Compilador.git
cd Projeto---Compilador
```

### Compilar um Arquivo C#

```bash
# Exemplo de uso (adicione o comando específico do seu compilador)
./compilador arquivo.cs
```

### Exemplo

```csharp
// arquivo.cs
class HelloWorld
{
    static void Main()
    {
        System.Console.WriteLine("Hello, World!");
    }
}
```

## 📂 Estrutura do Projeto

```
Projeto---Compilador/
├── src/                    # Código-fonte principal
│   ├── lexer/             # Análise léxica
│   ├── parser/            # Análise sintática
│   ├── semantic/          # Análise semântica
│   └── codegen/           # Geração de código
├── tests/                 # Testes unitários
├── examples/              # Exemplos de código C#
└── README.md             # Este arquivo
```

## 🔄 Etapas da Compilação

### 1. Análise Léxica (Lexer)
Converte o código-fonte em uma sequência de tokens.

### 2. Análise Sintática (Parser)
Constrói uma árvore sintática abstrata (AST) a partir dos tokens.

### 3. Análise Semântica (Semantic Analyzer)
Verifica tipos, validações e regras semânticas da linguagem.

### 4. Geração de Código (Code Generator)
Traduz o AST em código intermediário ou executável.

## 🧪 Testes

```bash
# Executar testes
./run_tests.sh
```

## 📚 Referências

- [Microsoft C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [Compiler Design Concepts](https://en.wikipedia.org/wiki/Compiler)

## 👤 Autor

**João Vitor Galvão**

## 📄 Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo LICENSE para detalhes.

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para:
1. Fazer um fork do projeto
2. Criar uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Fazer commit das mudanças (`git commit -m 'Adiciona MinhaFeature'`)
4. Fazer push para a branch (`git push origin feature/MinhaFeature`)
5. Abrir um Pull Request

## 💡 Próximas Melhorias

- [ ] Suporte a mais tipos de dados
- [ ] Otimizações de código
- [ ] Melhor tratamento de erros
- [ ] Documentação das classes principais
